using ModernWpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FolderSyncer
{
    /// <summary>
    /// Interaction logic for AddWindows.xaml
    /// </summary>
    public partial class AddWindows : Window
    {
        public AddWindows()
        {
            InitializeComponent();
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(Close);
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
        }
    }
}
