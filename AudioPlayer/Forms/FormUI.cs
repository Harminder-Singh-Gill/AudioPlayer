using AudioPlayer.Forms;
using NAudio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AudioPlayer
{
    public partial class FormUI : Form
    {
        private bool _progressBarBusy;
        private string jsonFileName = "AudioPlayerData.json";
        private int orLimit = 10;

        private MultiAudioPlayer player;
        private bool PlayListIsLoaded { get { return player != null && player.PlayListIsLoaded; } }
        private ExitState _exitState;

        private SpectrumAnalyzerVisualization spectrumAnalyzerVisualization;

        public FormUI()
        {
            InitializeComponent();
            menuStrip.Renderer = new MyRenderer();

            LoadExitState();
            RestoreExitUIState();

            //playlistPanel.BackColor = Color.FromArgb(90, Color.Black);

            spectrumAnalyzerVisualization = new SpectrumAnalyzerVisualization(this.spectrumAnalyser1);
        }

        #region Recent Audio

        private void PopulateOpenRecentMenu()
        {
            ClearRecentFromMenu();
            if (_exitState.RecentList == null) { return; }
            for (int i = 0; i < _exitState.RecentList.Count; i++)
            {
                BasicAudio audio = _exitState.RecentList.ElementAt(i);
                string content = audio.Title != String.Empty ? audio.Title : audio.SourceUrl;
                ToolStripMenuItem recentItem = new ToolStripMenuItem(content);
                recentItem.Click += new EventHandler(RecentItem_Click);
                recentItem.Tag = i;
                recentItem.DisplayStyle = openRecentToolStripMenuItem.DisplayStyle;
                recentItem.ForeColor = openRecentToolStripMenuItem.ForeColor;
                recentItem.BackColor = openRecentToolStripMenuItem.BackColor;
                this.openRecentToolStripMenuItem.DropDownItems.Add(recentItem);
            }
            if (openRecentToolStripMenuItem.DropDownItems.Count > 0)
            {
                ToolStripMenuItem clearRecent = new ToolStripMenuItem("Clear Recent");
                clearRecent.Click += new EventHandler(clearRecentToolStripMenuItem_Click);
                clearRecent.DisplayStyle = openRecentToolStripMenuItem.DisplayStyle;
                clearRecent.ForeColor = openRecentToolStripMenuItem.ForeColor;
                clearRecent.BackColor = openRecentToolStripMenuItem.BackColor;
                this.openRecentToolStripMenuItem.DropDownItems.Add(clearRecent);
                this.openRecentToolStripMenuItem.Enabled = true;
            }
        }
        private void clearRecentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_exitState.RecentList == null) { return; }
            _exitState.RecentList.Clear();
            ClearRecentFromMenu();
        }
        private void RemoveDuplicateFromRecents(Audio newAudio)
        {
            for (int i = 0; i < _exitState.RecentList.Count; i++)
            {
                BasicAudio audio = _exitState.RecentList[i];
                if (newAudio.IsEqual(audio))
                {
                    _exitState.RecentList.RemoveAt(i);
                    return;
                }
            }
        }

        private void AddToRecents(Audio audio)
        {
            if (_exitState.RecentList == null)
            {
                _exitState.RecentList = new List<BasicAudio>(orLimit);
            }else
            {
                RemoveDuplicateFromRecents(audio);
            }

            _exitState.RecentList.Insert(0, audio);
            if (_exitState.RecentList.Count > orLimit)
            {
                _exitState.RecentList.Remove(_exitState.RecentList.Last());
            }
            PopulateOpenRecentMenu();
        }

        private void ClearRecentFromMenu()
        {
            openRecentToolStripMenuItem.DropDownItems.Clear();
            openRecentToolStripMenuItem.Enabled = false;
        }

        private void RecentItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            BasicAudio basicAudio = _exitState.RecentList.ElementAt((int)item.Tag);
            Audio audio = MetaAudioUtility.GetNetworkAudioObject(basicAudio.SourceUrl);
            if (basicAudio.Source == AudioSource.Local)
            {
                audio = MetaAudioUtility.GetAudioObject(basicAudio.SourceUrl);
            }else if (basicAudio.Source == AudioSource.Youtube)
            {
                string url = YouTubeUtility.YouTubeBaseUrl + basicAudio.YoutubeVideoId;
                PlayFromYouTubeUrlAsync(url);
                return;
            }

            StartPlayback(audio);
        }

        #endregion

        #region ExitState
        private void RestoreExitUIState()
        {
            RestoreVolumeSetting();
            PopulateOpenRecentMenu();
        }

        private void RestoreVolumeSetting()
        {
            volumeSlider.Percent = _exitState.LastVolume;
            volumeLabel.Text = ((int)(_exitState.LastVolume * 100)).ToString();
        }

        private void LoadExitState()
        {
            if (File.Exists(jsonFileName))
            {
                string jsonString = File.ReadAllText(jsonFileName);
                _exitState = JsonConvert.DeserializeObject<ExitState>(jsonString);
            }
            else
            {
                _exitState = new ExitState();
            }
        }

        private void SaveExitState()
        {
            string jsonString = JsonConvert.SerializeObject(_exitState);
            File.WriteAllText(jsonFileName, jsonString);
        }
        #endregion

        #region Functionality
        #region PlayListFunctionality
        /// <summary>
        /// Calls player.ChangeSong(index) to change CurrentAudio in the Playlist to the one at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns> true if no exception was thrown by player.ChangeSong(), otherwise false.</returns>
        private bool ChangeAudio(int index)
        {
            if (PlayListIsLoaded)
            {
                try
                {
                    player.ChangeSong(index);
                    return true;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show(DesignUtility.FileNotFoundMessage);
                }
                catch (MmException)
                {
                    MessageBox.Show("Not a valid File");
                }
                catch (COMException)
                {
                    MessageBox.Show("Not a valid File");
                }catch (HttpRequestException)
                {
                    MessageBox.Show(DesignUtility.NoInternetMessage);
                    ClosePlayer();
                }
            }
            return false;
        }

        private void PlayPrevious()
        {
            if (PlayListIsLoaded)
            {
                if (!ChangeAudio(player.CurrentIndex - 1))
                {
                    if (player.PlayListHasPrevious)
                    {
                        DialogResult result = MessageBox.Show(DesignUtility.PlayPreviousMessage, DesignUtility.ErrorCaption, MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            PlayPrevious();
                            return;
                        }
                    }
                    ClosePlayer();
                }
            }
        }

        private void PlayNext()
        {
            if (PlayListIsLoaded)
            {
                if (!ChangeAudio(player.CurrentIndex + 1))
                {
                    DisplayPlayNextPrompt();
                }
            }
        }
        #endregion

        #region Playback Functionality
        #region Volume
        private void Unmute()
        {
            if (InPlaybackState)
            {
                player.Unmute();
                InMuteState = false;
            }
        }
        private void Mute()
        {
            if (InPlaybackState)
            {
                player.Mute();
                InMuteState = true;
            }
        }
        private void SetVolume(float value)
        {
            if (InPlaybackState)
            {
                player.SetVolume(value);
            }
        }
        #endregion

        private void Pause()
        {
            if (InPlaybackState)
            {
                player.Pause();
                InPauseState = true;
            }
        }

        private void Play()
        {
            if (InPlaybackState)
            {
                player.Play();
                InPauseState = false;
            }
        }
        private void StopAudio()
        {
            if (InPlaybackState)
            {
                player.Stop();
                InPlaybackState = false;
            }
        }

        private void Jump(int seconds)
        {
            if (InPlaybackState)
            {
                player.Jump(seconds);
            }
        }

        private void RestartAudio()
        {
            if (InPlaybackState)
            {
                player.RestartAudio();
            }
        }

        private void StartPlayback(Audio audio)
        {
            InitPlayer();
            player.Load(audio);
            Start(); // calls start on the player object and handles the exceptions that may be thrown
        }

        private void StartPlayback(List<Audio> audioList)
        {
            InitPlayer();
            player.Load(audioList);
            Start(); // calls start on the player object and handles the exceptions that may be thrown 
        }

        private void Start()
        {
            try
            {
                player.Start();
                return;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(DesignUtility.FileNotFoundMessage);
            }
            catch (MmException)
            {
                MessageBox.Show("Not a valid audio file");
            }
            catch (COMException)
            {
                MessageBox.Show("Not a valid audio file");
            }
            catch (HttpRequestException)
            {
                MessageBox.Show(DesignUtility.NoInternetMessage);
                ClosePlayer();
                return;
            }
            DisplayPlayNextPrompt();
        }
        
        #endregion
        #region Player Init and Close
        private void ClosePlayer()
        {
            if (PlayListIsLoaded)
            {
                _exitState.LastVolume = player.Volume;
                player.ResetPlayer();
                player = null;
                InPlaybackState = false;
            }
        }

        private void InitPlayer()
        {
            if (player == null)
            {
                player = new MultiAudioPlayer(_exitState.LastVolume);
                player.PlaybackStarted += new EventHandler(this.Playback_Started);
                player.PlayListEnded += new EventHandler(this.PlayList_Ended);
                player.PlayListLoaded += new EventHandler(this.PlayList_Loaded);
                player.MaximumCalculated += new EventHandler<MaxSampleEventArgs>(audioGraph_MaximumCalculated);
                player.FftCalculated += new EventHandler<FftEventArgs>(audioGraph_FftCalculated);
            }
            else
            {
                player.ResetPlayer();
            }
        }
        #endregion
        #endregion

        #region Miscellaneous
        private void DisplayPlayNextPrompt()
        {
            if (player.PlayListHasNext)
            {
                DialogResult result = MessageBox.Show(DesignUtility.PlayNextMessage, DesignUtility.ErrorCaption, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    PlayNext();
                    return;
                }
            }
            ClosePlayer();
        }

        private void ProgressBarMoved()
        {
            double ms = progressBarSlider.Percent * player.AudioDuration.TotalMilliseconds;
            player.ElapsedTime = TimeSpan.FromMilliseconds(ms);
        }
        private async void PlayFromYouTubeUrlAsync(string youtubeUrl)
        {
            try
            {
                loadingPictureBox.Visible = true;
                Audio audio = await YouTubeUtility.GetAudioObjectFromUrl(youtubeUrl);
                StartPlayback(audio);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(DesignUtility.ApologyMessage);
                ClosePlayer();
            }
            catch (System.Net.Http.HttpRequestException)
            {
                MessageBox.Show(DesignUtility.NoInternetMessage);
                ClosePlayer();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(DesignUtility.InvalidYouTubeUrlMessage);
                ClosePlayer();
            }
            loadingPictureBox.Visible = false;
        }
        #endregion

        #region Events
        #region Visualization Events
        void audioGraph_FftCalculated(object sender, FftEventArgs e)
        {
            if (this.spectrumAnalyzerVisualization != null)
            {
                this.spectrumAnalyzerVisualization.OnFftCalculated(e.Result);
            }
        }

        void audioGraph_MaximumCalculated(object sender, MaxSampleEventArgs e)
        {
            if (this.spectrumAnalyzerVisualization != null)
            {
                this.spectrumAnalyzerVisualization.OnMaxCalculated(e.MinSample, e.MaxSample);
            }
        }
        #endregion
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!_inPlaybackState)
            {
                return;
            }
            if (youtubeTextBox.Focused)
            {
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (InPauseState) { Play(); }
                    else { Pause(); }
                    break;
                case Keys.J:
                    Jump(-5);
                    break;
                case Keys.K:
                    Jump(5);
                    break;
                case Keys.Oemcomma:
                    PlayPrevious();
                    break;
                case Keys.OemPeriod:
                    PlayNext();
                    break;
                case Keys.R:
                    RestartAudio();
                    break;
                case Keys.X:
                    ClosePlayer();
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (!InPlaybackState) { return; }
            elapsedTimeLabel.Text = DesignUtility.GetTimeSpanString(player.ElapsedTime);
            if (!_progressBarBusy)
            {
                progressBarSlider.Percent = (float)(player.ElapsedTime.TotalSeconds / player.AudioDuration.TotalSeconds);
            }
        }

        #region Button Events
        private void pauseButton_Click(object sender, EventArgs e)
        {
            Pause();
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            RestartAudio();
        }
        protected virtual void playButton_Click(object sender, EventArgs e)
        {
            Play();
        }
        private void endButton_Click(object sender, EventArgs e)
        {
            ClosePlayer();
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            PlayNext();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            PlayPrevious();
        }

        private void playYoutubeButton_Click(object sender, EventArgs e)
        {
            StopAudio();

            loadingPictureBox.Visible = true;
            string youtubeQuery = youtubeTextBox.Text.Trim();

            YoutubeQueryBackgroundWorker.RunWorkerAsync(youtubeQuery);
            youtubeTextBox.Clear();
            playButton.Focus();
            //PlayFromYoutubeQueryAsync(youtubeQuery);
        }
        private void muteButton_Click(object sender, EventArgs e)
        {
            Mute();
        }

        private void unmuteButton_Click(object sender, EventArgs e)
        {
            Unmute();
        }
        #endregion

        #region YouTube TextBox Events
        private void youtubeTextBox_TextChanged(object sender, EventArgs e)
        {
            playYoutubeButton.Enabled = youtubeTextBox.Text.Trim() != String.Empty;
            playYoutubeXUIButton.Enabled = youtubeTextBox.Text.Trim() != String.Empty;
            hintLabel.Visible = youtubeTextBox.Text == String.Empty;
        }
        #endregion

        #region Slider Events
        private void progressBarSlider1_SliderDown(object sender, EventArgs e)
        {
            _progressBarBusy = true;
            ProgressBarMoved();
        }

        private void progressBarSlider1_SliderUp(object sender, EventArgs e)
        {
            _progressBarBusy = false;
        }
        private void progressBarSlider1_SliderMoved(object sender, EventArgs e)
        {
            ProgressBarMoved();
        }

        private void trackSlider1_ValueChanged(object sender, EventArgs e)
        {
            SetVolume(volumeSlider.Percent);
            if (InPlaybackState)
            {  
                volumeLabel.Text = ((int)(player.Volume*100)).ToString();
            }
            
        }
        #endregion

        #region MenuStrip Click Events
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = MetaAudioUtility.AudioFilesFilter;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Audio audio = MetaAudioUtility.GetAudioObject(ofd.FileName);
                if (audio.Title == null || audio.Title.Length == 0)
                {
                    audio.Title = ofd.SafeFileName;
                }
                StartPlayback(audio);
            }
        }

        private void openNetworkStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormPlayOnline formPlayOnline = new FormPlayOnline())
            {
                formPlayOnline.Text = "Play from Network";
                if (formPlayOnline.ShowDialog() == DialogResult.OK)
                {
                    StartPlayback(MetaAudioUtility.GetNetworkAudioObject(formPlayOnline.Url));
                }
            }
        }

        private void playFromYouTubeUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormPlayOnline formPlayOnline = new FormPlayOnline())
            {
                formPlayOnline.Text = "Play from YouTube";
                if (formPlayOnline.ShowDialog() == DialogResult.OK)
                {
                    PlayFromYouTubeUrlAsync(formPlayOnline.Url);
                }
            }
            //PlayFromYouTubeUrlAsync("https://www.youtube.com/watch?v=9kPvAPnvv9M");
        }

        private void playMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> urls = null;
            AudioSource source;
            using (FormPlayMultiple playMultiple = new FormPlayMultiple())
            {
                if (playMultiple.ShowDialog() == DialogResult.OK)
                {
                    urls = playMultiple.Urls;
                    source = playMultiple.Source;
                }else
                {
                    return;
                }
            }
            ClosePlayer();
            List<Audio> audioList;
            switch (source)
            {
                case AudioSource.Local:
                    audioList = MetaAudioUtility.GetAudioList(urls);
                    StartPlayback(audioList);
                    break;
                case AudioSource.Youtube:
                    loadingPictureBox.Visible = true;
                    YoutubeUrlsBackgroundWorker.RunWorkerAsync(urls);
                    break;
                case AudioSource.Network:
                    audioList = MetaAudioUtility.GetAudioListFromNetworkUrls(urls);
                    StartPlayback(audioList);
                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePlayer();
            SaveExitState();
            Application.Exit();
        }
        #endregion

        #region Audio Player Events
        private void Playback_Started(object sender, EventArgs e)
        {
            InPlaybackState = true;
            MakeUIChangesOnPlaybackStart();
        }

        private void MakeUIChangesOnPlaybackStart()
        {
            totalTimeLabel.Text = DesignUtility.GetTimeSpanString(player.AudioDuration);
            titleLabel.Text = player.CurrentAudio.Title;
            if (player.CurrentAudio.Artists != null)
            {
                artistLabel.Text = string.Join(", ", player.CurrentAudio.Artists);
            }
            coverPictureBox.Image = player.CurrentAudio.Thumbnail;
            AddToRecents(player.CurrentAudio);

            PlayListUIChangeSelected();
        }

        private void PlayListUIChangeSelected()
        {
            DeselectAudioItem(SelectedAudioItemPosition);
            FocusAudioItem(player.CurrentIndex);
            SelectedAudioItemPosition = player.CurrentIndex;
        }

        private int SelectedAudioItemPosition { get; set; } = 0;
        private void DeselectAudioItem(int position)
        {
            ImagePanel imagePanel = (ImagePanel)flowLayoutPanel2.Controls[position];
            imagePanel.BackColor = Color.FromArgb(30, Color.Black);
            imagePanel.BorderStyle = BorderStyle.None;
        }

        private void FocusAudioItem(int position)
        {
            ImagePanel imagePanel = (ImagePanel)flowLayoutPanel2.Controls[position];
            imagePanel.BackColor = Color.FromArgb(10, Color.White);
            imagePanel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void PopulatePlayListPanel(List<Audio> audioList)
        {
            ClearPlayListPanel();
            for (int i = 0; i < audioList.Count;i++)
            {
                Audio audio = audioList[i];
                ImagePanel imagePanel = new ImagePanel();
                imagePanel.Image = AudioPlayer.Properties.Resources.default_thumbnail;
                if (audio.Thumbnail != null) { imagePanel.Image = audio.Thumbnail; }
                imagePanel.TitleText = audio.Title;
                imagePanel.Height = 56;
                imagePanel.Width = flowLayoutPanel2.Width - 19;
                imagePanel.Margin = new Padding(0,2,0,2);
                imagePanel.BackColor = Color.FromArgb(30, Color.Black);
                imagePanel.Id = i;
                imagePanel.ImagePanelClick += new EventHandler(ImagePanel_Click);
                flowLayoutPanel2.Controls.Add(imagePanel);
            }
        }

        private void ImagePanel_Click(object sender, EventArgs e)
        {
            ImagePanel imagePanel = (ImagePanel) sender;
            ChangeAudio(imagePanel.Id);
        }

        private void ClearPlayListPanel()
        {
            flowLayoutPanel2.Controls.Clear();
            SelectedAudioItemPosition = 0;
        }

        private void PlayList_Ended(object sender, EventArgs e)
        {
            InPlaybackState = false;
        }

        private void PlayList_Loaded(object sender, EventArgs e)
        {
            PopulatePlayListPanel(player.PlayList);
        }
        #endregion

        #region Form Events
        private void FormUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosePlayer();
            SaveExitState();
        }
        #endregion

        #region BackgroundWorker Events
        #region Youtube Query Background Worker
        private void YoutubeQueryBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string query = (string)e.Argument;
            List<Audio> audioList = YouTubeUtility.GetAudioListFromQueryAsync(query).GetAwaiter().GetResult();
            e.Result = audioList;
        }

        private void YoutubeQueryBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            loadingPictureBox.Visible = false;
            if (e.Error != null)
            {
                try
                {
                    throw e.Error;
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show(DesignUtility.NoInternetMessage);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show(DesignUtility.ApologyMessage);
                }
                return;
            }

            if (e.Result == null) { return; }
            List<Audio> audioList = (List<Audio>)e.Result;
            if (audioList.Count == 0)
            {
                MessageBox.Show(DesignUtility.NoYouTubeResultsMessage);
            }else
            {
                StartPlayback(audioList);
            }
        }
        #endregion

        #region Youtube Urls BackgroundWorker
        private void YoutubeUrlsBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<string> urls = (List<string>)e.Argument;
            List<Audio> audioList = YouTubeUtility.GetAudioListFromYoutubeUrlsAsync(urls).GetAwaiter().GetResult();
            e.Result = audioList;
        }

        private void YoutubeUrlsBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            loadingPictureBox.Visible = false;
            if (e.Error != null)
            {
                try
                {
                    throw e.Error;
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show(DesignUtility.NoInternetMessage);
                }
                return;
            }
            if (e.Result == null) { return; }
            List<Audio> audioList = (List<Audio>)e.Result;
            StartPlayback(audioList);
        }
        #endregion

        #endregion

        #endregion

        #region Properties
        private bool _inPauseState;
        protected bool InPauseState
        {
            get { return _inPauseState; }
            set
            {
                _inPauseState = value;
                
                playButton.Visible = _inPauseState;
                pauseButton.Visible = !_inPauseState;
                timer1.Enabled = !_inPauseState;
            }
        }
        private bool _inPlaybackState;
        protected bool InPlaybackState
        {
            get { return _inPlaybackState; }
            set
            {
                _inPlaybackState = value;
                if (!_inPlaybackState)
                {
                    progressBarSlider.Percent = 0f;
                    ClearPlayListPanel();
                }
                else
                {
                    _progressBarBusy = false;
                }
                InPauseState = !_inPlaybackState;
                progressBarSlider.Enabled = _inPlaybackState;
                volumeSlider.Enabled = _inPlaybackState;
                elapsedTimeLabel.Visible = _inPlaybackState;
                totalTimeLabel.Visible = _inPlaybackState;
                timer1.Enabled = _inPlaybackState;
                titleLabel.Visible = _inPlaybackState;
                artistLabel.Visible = _inPlaybackState;
                coverImagePanel.Visible = _inPlaybackState;
                spectrumAnalyser.Visible = _inPlaybackState;
            }
        }

        private bool _inMuteState = false;
        private bool InMuteState
        {
            get { return _inMuteState; }
            set
            {
                _inMuteState = value;

                unmuteButton.Visible = value;
                muteButton.Visible = !value;
                volumeSlider.Enabled = !value;
            }
        }

        private void playYoutubeXUIButton_EnabledChanged(object sender, EventArgs e)
        {
            playYoutubeXUIButton.TextColor = playYoutubeXUIButton.Enabled ? Color.White : Color.DarkGray;
        }
        #endregion

        //private async void PlayFromYoutubeQueryAsync(string query)
        //{
        //    List<Audio> audioList = null;
        //    try
        //    {
        //        loadingPictureBox.Visible = true;
        //        audioList = await YouTubeUtility.GetAudioListFromQueryAsync(query);
        //        youtubeTextBox.Clear();
        //        StartPlayback(audioList);
        //    }
        //    catch(HttpRequestException)
        //    {
        //        MessageBox.Show(DesignUtility._noInternetMessage);
        //        return;
        //    }catch(InvalidOperationException)
        //    {
        //        MessageBox.Show(DesignUtility._apologyMessage);
        //    }
        //    finally
        //    {
        //        loadingPictureBox.Visible = false;
        //    }
        //}
    }
}