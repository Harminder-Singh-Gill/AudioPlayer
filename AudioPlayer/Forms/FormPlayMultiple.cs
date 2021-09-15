using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioPlayer
{
    public enum AudioSource { Youtube, Local, Network }
    public partial class FormPlayMultiple : Form
    {
        private ListBox _activeListBox;
        private Button _activeAddButton;
        private Button _activeRemoveButton;
        private Button _activeUpButton;
        private Button _activeDownButton;
        private TextBox _activeTextBox;

        public AudioSource Source;
        public List<Audio> AudioList { get; set; }
        public List<string> Urls { get; set; }

        public FormPlayMultiple()
        {
            InitializeComponent();
            _activeListBox = fileListBox;
            _activeAddButton = fileAddButton;
            _activeRemoveButton = fileRemoveButton;
            _activeUpButton = fileUpButton;
            _activeDownButton = fileDownButton;
            _activePlayButton = filePlayButton;
            this.Source = AudioSource.Local;

            _activePlayButton.Enabled = false;
            _activeRemoveButton.Enabled = false;
            _activeUpButton.Enabled = false;
            _activeDownButton.Enabled = false;
        }

        #region Harminder
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (_activeListBox.SelectedIndex == -1)
            {
                _activeListBox.Items.Add(_activeTextBox.Text);
            }
            else
            {
                _activeListBox.Items.Insert(_activeListBox.SelectedIndex + 1, _activeTextBox.Text);
            }
            _activeTextBox.Clear();
            _activePlayButton.Enabled = _activeListBox.Items.Count > 0;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = _activeListBox.SelectedIndex;
            if (selectedIndex > -1)
            {
                if (selectedIndex > 0)
                {
                    _activeListBox.SetSelected(selectedIndex - 1, true);
                }
                _activeListBox.Items.RemoveAt(selectedIndex);
            }
            _activePlayButton.Enabled = _activeListBox.Items.Count > 0;
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            if (_activeListBox.SelectedIndex > 0)
            {
                MoveSelectedItem(-1);
            }
        }

        private void MoveSelectedItem(int steps)
        {
            int oldIndex = _activeListBox.SelectedIndex;
            int newIndex = oldIndex + steps;

            object temp = _activeListBox.Items[oldIndex];
            _activeListBox.Items[oldIndex] = _activeListBox.Items[newIndex];
            _activeListBox.Items[newIndex] = temp;

            _activeListBox.SetSelected(newIndex, true);
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            if (_activeListBox.SelectedIndex < _activeListBox.Items.Count - 1 && _activeListBox.SelectedIndex != -1)
            {
                MoveSelectedItem(1);
            }
        }

        private void AddFilesUnderSelected(string[] files)
        {
            for (int i = 0; i < files.Length; i++)
            {
                fileListBox.Items.Insert(fileListBox.SelectedIndex + 1 + i, files[i]);
            }
        }

        private void filesAddButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = MetaAudioUtility.AudioFilesFilter;
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (fileListBox.SelectedIndex == -1)
                {
                    fileListBox.Items.AddRange(ofd.FileNames);
                }else
                {
                    AddFilesUnderSelected(ofd.FileNames);
                }
            }
            filePlayButton.Enabled = fileListBox.Items.Count > 0;
        }
        #endregion Harminder

        #region Glenn

        private void Cancel()
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Events
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _activeRemoveButton.Enabled = _activeListBox.SelectedIndex != -1;
            _activeUpButton.Enabled = _activeListBox.SelectedIndex != -1;
            _activeDownButton.Enabled = _activeListBox.SelectedIndex != -1;
        }

        private Button _activePlayButton;
        private void tabControl1_Selected(object sender, EventArgs e)
        {
            if (playMultipleTab.SelectedTab == fileTab)
            {
                this.Source = AudioSource.Local;
                _activeListBox = fileListBox;
                _activeAddButton = fileAddButton;
                _activeRemoveButton = fileRemoveButton;
                _activeUpButton = fileUpButton;
                _activeDownButton = fileDownButton;
                _activePlayButton = filePlayButton;
                _activeTextBox = null;
            }
            else if (playMultipleTab.SelectedTab == youtubeTab)
            {
                this.Source = AudioSource.Youtube;
                _activeListBox = youtubeListBox;
                _activeAddButton = youtubeAddButton;
                _activeRemoveButton = youtubeRemoveButton;
                _activeUpButton = youtubeUpButton;
                _activeDownButton = youtubeDownButton;
                _activeTextBox = youtubeTextBox;
                _activePlayButton = youtubePlayButton;

            }
            else if (playMultipleTab.SelectedTab == networkTab)
            {
                this.Source = AudioSource.Network;
                _activeListBox = urlListBox;
                _activeAddButton = urlAddButton;
                _activeRemoveButton = urlRemoveButton;
                _activeUpButton = urlUpButton;
                _activeDownButton = urlDownButton;
                _activeTextBox = urlTextBox;
                _activePlayButton = urlPlayButton;
            }
            _activePlayButton.Enabled = _activeListBox.Items.Count > 0;
            _activeAddButton.Enabled = _activeTextBox == null || _activeTextBox.Text.Trim() != String.Empty;
            _activeRemoveButton.Enabled = _activeListBox.SelectedIndex != -1;
            _activeUpButton.Enabled = _activeListBox.SelectedIndex != -1;
            _activeDownButton.Enabled = _activeListBox.SelectedIndex != -1;
        }
        private void Tab_Click(object sender, EventArgs e)
        {
            _activeListBox.SelectedIndex = -1;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        //private async void PlayButtonClickAsync()
        //{
        //    List<string> urls = new List<string>(_activeListBox.Items.Cast<string>());
        //    if (playMultipleTab.SelectedTab == youtubeTab)
        //    {
        //        try
        //        {
        //            AudioList = await YouTubeUtility.GetAudioListFromYoutubeUrlsAsync(urls); //exception handling TODO
        //        }catch (HttpRequestException)
        //        {
        //            MessageBox.Show(DesignUtility._noInternetMessage);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        AudioList = MetaAudioUtility.GetAudioList(urls);
        //    }
        //    DialogResult = DialogResult.OK;
        //    this.Close();
        //}
        private void playMultiButton_Click(object sender, EventArgs e)
        {
            // PlayButtonClickAsync();
            Urls = new List<string>(_activeListBox.Items.Cast<string>());
            DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion Events

        #endregion Glenn

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            _activeAddButton.Enabled = _activeTextBox.Text.Trim() != String.Empty;
        }
    }
}
