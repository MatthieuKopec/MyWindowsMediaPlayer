using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WpfApplication4.ViewModels;

namespace WpfApplication4
{
    public class myPlayer
    {
        public SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("fr-FR"));
        private MediaElement                        mediaEl;
        public MainWindowViewModel                  mv = new MainWindowViewModel();
        public ViewableCollection<SongViewModel>    _songs;
        public SongViewModel                        test = new SongViewModel();
        public int                                  _currentSongIndex = 0;
        public int                                  _maxSongIndex = 0;
        private OpenFileDialog                      openFileDialog1 = new OpenFileDialog();
        private DialogService                       dl = new DialogService();
        private String                              duration;
        private FileSystemWatcher                           watcher = new FileSystemWatcher();

        public String                               Duration
        {
            get
            {
                if (duration == null)
                {
                    duration = String.Format("");
                }
                return duration;
            }
        }
        public myPlayer()
        {
            test.PathName = "";
            test.SafeName = "Select a track";
            speechEnable();
            initiateLibrary();
            mv.Songs.Add(test);
        }

        public void setMedia(MediaElement el)
        {
            mediaEl = el;
        }
        public void playAudio()
        {
            mediaEl.Play();
        }

        public void pauseAudio()
        {
            mediaEl.Pause();
        }

        public void stopAudio()
        {
            mediaEl.Stop();
        }

        public void addPlaylist()
        {
            SongViewModel song = new SongViewModel();
            song.PathName = test.PathName;
            song.SafeName = test.SafeName;
            mv.ListSongs.Add(song);
            _maxSongIndex++;
            for (int i = 0; i < mv.LibSongs.Count(); ++i)
                if (mv.LibSongs[i].SafeName == song.SafeName)
                    return;
            mv.LibSongs.Add(song);
        }
        public void addPlaylist(SongViewModel song)
        {
            mv.ListSongs.Add(song);
        }

        public void delPlayList(int index)
        {
            if (mv.ListSongs.Count() > 0 && index > -1)
            {
                _maxSongIndex--;
                mv.ListSongs.RemoveAt(index);
            }
        }

        public void browseFile()
        {
            if (dl.GetOpenFileDialog("", "") == true)
            {
                test.PathName = dl.PathName;
                test.SafeName = dl.SafeName;

                test.fillMeta();
                mediaEl.Source = new Uri(dl.PathName);

                SongViewModel song = new SongViewModel();
                song.PathName = test.PathName;
                song.SafeName = Path.GetFileNameWithoutExtension(test.PathName);
                addPlaylist();
            }
        }

        public void changeCurrent(int index)
        {
            if (mv.ListSongs.Count() > 0)
            {
                if (index >= mv.ListSongs.Count())
                    index = 0;
                _currentSongIndex = index;
                test.SafeName = mv.ListSongs[index].SafeName;
                test.PathName = mv.ListSongs[index].PathName;
                test.fillMeta();
                mediaEl.Source = new Uri(test.PathName);
            }
        }
        /// <summary>
        /// A placer dans une classe distincte ensuite !
        /// </summary>
        /// <param name="args"></param>
        public void speechEnable()
        {
                var c = new Choices();
                c.Add("player play");
                c.Add("player stop");
                c.Add("player next");
                c.Add("good job player");

                var gb = new GrammarBuilder(c);
                var g = new Grammar(gb);
                recognizer.LoadGrammar(g);
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence < 0.4)
                 return;
            myPlayer player = MainWindow.getPlayer;
            if (e.Result.Text == "player play")
                player.playAudio();
            else if (e.Result.Text == "player stop")
                player.stopAudio();
            else if (e.Result.Text == "good job player")
                player._synthesizer.Speak("Thank you master.");

        }

        private void initiateLibrary()
        {
            List<string> wplfiles = new List<string> { };
            string appFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Music Library");
            Directory.CreateDirectory(appFolder);
            string historyFile = Path.Combine(appFolder, "history.wpl");
            if (File.Exists(historyFile))
                wplfiles = mv.parseWpl(historyFile);
            var files = Directory.GetFiles(appFolder, "*.*", SearchOption.AllDirectories).Where(name => !name.EndsWith(".wpl"));
            wplfiles.AddRange(files);
            wplfiles = wplfiles.Distinct().ToList();
            foreach (string file in wplfiles)
            {
                SongViewModel song = new SongViewModel();
                song.PathName = file;
                song.SafeName = Path.GetFileNameWithoutExtension(file);
                song.fillMeta();
                mv.LibSongs.Add(song);
                mv.FilterSongs.Add(song);
            }
            runWatcher(appFolder);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
       private void runWatcher(string Path)
        {
            watcher.Path = Path;
            watcher.IncludeSubdirectories = true;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            myPlayer player = MainWindow.getPlayer;
            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                for (int i = 0; i < player.mv.LibSongs.Count(); ++i)
                {
                    if (player.mv.LibSongs[i].PathName == e.FullPath)
                        player.mv.removeFromLib(i);
                }
            }
            else if (e.ChangeType == WatcherChangeTypes.Created)
            {
                for (int i = 0; i < player.mv.LibSongs.Count(); ++i)
                {
                    if (player.mv.LibSongs[i].PathName == e.FullPath)
                        return;
                }
                SongViewModel item = new SongViewModel();
                item.PathName = e.FullPath;
                item.SafeName = Path.GetFileNameWithoutExtension(e.FullPath);
                player.mv.addToLib(item);
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            
        myPlayer player = MainWindow.getPlayer;
        for (int i = 0; i < player.mv.LibSongs.Count(); ++i)
        {
            if (player.mv.LibSongs[i].PathName == e.OldFullPath)
            {
                player.mv.removeFromLib(i);
                SongViewModel item = new SongViewModel();
                item.PathName = e.FullPath;
                item.SafeName = Path.GetFileNameWithoutExtension(e.FullPath);
                player.mv.addToLib(item);
            }
        }

        }
    }
}
