using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace FolderSyncer.ModelViews
{
    class AddFolderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Action CloseAction { get; set; }
        private string _fp = "", _sp = "";
        private ICommand _firstfolderselect;
        private ICommand _secondfolderselect;
        private ICommand _done;
        public string FirstPath
        {
            get { return _fp; }
            set
            {
                if (value != _fp)
                {
                    _fp = value;
                    OnPropertyChanged(nameof(FirstPath));
                }
            }
        }
        public string SecondPath
        {
            get { return _sp; }
            set
            {
                if (value != _sp)
                {
                    _sp = value;
                    OnPropertyChanged(nameof(SecondPath));
                }
            }
        }
        public ICommand FirstFolderSelect
        {
            get
            {
                if (_firstfolderselect == null)
                {
                    _firstfolderselect = new RelayCommand(
                        param => this.AddFolder(true),
                        param => { return true; }
                    );
                }
                return _firstfolderselect;
            }
        }
        public ICommand SecondFolderSelect
        {
            get
            {
                if (_secondfolderselect == null)
                {
                    _secondfolderselect = new RelayCommand(
                        param => this.AddFolder(false),
                        param => { return true; }
                    );
                }
                return _secondfolderselect;
            }
        }
        public ICommand Done
        {
            get
            {
                if (_done == null)
                {
                    _done = new RelayCommand(
                        param => this.SendFolder(),
                        param =>
                        {
                            if (FirstPath != "" && SecondPath != "")
                                return true;
                            else
                                return false;
                        }
                    );
                }
                return _done;
            }
        }
        private void AddFolder(bool firstPath)
        {
            FolderBrowserDialog tmp = new FolderBrowserDialog();
            if (tmp.ShowDialog() == DialogResult.OK)
            {
                if (firstPath)
                    FirstPath = tmp.SelectedPath;
                else
                    SecondPath = tmp.SelectedPath;
            }
        }
        private void SendFolder()
        {
            ModelViews.MainViewModel.Folders.Add(new Models.FolderToSync(_fp, _sp));
            CreateINI();
            CloseAction();
        }
        private void CreateINI()
        {
            string _folders = "";
            foreach (var tmp in ModelViews.MainViewModel.Folders)
            {
                _folders += tmp.PathFrom + "|" + tmp.PathTo +"|"+tmp.LastUpdate+ "\n";
            }
            File.WriteAllText("settings.ini", _folders);
        }
    }
}
