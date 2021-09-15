using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioPlayer
{
    static class MetaAudioUtility
    {
        public static readonly string AudioFilesFilter = "Audio|*.mp3;*.wav;*.wave;*.aif;*.aiff;*.aifc;*.wma;*.wmv;*.m4a;*.3gp;*.m4b;*.m4p;*.m4r;*.m4v;*.aac;*.mp4";

        public static Audio GetAudioObject(string filePath)
        {
            Audio audio = new Audio();
            using (TagLib.File file = TagLib.File.Create(filePath))
            {
                audio.SourceUrl = filePath;
                audio.Title = file.Tag.Title;
                if (audio.Title == null || audio.Title == String.Empty)
                {
                    audio.Title = "Local Streaming...";
                }
                audio.Source = AudioSource.Local;
                if (file.Tag.Performers != null)
                {
                    audio.Artists.AddRange(file.Tag.Performers);
                }
                TagLib.IPicture[] pics = file.Tag.Pictures;
                if (pics.Length != 0)
                {
                    byte[] bin = pics[0].Data.Data;
                    audio.Thumbnail = Image.FromStream(new MemoryStream(bin));
                }
                else
                {
                    audio.Thumbnail = null;
                }
            }
            return audio;
        }

        public static List<Audio> GetAudioList(List<string> filePaths)
        {
            List<Audio> audios = new List<Audio>();
            foreach (var path in filePaths)
            {
                audios.Add(GetAudioObject(path));
            }
            return audios;
        }
        public static Audio GetNetworkAudioObject(string url)
        {
            Audio audio = new Audio();
            audio.SourceUrl = url;
            audio.Source = AudioSource.Network;
            audio.Title = "Network Streaming...";
            return audio;
        }

        public static List<Audio> GetAudioListFromNetworkUrls(List<string> urls)
        {
            List<Audio> audioList = new List<Audio>();
            foreach (var url in urls)
            {
                audioList.Add(GetNetworkAudioObject(url));
            }
            return audioList;
        }

    }
}
