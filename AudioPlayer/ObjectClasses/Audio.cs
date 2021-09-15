using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class Audio : BasicAudio
    {
        public Audio()
        {
            Artists = new List<string>();
        }

        public Audio(string sourceUrl) : base(sourceUrl)
        {
            Artists = new List<string>();
        }

        public Image Thumbnail { get; set; }
        public List<string> Artists { get; set; }
    }
}
