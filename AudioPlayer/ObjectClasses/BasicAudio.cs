using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class BasicAudio
    {
        public BasicAudio()
        {

        }
        public BasicAudio(string sourceUrl)
        {
            SourceUrl = sourceUrl;
        }

        public string SourceUrl { get; set; }
        public string Title { get; set; }
        public string YoutubeVideoId { get; set; }
        public AudioSource Source { get; set; }

        public bool IsEqual(BasicAudio audio)
        {
            if (this.Source != audio.Source) { return false; }
            if (this.SourceUrl == audio.SourceUrl) { return true; }
            if (this.Source == AudioSource.Youtube) { return this.YoutubeVideoId == audio.YoutubeVideoId; }
            return false;
        }
    }
}
