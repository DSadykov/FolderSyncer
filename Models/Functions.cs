using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;

namespace FolderSyncer.Models
{
    class FolderToSync : INotifyPropertyChanged
    {
        public FolderToSync(string p1, string p2, string time = "")
        {
            PathFrom = p1;
            PathTo = p2;
            if (time == "")
                LastUpdate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            else
                LastUpdate = time;
            BeginSyncing();
        }
        private Thread Syncer;
        private bool flag = true;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ~FolderToSync()
        {
            StopSyncing();
        }
        public bool Flag
        {
            get { return flag; }
            set
            {
                flag = value;
                OnPropertyChanged(nameof(Flag));
                if (flag == true)
                    BeginSyncing();
            }
        }
        public string PathFrom { get; set; }
        public string PathTo { get; set; }
        private string _lp = "";
        public string LastUpdate
        {
            get { return _lp; }
            set
            {
                if (value != LastUpdate)
                {
                    _lp = value;
                    OnPropertyChanged(nameof(LastUpdate));
                }
            }
        }
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
                if (Directory.Exists(PathTo) && Directory.Exists(PathFrom))
                {
                    foreach (string file in Directory.GetFiles(PathFrom, "*", SearchOption.AllDirectories))
                    {
                        filename = file.Substring(PathFrom.Length, file.Length - PathFrom.Length);
                        Sync(filename, CheckForChanges(filename));
                    }
                    foreach (string file in Directory.GetFiles(PathTo, "*", SearchOption.AllDirectories))
                    {
                        filename = file.Substring(PathTo.Length, file.Length - PathTo.Length);
                        if (!File.Exists(PathFrom + filename) && File.Exists(PathTo + filename) && !filename.Contains(".deleted"))
                        {
                            LastUpdate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                            File.Move(PathTo + filename, PathTo + filename + ".deleted");
                        }
                    }
                    Thread.Sleep(1000);
                }
                else if(!Directory.Exists(PathTo))
                {
                    MessageBox.Show("Directory "+PathTo+" wasn't found","Error");
                    Flag = false;
                }
                else if (!Directory.Exists(PathFrom))
                {
                    MessageBox.Show("Directory " + PathFrom + " wasn't found", "Error");
                    Flag = false;
                }
            }

        }
        private void Sync(string filename, states type)
        {
            switch (type)
            {
                case states.noex:
                    {
                        File.Copy(PathFrom + filename, PathTo + filename, true);
                        LastUpdate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                        break;
                    }
                case states.noexsub:
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(PathTo + filename)))
                            Directory.CreateDirectory(Path.GetDirectoryName(PathTo + filename));
                        LastUpdate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                        File.Copy(PathFrom + filename, PathTo + filename, true);
                        break;
                    }
                case states.older:
                    {

                        File.Copy(PathFrom + filename, PathTo + filename, true);
                        LastUpdate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
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
