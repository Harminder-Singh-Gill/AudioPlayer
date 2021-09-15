using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer.Players
{
    class PlayerV
    {
        private MediaFoundationReader mfr;
        private WaveOut woe;

        public PlayerV(float volume)
        {
            aggregator = new SampleAggregator();
            aggregator.NotificationCount = 882;
            aggregator.PerformFFT = true;

            _lastVolume = volume;
        }

        private ISampleProvider CreateInputStream(string fileName)
        {
            mfr = new MediaFoundationReader(fileName);
            SampleChannel inputStream = new SampleChannel(mfr);
            NotifyingSampleProvider sampleStream = new NotifyingSampleProvider(inputStream);
            sampleStream.Sample += (s, e) => aggregator.Add(e.Left);
            return sampleStream;
        }

        private SampleAggregator aggregator;

        public event EventHandler<FftEventArgs> FftCalculated
        {
            add { aggregator.FftCalculated += value; }
            remove { aggregator.FftCalculated -= value; }
        }

        public event EventHandler<MaxSampleEventArgs> MaximumCalculated
        {
            add { aggregator.MaximumCalculated += value; }
            remove { aggregator.MaximumCalculated -= value; }
        }

        public void Play()
        {
            if (IsActive)
            {
                woe.Play();
            }
            
        }

        public void Pause()
        {
            if (IsActive)
            {
                woe.Pause();
            }
        }

        public void Stop()
        {
            if (IsActive)
            {
                woe.Stop();
                //mfr.Position = 0;
            }
        }
        public void RestartAudio()
        {
            if (IsActive)
            {
                mfr.Position = 0;
            }
        }
        public void Jump(int seconds)
        {
            if (IsActive)
            {
                mfr.Skip(seconds);
            }
        }

        public void Load(string fileName)
        {
            CloseFile();

            woe = new WaveOut();
            woe.PlaybackStopped += new EventHandler<StoppedEventArgs>(Playback_Stopped);
            woe.Volume = _lastVolume;
            IsPlaying = true;

            OpenFile(fileName);

            InvokePlaybackStarted();
        }

        public void CloseFile()
        {
            if (mfr != null)
            {
                mfr.Dispose();
                mfr = null;
            }
        }
        public void Dispose()
        {
            if (woe != null)
            {
                woe.Dispose();
                woe = null;
            }
            if (mfr != null)
            {
                mfr.Dispose();
                mfr = null;
            }
        }

        public void Mute()
        {
            _lastVolume = woe.Volume;
            SetVolume(0);
        }
        /// <summary>
        /// Sets the volume of the audio playback
        /// </summary>
        /// <param name="volume"></param>
        public void SetVolume(float volume)
        {
            if (IsActive)
            {
                woe.Volume = volume;
                if (volume != 0)
                {
                    _lastVolume = volume;
                }
            }
        }
        public void Unmute()
        {
            SetVolume(_lastVolume);
        }

        private void OpenFile(string fileName)
        {
            var inputStream = CreateInputStream(fileName);
            woe.Init(new SampleToWaveProvider(inputStream));
        }
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
        protected void Playback_Stopped(object sender, StoppedEventArgs e)
        {

            if (IsActive) // && ElapsedTime >= AudioDuration)
            {
                if (AudioDuration.Subtract(ElapsedTime).TotalMilliseconds < 500)
                {
                    IsPlaying = false;
                    InvokePlaybackEnded();
                }
            }
        }
        #endregion Events
        #endregion EventHandling
        #region Properties
        public bool IsActive { get { return mfr != null && woe != null; } }
        public bool IsPlaying { get; private set; } = false;

        public TimeSpan AudioDuration
        {
            get { return mfr.TotalTime; }
        }

        public TimeSpan ElapsedTime
        {
            get { return mfr.CurrentTime; }
            set
            {
                if (mfr == null)
                {
                    return;
                }
                if (mfr.CurrentTime.CompareTo(value) == 0)
                {
                    return;
                }

                if (value > AudioDuration)
                {
                    mfr.CurrentTime = AudioDuration;
                }
                else if (value < TimeSpan.Zero)
                {
                    mfr.CurrentTime = TimeSpan.Zero;
                }
                else
                {
                    mfr.CurrentTime = value;
                }
            }
        }
        private float _lastVolume = 0f;

        public float Volume
        {
            get { return woe != null ? woe.Volume : _lastVolume; }
        }
        #endregion 
    }
}
