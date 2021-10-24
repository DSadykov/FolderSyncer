using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace FolderSyncer.ModelViews
{
    class MainViewModel
    {
        private ICommand _addcommand;

        public ICommand AddCommand
        {
            get
            {
                if (_addcommand == null)
                {
                    _addcommand = new RelayCommand(
                        param => this.LaunchAdd(),
                        param => this.CanLaunchAdd()
                    );
                }
                return _addcommand;
            }
        }
        private ICommand _deletecommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_deletecommand == null)
                {
                    _deletecommand = new RelayCommand(
                        param => this.DeleteCom(param),
                        param => this.CanDelete(param)
                    );
                }
                return _deletecommand;
            }
        }
        static public ObservableCollection<Models.FolderToSync> Folders = new ObservableCollection<Models.FolderToSync>();

        private bool CanLaunchAdd()
        {
            return true;
        }
        private bool CanDelete(object Item)
        {
            Models.FolderToSync folder = Item as Models.FolderToSync;
            return folder != null;
        }
        private void DeleteCom(object Item)
        {
            Models.FolderToSync folder = Item as Models.FolderToSync;
            folder.StopSyncing();
            Folders.Remove(folder);
        }
        private void LaunchAdd()
        {
            var tmp = new AddWindows();
            tmp.Show();
        }

        private void LoadINI()
        {

            //TODO:
        }
    }
}
