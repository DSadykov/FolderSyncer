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
        static public ObservableCollection<Models.FolderToSync> Folders = new ObservableCollection<Models.FolderToSync>();
        
        private bool CanLaunchAdd()
        {
            return true;
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
