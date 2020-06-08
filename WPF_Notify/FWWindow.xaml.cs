using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace WPF_Notify
{
    /// <summary>
    /// Logika interakcji dla klasy FWWindow.xaml
    /// </summary>
    public partial class FWWindow : Window
    {
        public TextBoxContent TextBoxContent { get; set; } = new TextBoxContent();
        private FileSystemWatcher FSM = new FileSystemWatcher();
        private string _path;
        public FWWindow()
        {
            InitializeComponent();
            MyTextBox.DataContext = TextBoxContent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog()
            {
                Title = "Wybierz plik do obserwowania",
                Filter = "Pliki .txt (*.txt)|*.txt"
            };
            fileDialog.ShowDialog(this);

            _path = fileDialog.FileName;
            var text = File.ReadAllText(_path);
            TextBoxContent.Content = text;
            FSM.Path = _path.Replace(fileDialog.SafeFileName, string.Empty);
            FSM.NotifyFilter = NotifyFilters.LastWrite;
            FSM.EnableRaisingEvents = true;
            FSM.Changed += FSM_Changed;
        }

        private void FSM_Changed(object sender, FileSystemEventArgs e)
        {
            TextBoxContent.Content = File.ReadAllText(_path);
        }
    }
}
