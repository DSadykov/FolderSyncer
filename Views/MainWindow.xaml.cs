using FolderSyncer.Models;
using ModernWpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FolderSyncer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Folders_DG.ItemsSource = ModelViews.MainViewModel.Folders;
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
        }

        private void CoreWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string _folders = "";
            foreach (var tmp in ModelViews.MainViewModel.Folders)
            {
                _folders += tmp.PathFrom + "|" + tmp.PathTo + "|" + tmp.LastUpdate + "\n";
            }
            File.WriteAllText("settings.ini", _folders);
        }

        private void CoreWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("settings.ini"))
                foreach (var str in File.ReadAllText("settings.ini").Trim().Split("\n"))
                    if (str != "")
                        ModelViews.MainViewModel.Folders.Add
                            (new FolderToSync(str.Split('|')[0], str.Split('|')[1], str.Split('|')[2]));
        }
    }
}
