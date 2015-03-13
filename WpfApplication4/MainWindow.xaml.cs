using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication4.ViewModels;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WpfApplication4
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static myPlayer getPlayer { get; set; }
        myPlayer        pl = new myPlayer();
        DispatcherTimer timer = new DispatcherTimer();
        double          time = 0;
        bool            isPlaying = false;
        bool            isDragging = false;
        enum repeat { NONE, SONG, ALL };
        repeat _repeat = repeat.ALL;
        public MainWindow()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            pl.setMedia(this.MediaEl);
            getPlayer = pl;
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += new EventHandler(clock);
            this.DataContext = pl.mv;
            this.playlist.ItemsSource = pl.mv.ListSongs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying == false)
            {
                isPlaying = true;
                pl.playAudio();
                MediaButton.Content = FindResource("Stop");
            }
            else
            {
                isPlaying = false;
                pl.pauseAudio();
                MediaButton.Content = FindResource("Play");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pl.stopAudio();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            pl.browseFile();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (_repeat == repeat.ALL)
            {
                RepeatButton.Content = FindResource("repeat_song");
                _repeat = repeat.SONG;
            }
            else if (_repeat == repeat.NONE)
            {
                RepeatButton.Content = FindResource("repeat_all");
                _repeat = repeat.ALL;
            }
            else
            {
                RepeatButton.Content = FindResource("no_repeat");
                _repeat = repeat.NONE;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (this.playlist.SelectedIndex != -1)
                pl.delPlayList(this.playlist.SelectedIndex);
        }

        void playlist_MouseDoubleClick(object sender, System.Windows.Input.MouseEventArgs e)
        {
            int index = this.playlist.SelectedIndex;
            if (index >= 0 || index < this.playlist.Items.Count)
                pl.changeCurrent(index);
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            int index = this.playlist.SelectedIndex;
            if (index >= 0 && index < this.playlist.Items.Count)
                pl.changeCurrent(index);
        }

        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (MediaEl.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = MediaEl.NaturalDuration.TimeSpan;
                SeekBar.Maximum = ts.TotalSeconds;
                SeekBar.SmallChange = 1;
                MediaEl.Volume = (double)volume.Value;
                SeekBar.LargeChange = Math.Min(10, ts.Seconds / 10);
            }
            timer.Start();
        }

        void clock(object sender, EventArgs e)
        {
            if (isDragging == false)
            {
                SeekBar.Value = MediaEl.Position.TotalSeconds;
                time = SeekBar.Value;
            }
            try
            {
                if (SeekBar.Value == MediaEl.NaturalDuration.TimeSpan.TotalSeconds)
                {
                    SeekBar.Value = 0;
                    if (_repeat == repeat.SONG)
                        pl.changeCurrent(pl._currentSongIndex);
                    else if (_repeat == repeat.NONE)
                    {
                        if (pl._currentSongIndex == pl._maxSongIndex - 1)
                        {
                            MediaButton.Content = FindResource("Play");
                            return;
                        }
                    }
                    else
                        pl.changeCurrent(pl._currentSongIndex + 1);
                }
            }
            catch { }
              
        }

        private void playlist_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            e.Effects = System.Windows.DragDropEffects.None;
        }

        private void getDataOfADir(string path)
        {
            string[] files = System.IO.Directory.GetFiles(path);
            string[] directories = System.IO.Directory.GetDirectories(path);

            foreach (string file in files)
            {
                if (file.EndsWith(".mp3") || file.EndsWith(".wav") || file.EndsWith(".wma"))
                {
                    SongViewModel song = new SongViewModel();
                    song.PathName = file;
                    song.SafeName = System.IO.Path.GetFileNameWithoutExtension(file);
                    song.fillMeta();
                    pl.mv.ListSongs.Add(song);
                }
            }
            foreach (string directorie in directories)
            {
                getDataOfADir(directorie);
            }
        }
        private void playlist_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
            {
                String[] files = (String[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
                foreach (string file in files)
                {

                    if (System.IO.Directory.Exists(file))
                        getDataOfADir(file);
                    else if (file.EndsWith(".mp3") || file.EndsWith(".wav") || file.EndsWith(".wma"))
                    {
                        SongViewModel song = new SongViewModel();
                        song.PathName = file;
                        song.SafeName = System.IO.Path.GetFileNameWithoutExtension(file);
                        song.fillMeta();
                        pl.mv.ListSongs.Add(song);
                    }
                }
            }
        }
        private void seekBar_DragStarted(object sender, DragStartedEventArgs e)
        {
            isDragging = true;
        }
        private void seekBar_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            isDragging = false;
            MediaEl.Position = TimeSpan.FromSeconds(SeekBar.Value);
        }
        private void volume_DragStarted(object sender, DragStartedEventArgs e)
        {

        }
        private void volume_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            MediaEl.Volume = (double)volume.Value;
        }
        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
           pl.mv.Name = Plname.Text;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            pl.mv.savePlaylist();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                pl.mv.parseWpl();
                pl.changeCurrent(0);
                pl.playAudio();
            }
            catch { }
        }

        [DllImport("user32.dll")]
        static extern uint GetDoubleClickTime();

        System.Timers.Timer timeClick = new System.Timers.Timer((int)GetDoubleClickTime())
        {
            AutoReset = false
        };

        bool fullScreen = false;

        private void MediaElement_LeftClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("GREAT!");
            if (!timeClick.Enabled)
            {
                timeClick.Enabled = true;
                return;
            }

            if (timeClick.Enabled)
            {
                if (!fullScreen)
                {
                    MediaGrid.Children.Remove(MediaEl);
                    this.Background = new SolidColorBrush(Colors.Black);
                    this.Content = MediaEl;
                    this.WindowStyle = WindowStyle.None;
                    this.WindowState = WindowState.Maximized;
                    MediaEl.Position = TimeSpan.FromSeconds(time);
                }
                else
                {
                    this.Content = MainGrid;
                    MediaGrid.Children.Add(MediaEl);
                    this.Background = new SolidColorBrush(Colors.White);
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.WindowState = WindowState.Normal;
                    MediaEl.Position = TimeSpan.FromSeconds(time);
                }
                fullScreen = !fullScreen;
            }
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            myPlayer pl = getPlayer;
            pl.mv.savePlaylist(1);
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            // user clicked an item of listview control
            if (listView.SelectedItems.Count == 1)
            {
                SongViewModel a = (SongViewModel)listView.SelectedItems[0];
                pl.addPlaylist(a);
            }
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && listView.SelectedItems.Count >= 1)
            {
                foreach (SongViewModel a in listView.SelectedItems)
                    pl.addPlaylist(a);
                e.Handled = true;
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (libgrid.Visibility == Visibility.Collapsed)
            {
                MediaEl.Visibility = Visibility.Collapsed;
                libgrid.Visibility = Visibility.Visible;
            }
            else
            {
                libgrid.Visibility = Visibility.Collapsed;
                MediaEl.Visibility = Visibility.Visible;
            }
        }

        private void UpdateBinding(object sender, TextChangedEventArgs e)
        {
            var binding = (sender as TextBox).GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (playlist.SelectedIndex == -1) return;
            pl.delPlayList(playlist.SelectedIndex);
        }

        private void playlist_KeyDown(object sender, KeyEventArgs e)
        {
            int index = playlist.SelectedIndex;
            if (e.Key == Key.Delete && index != -1)
            {
                if (index >= 0 && index < this.playlist.Items.Count)
                    pl.delPlayList(playlist.SelectedIndex);
            }
            if (e.Key == Key.Enter && index != -1)
            {
                if (index >= 0 && index < this.playlist.Items.Count)
                {
                    pl.changeCurrent(index);
                    pl.playAudio();
                }
            }
        }

    }
}
