using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioPlayer.Forms
{
    class ExitState
    {
        public float LastVolume { get; set; } = 0f;
        public bool RepeatOn { get; set; } = false;
        public List<BasicAudio> RecentList { get; set; }
    }
}
