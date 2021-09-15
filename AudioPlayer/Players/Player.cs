using NAudio.Wave;
using System;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AudioPlayer
{
    public class Player
    {
        private WaveOut outputDevice;
        //private WaveOutEvent outputDevice;
        private MediaFoundationReader audioFile;
        public Player(float volume)
        {
            PlaybackEnded += new EventHandler(Playback_Ended);
            _lastVolume = volume;
        }

        #region Glenn
        #region Properties
        public bool IsActive { get { return audioFile != null && outputDevice != null; } }
        public bool IsPlaying { get; private set; } = false;

        public TimeSpan AudioDuration
        {
            get { return audioFile.TotalTime; }
        }

        public TimeSpan ElapsedTime
        {
            get { return audioFile.CurrentTime; }
            set
            {
                if (audioFile == null)
                {
                    return;
                }
                if (audioFile.CurrentTime.CompareTo(value) == 0)
                {
                    return;
                }

                if (value > AudioDuration)
                {
                    audioFile.CurrentTime = AudioDuration;
                }
                else if (value < TimeSpan.Zero)
                {
                    audioFile.CurrentTime = TimeSpan.Zero;
                }
                else
                {
                    audioFile.CurrentTime = value;
                }
            }
        }
        private float _lastVolume = 0f;

        public float Volume
        {
            get { return outputDevice != null ? outputDevice.Volume : _lastVolume; }
        }
        #endregion Properties


        #region EventHandling
        #region EventHandlers
        public event EventHandler PlaybackStarted;
        public event EventHandler PlaybackEnded;
        #endregion EventHandlers
        #region EventInvokers
        private void InvokePlaybackStarted()
        {
            PlaybackStarted?.Invoke(this, EventArgs.Empty);
        }
        private void InvokePlaybackEnded()
        {
            PlaybackEnded?.Invoke(this, EventArgs.Empty);
        }
        #endregion EventInvokers

        #region Events
        protected virtual void Playback_Ended(object sender, EventArgs e)
        {
            IsPlaying = false;
        }
        protected void Playback_Stopped(object sender, StoppedEventArgs e)
        {
            
            if (IsActive) // && ElapsedTime >= AudioDuration)
            {
                if (AudioDuration.Subtract(ElapsedTime).TotalMilliseconds < 500)
                {
                    InvokePlaybackEnded();
                }
            }
        }
        #endregion Events
        #endregion EventHandling
        #endregion Glenn

        #region Waqar
        /// <summary>
        /// Starts audio playback from local file. Initializes all audio playback Components for file playback
        /// </summary>
        public void Start(string file)
        {
            try 
            {
                audioFile = new MediaFoundationReader(file);
                //outputDevice = new WaveOutEvent();
                outputDevice = new WaveOut();
                outputDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(Playback_Stopped);
                outputDevice.Init(audioFile);
                outputDevice.Volume = _lastVolume;
                outputDevice.Play();
                IsPlaying = true;
                InvokePlaybackStarted();
            }
            catch (Exception)
            {
                // System.IO.FileNotFoundException or
                // System.Runtime.InteropServices.COMException or
                // MmException
                throw;
            }
        }
        
        /// <summary>
        /// Stops audio playback.
        /// </summary>
        public void StopAudio()
        {
            if (IsActive)
            {
                outputDevice.Stop();
            }
        }

        /// <summary>
        /// Disposes all audio components.
        /// </summary>
        public void Dispose()
        {
            if (outputDevice != null)
            {
                
                outputDevice.Dispose();
                outputDevice = null;
            }
            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }
        }

        /// <summary>
        /// Pauses the audio playback
        /// </summary>
        public void Pause()
        {
            if (IsActive)
            {
                outputDevice.Pause();
            }
        }
        /// <summary>
        /// Resumes the audio playback
        /// </summary>
        public void Play()
        {
            if (IsActive)
            {
                outputDevice.Play();
            }
        }

        /// <summary>
        /// Restarts the current audio playback from the beginning
        /// </summary>
        public void RestartAudio()
        {
            if (IsActive)
            {
                ElapsedTime = TimeSpan.Zero;
            }
        }

        /// <summary>
        /// Sets the volume of the audio playback
        /// </summary>
        /// <param name="volume"></param>
        public void SetVolume(float volume)
        {
            if (IsActive)
            {   
                outputDevice.Volume = volume;
            }
        }
        public void Mute()
        {
            _lastVolume = outputDevice.Volume;
            SetVolume(0);
        }

        public void Unmute()
        {
            SetVolume(_lastVolume);
        }

        /// <summary>
        /// Makes the audio playback jump forward or backward by parameter seconds
        /// </summary>
        public void Jump(int seconds)
        {
            if (IsActive)
            {
                audioFile.Skip(seconds);
            }
        }
        #endregion Waqar
    }
}