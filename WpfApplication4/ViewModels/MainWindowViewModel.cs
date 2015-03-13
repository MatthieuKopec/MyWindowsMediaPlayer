using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace WpfApplication4.ViewModels
{
    public class MainWindowViewModel : MyViewModel
    {

        private ViewableCollection<SongViewModel> _songs;
        public ViewableCollection<SongViewModel> Songs
        {
            get
            {
                if (_songs == null)
                {
                    _songs = new ViewableCollection<SongViewModel>();
                }
                return _songs;
            }
        }

        private ViewableCollection<SongViewModel> _listsongs;
        public ViewableCollection<SongViewModel> ListSongs
        {
            get
            {
                if (_listsongs == null)
                {
                    _listsongs = new ViewableCollection<SongViewModel>();
                }
                return _listsongs;
            }
        }
        public void removeFromLib(int index)
        {
            Application.Current.Dispatcher.Invoke(
new Action(() => LibSongs.RemoveAt(index))); 
        }
        public void addToLib(SongViewModel index)
        {
            Application.Current.Dispatcher.Invoke(
new Action(() => LibSongs.Add(index)));
        }
        private string _name = "Sans Titre";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public void savePlaylist()
        {
            XElement xe = new XElement("smil");
            xe.Add(
                    new XElement
                    (
                        "header",
                        new XElement(
                            "title",
                            Name
                            )
                    ));

                    xe.Add (new XElement
                    (
                        "sub",
                        ListSongs.Select
                        (
                        x =>
                            new XElement
                            (
                                "media",
                                new XAttribute(
                                    "src",
                                    x.PathName
                                    ),
                                    null
                                   
                            )
                        )
                    )
                    );
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = Name;
                    dlg.DefaultExt = ".wpl";
                    dlg.Filter = "Media Playlist (.wpl)|*.wpl"; 

                    Nullable<bool> result = dlg.ShowDialog();
                    if (result == true)
                    {
                        string filename = dlg.FileName;
                        xe.Save(filename);
                    }
        }

        public void savePlaylist(int code)
        {
            XElement xe = new XElement("smil");
            xe.Add(
                    new XElement
                    (
                        "header",
                        new XElement(
                            "title",
                            Name
                            )
                    ));

            xe.Add(new XElement
            (
                "sub",
                LibSongs.Select
                (
                x =>
                    new XElement
                    (
                        "media",
                        new XAttribute(
                            "src",
                            x.PathName
                            ),
                            null

                    )
                )
            )
            );

            string appFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Music Library");
            string historyFile = Path.Combine(appFolder, "history.wpl");
            xe.Save(historyFile);
        }

        public bool parseWpl()
        {

            string file = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".wpl";
            dlg.Filter = "Media Playlist File (*.wpl)|*.wpl";
            dlg.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Playlists");
            Directory.CreateDirectory(dlg.InitialDirectory);
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
                file = dlg.FileName;
            else
                return false;
            XDocument document = XDocument.Load(file);

            if (document.Root.Name != "smil")
                return false;
            var query = from node in document.Root.Descendants("media")
                        where node.Attribute("src").Value != null
                        select new
                        {
                            MediaItem = new
                            {
                                Src = node.Attribute("src").Value,
                                Name = "x0x0"
                            }
                        };
            var getTitle = from node in document.Root.Descendants("title")
                         where node.Value != null
                         select node.Value;
            if (getTitle.Count() > 0)
                Name = getTitle.ElementAt(0);
            else
                Name = System.IO.Path.GetFileNameWithoutExtension(file);
            ListSongs.Clear();
             foreach (var item in query)
             {
                 SongViewModel song = new SongViewModel();
                 if (System.IO.Path.IsPathRooted(item.MediaItem.Src) == false)
                     song.PathName = Path.Combine(Path.GetDirectoryName(file), item.MediaItem.Src);
                 else
                     song.PathName = item.MediaItem.Src;
                 song.SafeName = System.IO.Path.GetFileNameWithoutExtension(song.PathName);
                 ListSongs.Add(song);
             }
            return (true);
        }

        private ViewableCollection<SongViewModel> _libsongs;
        public ViewableCollection<SongViewModel> LibSongs
        {
            get
            {
                if (_libsongs == null)
                {
                    _libsongs = new ViewableCollection<SongViewModel>();
                }
                return _libsongs;
            }
        }

        public List<string> parseWpl(string file)
        {
            XDocument document = XDocument.Load(file);

            var query = from node in document.Root.Descendants("media")
                        where node.Attribute("src").Value != null
                        select new
                        {
                            MediaItem = new
                            {
                                Src = node.Attribute("src").Value,
                                Name = "x0x0"
                            }
                        };
            var getTitle = from node in document.Root.Descendants("title")
                           where node.Value != null
                           select node.Value;
            if (getTitle.Count() > 0)
                Name = getTitle.ElementAt(0);
            else
                Name = System.IO.Path.GetFileNameWithoutExtension(file);
            LibSongs.Clear();
            List<string> list = new List<string> { };
            foreach (var item in query)
            {
                SongViewModel song = new SongViewModel();
                if (System.IO.Path.IsPathRooted(item.MediaItem.Src) == false)
                    list.Add(Path.Combine(Path.GetDirectoryName(file), item.MediaItem.Src));
                else
                    list.Add(item.MediaItem.Src);
            }
            return (list);
        }

        private ViewableCollection<SongViewModel> _filtersongs;
        public ViewableCollection<SongViewModel> FilterSongs
        {
            get
            {
                if (_filtersongs == null)
                {
                    _filtersongs = new ViewableCollection<SongViewModel>();
                }
                return _filtersongs;
            }
        }

        private string _typeFilter = "";
        public string TypeFilter
        {
            get
            {
                return _typeFilter;
            }
            set
            {
                if (_typeFilter != value)
                {
                    _typeFilter = value;
                    RaisePropertyChanged("TypeFilter");
                    filterUpdate();
                }
            }
        }

        private string _albumFilter = "";
        public string AlbumFilter
        {
            get
            {
                return _albumFilter;
            }
            set
            {
                if (_albumFilter != value)
                {
                    _albumFilter = value;
                    RaisePropertyChanged("AlbumFilter");
                    filterUpdate();
                }
            }
        }

        private string _artistFilter = "";
        public string ArtistFilter
        {
            get
            {
                return _artistFilter;
            }
            set
            {
                if (_artistFilter != value)
                {
                    _artistFilter = value;
                    RaisePropertyChanged("ArtistFilter");
                    filterUpdate();
                }
            }
        }

        private string _genreFilter = "";
        public string GenreFilter
        {
            get
            {
                return _genreFilter;
            }
            set
            {
                if (_genreFilter != value)
                {
                    _genreFilter = value;
                    RaisePropertyChanged("GenreFilter");
                    filterUpdate();
                }
            }
        }

        private string _searchFilter = "";
        public string SearchFilter
        {
            get
            {
                return _searchFilter;
            }
            set
            {
                if (_searchFilter != value)
                {
                    _searchFilter = value;
                    RaisePropertyChanged("SearchFilter");
                    filterUpdate();
                }
            }
        }

        public void filterUpdate()
        {
            bool filtered = false;
            _filtersongs.Clear();
            var items = _filtersongs.Where(x => x.SafeName == "");
            if (_searchFilter != "")
            {
                items = LibSongs.Where(x => x.SafeName.Contains(_searchFilter));
                foreach (SongViewModel item in items)
                    _filtersongs.Add(item);
                filtered = true;
            }

            if (_albumFilter != "")
            {
                if (filtered == false)
                    items = LibSongs.Where(x => x.Album.Contains(_albumFilter));
                else
                {
                    items = _filtersongs.Where(x => x.Album.Contains(_albumFilter));
                    _filtersongs.Clear();
                }
                foreach (SongViewModel item in items)
                    _filtersongs.Add(item);
                filtered = true;
            }

            if (_genreFilter != "" && _genreFilter != "Genre")
            {
                if (filtered == false)
                    items = LibSongs.Where(x => x.Genre.Contains(_genreFilter));
                else
                {
                    items = _filtersongs.Where(x => x.Genre.Contains(_genreFilter));
                    _filtersongs.Clear();
                }
                foreach (SongViewModel item in items)
                    _filtersongs.Add(item);
                filtered = true;
            }

            if (_typeFilter != "")
            {
                if (filtered == false)
                    items = LibSongs.Where(x => x.FileType.Contains(_typeFilter));
                else
                {
                    items = _filtersongs.Where(x => x.FileType.Contains(_typeFilter));
                    _filtersongs.Clear();
                }
                foreach (SongViewModel item in items)
                    _filtersongs.Add(item);
                filtered = true;
            }

            if (_artistFilter != "")
            {
                if (filtered == false)
                    items = LibSongs.Where(x => x.Artist.Contains(_artistFilter));
                else
                {
                    items = _filtersongs.Where(x => x.Artist.Contains(_artistFilter));
                    _filtersongs.Clear();
                }
                foreach (SongViewModel item in items)
                    _filtersongs.Add(item);
                filtered = true;
            }
            if (filtered == false)
            {
                foreach (SongViewModel item in LibSongs)
                    _filtersongs.Add(item);
            }
        }
        

    }
}
