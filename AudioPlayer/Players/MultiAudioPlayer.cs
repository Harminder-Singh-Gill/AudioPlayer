using AudioPlayer.Players;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace AudioPlayer
{
    class MultiAudioPlayer : PlayerV
    {
        public MultiAudioPlayer(float volume): base(volume)
        {
            base.PlaybackEnded += new EventHandler(Playback_Ended);
        }
        public event EventHandler PlayListLoaded;

        private void InvokePlayListLoaded()
        {
            PlayListLoaded?.Invoke(this, EventArgs.Empty);
        }

        public List<Audio> PlayList { get; set; }
        public int CurrentIndex { get; set; } = -1;

        public Audio CurrentAudio {
            get
            {
                if (PlayList == null)
                {
                    return null;
                }

                if (PlayList.Count <= CurrentIndex)
                {
                    return null;
                }

                return PlayList[CurrentIndex];
            } 
        }

        public bool PlayListIsLoaded { get { return PlayList != null && PlayList.Count > 0; } }
        public bool PlayListHasNext { get { return CurrentIndex + 1 < PlayList.Count; } }
        public bool PlayListHasPrevious { get { return CurrentIndex > 0; } }

        #region MultiPlayer Functionality
        public void Load(Audio audio)
        {
            if (PlayListIsLoaded)
            {
                ResetPlayer();
            }

            PlayList = new List<Audio>
            {
                audio
            };
            CurrentIndex = 0;
            InvokePlayListLoaded();
        }

        public void Load(List<Audio> audioList)
        {
            if (PlayListIsLoaded)
            {
                ResetPlayer();
            }

            PlayList = audioList;
            CurrentIndex = 0;
            InvokePlayListLoaded();
        }

        public void ChangeSong(int index)
        {
            if (!PlayListIsLoaded) { return; }
            if (index >= 0 && index < PlayList.Count)
            {
                CurrentIndex = index;
                try
                {
                    Start();
                }catch (Exception)
                {
                    throw;
                }
            }
        }
        public void ResetPlayer()
        {
            PlayList = null;
            CurrentIndex = -1;
            base.Dispose();
        }
        public void Start()
        {
            if (!PlayListIsLoaded) { return; }
            base.Dispose();
            try
            {
                base.Load(CurrentAudio.SourceUrl);
                base.Play();
            }
            catch (Exception)
            {
                // System.IO.FileNotFoundException or
                // System.Runtime.InteropServices.COMException or
                // MmException
                throw;
            }
        }

        //public void Start()
        //{
        //    if (!PlayListIsLoaded) { return; }
        //    base.Dispose();
        //    try
        //    {
        //        base.Start(CurrentAudio.SourceUrl);
        //    }
        //    catch (Exception)
        //    {
        //        // System.IO.FileNotFoundException or
        //        // System.Runtime.InteropServices.COMException or
        //        // MmException
        //        throw;
        //    }
        //}

        public void PlayNext()
        {
            try
            {
                ChangeSong(CurrentIndex + 1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PlayPrevious()
        {
            try
            {
                ChangeSong(CurrentIndex - 1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddToPlayList(Audio audio)
        {
            if (PlayListIsLoaded)
            {
                PlayList.Add(audio);
            }
        }

        public void AddToPlayList(List<Audio> audios)
        {
            if (PlayListIsLoaded)
            {
                PlayList.AddRange(audios);
            }
        }

        #endregion MultiPlayer Functionality
        #region EventHandling
        public event EventHandler PlayListEnded;
        private void InvokePlayListEnded()
        {
            PlayListEnded?.Invoke(this, EventArgs.Empty);
        }

        protected void Playback_Ended(object sender, EventArgs e)
        {
            if (!PlayListIsLoaded) { return; }
            
            bool playNextFailed = true;
            while (playNextFailed && PlayListHasNext)
            {
                try
                {
                    PlayNext();
                    playNextFailed = false;
                }
                catch (Exception)
                {
                    playNextFailed = true;
                }
            }

            if (playNextFailed)
            {
                ResetPlayer();
                InvokePlayListEnded();
            }
        }
        #endregion EventHandling
    }
}
