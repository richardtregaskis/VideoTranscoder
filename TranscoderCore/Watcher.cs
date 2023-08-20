using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoTranscoderCore
{
	public class Watcher
	{
        private FileSystemWatcher _watcher;
        private List<string> _watchedFiles = new List<string>();

        public void WatchFolder(string folderToWatch)
        {
           _watcher = new FileSystemWatcher(folderToWatch);

            _watcher.NotifyFilter = NotifyFilters.LastWrite;

            _watcher.Changed += OnChanged;
            
            _watcher.Filter = "*.mp4";
            _watcher.IncludeSubdirectories = false;
            _watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                if (_watchedFiles.Contains(e.FullPath))
                {
                    //_watchedFiles.Remove(e.FullPath);

                    //string targetFile = TranscodeCore.GetTargetFilename(e.FullPath);
                    //string command = TranscodeCore.GetProResCommandString(TranscodeCore.ProResProfile.YUV422LT, e.FullPath, targetFile);
                    //Transcoder.TranscodeVideo(command, targetFile);
                }
                else
                {
                    _watchedFiles.Add(e.FullPath);
                }
            }
           
        }      
    }
}
