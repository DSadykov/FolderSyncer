using System.IO;
using System.Threading;

namespace FolderSyncer.Models
{
    class FolderToSync
    {
        public FolderToSync(string p1, string p2)
        {
            PathFrom = p1;
            PathTo = p2;
            BeginSyncing();
        }
        ~FolderToSync()
        {
            flag = false;
        }
        private Thread Syncer;
        private bool flag = true;
        public string PathFrom { get; set; }
        public string PathTo { get; set; }
        private enum states { noexsub, noex, older, newer, }
        
        private states CheckForChanges(string name)
        {
            if (!File.Exists(PathTo + name))
            {
                if (name.Contains(@"\"))
                    return states.noexsub;
                else
                    return states.noex;
            }
            else
            {
                if (File.GetLastWriteTimeUtc(PathFrom + name) < File.GetLastWriteTimeUtc(PathTo + name))
                    return states.older;
                else
                    return states.newer;
            }
        }
        private void CheckAllFiles()
        {
            while (flag)
            {
                string filename;
                foreach (string file in Directory.GetFiles(PathFrom, "*", SearchOption.AllDirectories))
                {
                    filename = file.Substring(PathFrom.Length, file.Length - PathFrom.Length);
                    Sync(filename, CheckForChanges(filename));
                }
                foreach (string file in Directory.GetFiles(PathTo, "*", SearchOption.AllDirectories))
                {
                    filename = file.Substring(PathTo.Length, file.Length - PathTo.Length);
                    if (!File.Exists(PathFrom + filename) && File.Exists(PathTo + filename)&&!filename.Contains(".deleted"))
                        File.Move(PathTo + filename, PathTo + filename + ".deleted");
                }
                Thread.Sleep(1000);
            }
            
        }
        private void Sync(string filename, states type)
        {
            switch (type)
            {
                case states.noex:
                    {
                        File.Copy(PathFrom + filename, PathTo + filename, true);
                        break;
                    }
                case states.noexsub:
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(PathTo + filename)))
                            Directory.CreateDirectory(Path.GetDirectoryName(PathTo + filename));
                        File.Copy(PathFrom + filename, PathTo + filename, true);
                        break;
                    }
                case states.older:
                    {
                        File.Copy(PathFrom + filename, PathTo + filename, true);
                        break;
                    }
                case states.newer:
                    break;
            }
        }
       
        public void BeginSyncing()
        {
            Syncer = new Thread(new ThreadStart(CheckAllFiles));
            Syncer.IsBackground = true;
            Syncer.Start();
        }
        public void StopSyncing()
        {
            flag = false;
        }
    }
}
