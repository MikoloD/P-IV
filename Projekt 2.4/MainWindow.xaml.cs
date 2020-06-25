using System;
using System.Collections.Generic;
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
using System.Media;
using System.IO;
using WMPLib;
using Microsoft.Win32;
using Path = System.IO.Path;
using System.Threading;
using System.Windows.Threading;

namespace Projekt_2._4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Kontekst db = new Kontekst();
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        private List<Utwor> playList = new List<Utwor>();
        private void Najpop()
        {
            if (db.Utwory.Count() != 0)
            {
                var najpopularniejsze = db.Utwory.Max(x => x.Popularity);
                Utwor displayed = db.Utwory.Where(x => x.Popularity == najpopularniejsze).First();
                Najpopularnirjsze.Text = $"Najpopularniejszy utwór to: {displayed.Name}";
            }
            else
            {
                Najpopularnirjsze.Text = $"Brak najpopularniejszego utworu";
            }
        }
        private Utwor TakeFromComboBox(ComboBox myCombobox)
        {
            Utwor wynik = db.Utwory.Where(x => x.Name == myCombobox.SelectedItem.ToString()).First();
            if(myCombobox != ChooseSingleCombobox) myCombobox.SelectedItem = null;
            return wynik;
        }
        private void UpdateWindow()
        {
            var bazaUtworow = db.Utwory.Select(x => x.Name).ToList();
            LitaUtworow.ItemsSource = bazaUtworow;
            ListaUtworowComboBox.ItemsSource = bazaUtworow;
            PlayListChooser.ItemsSource = bazaUtworow;
            ChooseSingleCombobox.ItemsSource = bazaUtworow;
        }
        private void UpdatePlaylist()
        {
            var playLista = playList.Select(x => x.Name).ToList();
            PlayList.ItemsSource = playLista;
            PlayListDeleteCombobox.ItemsSource = playLista;
        }
        public MainWindow()
        {
            InitializeComponent();
            UpdateWindow();
            Najpop();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "mp3 files (*.mp3)|*.mp3";
            dialog.ShowDialog();
            string path = dialog.FileName;
            string name = Path.GetFileNameWithoutExtension(path);
            if (path != null && name != null)
            {
                db.Utwory.Add(new Utwor
                {
                    Name = name,
                    Path = path,
                    Popularity =0
                });
                db.SaveChanges();
                UpdateWindow();
            }
        }

        private void PlayListAdd_Button_Click(object sender, RoutedEventArgs e)
        {
                playList.Add(TakeFromComboBox(PlayListChooser));
                UpdatePlaylist();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {

            Utwor usun = TakeFromComboBox(ListaUtworowComboBox);
            db.Utwory.Remove(usun);
            db.SaveChanges();
            UpdateWindow();
        }

        private void DeletePlayList_Button_Click(object sender, RoutedEventArgs e)
        {
            Utwor usun = TakeFromComboBox(PlayListDeleteCombobox);
            playList.Remove(usun);
            UpdatePlaylist();
        }
        private void PlaySingle_Button_Click(object sender, RoutedEventArgs e)
        {
            string path = TakeFromComboBox(ChooseSingleCombobox).Path;
            db.Utwory.Where(x => x.Path == path).First().Popularity++;
            db.SaveChanges();
            var wybrany = db.Utwory.Where(x => x.Path == path).First();
            Najpop();
            player.URL = wybrany.Path;
        }

        private void Pause_Button_Click(object sender, RoutedEventArgs e)
        {
            player.controls.pause();          
        }

        private void Wznow_Button_Click(object sender, RoutedEventArgs e)
        {
            player.controls.play();
        }

        private void PlayList_Button_Click(object sender, RoutedEventArgs e)
        {
            IWMPPlaylist playlist = player.playlistCollection.newPlaylist("mojaPlaylista");
            foreach (var elem in playList)
            {
                IWMPMedia media = player.newMedia(elem.Path); ;
                db.Utwory.Where(x => x.Id == elem.Id).First().Popularity++;
                db.SaveChanges();
                playlist.appendItem(media);
            }
            Najpop();
            player.currentPlaylist = playlist;
            player.controls.play();
        }
    }
}
