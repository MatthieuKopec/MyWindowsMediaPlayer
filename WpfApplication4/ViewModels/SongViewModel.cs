using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication4.ViewModels
{
    public class SongViewModel : MyViewModel
    {
        private string _pathName = "New";
        /// <summary>
        /// This property stores the contact's first name.
        /// </summary>
        public string PathName
        {
            get
            {
                return _pathName;
            }
            set
            {
                if (_pathName != value)
                {
                    _pathName = value;
                    RaisePropertyChanged("PathName");
                }
            }
        }

        private string _safeName = "SafeName";
        public string SafeName
        {
            get
            {
                    return _safeName;
            }
            set
            {
                if (_safeName != value)
                {
                    _safeName = value;
                    RaisePropertyChanged("SafeName");
                }
            }
        }

        private string _title = "Unknown";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                    RaisePropertyChanged("SafeName");
                    RaisePropertyChanged("Meta");
                }
            }
        }

        private string _album = "Unknown";
        public string Album
        {
            get
            {
                return _album;
            }
            set
            {
                if (_album != value)
                {
                    _album = value;
                    RaisePropertyChanged("Album");
                    RaisePropertyChanged("SafeName");
                    RaisePropertyChanged("Meta");
                }
            }
        }

        private string _genre = "Unknown";
        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                if (_genre != value)
                {
                    _genre = value;
                    RaisePropertyChanged("Genre");
                    RaisePropertyChanged("Meta");
                }
            }
        }

        private string _artist = "Unknown";
        public string Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                if (_artist != value)
                {
                    _artist = value;
                    RaisePropertyChanged("Artist");
                    RaisePropertyChanged("SafeName");
                    RaisePropertyChanged("Meta");
                }
            }
        }

        private string _meta = "Unknown";
        public string Meta
        {
            get
            {
                return ("Titre : " + _title + " - Artist : " + _artist + " - Album : " + _album + " - Genre : " + _genre);
            }
            set
            {
                if (_genre != value)
                {
                    _genre = value;
                }
            }
        }

        private string _filetype = "?";
        public string FileType
        {
            get
            {
                return _filetype;
            }
            set
            {
                if (_filetype != value)
                {
                    _filetype = value;
                    RaisePropertyChanged("FileType");
                }
            }
        } 
        public void fillMeta()
        {
            try
            {
                TagLib.File file = TagLib.File.Create(PathName);
                Album = file.Tag.Album;
                if (Album == null)
                    Album = "Unknown";
                Title = file.Tag.Title;
                if (Album == null)
                    Album = "Unknown";
                Genre = file.Tag.Genres[0];
                if (Album == null)
                    Album = "Unknown";
                Artist = file.Tag.Performers[0];
                if (Artist == null)
                    Artist = "Unknown";
            }
            catch
            {
                Album = "unknown";
                Title = "unknown";
                Genre = "unknown";
                Artist = "unknown";
            }
        }

        /// <summary>
        /// Returns a System.String representing this contact.
        /// </summary>
        /// <returns>A string formatted to have Last Name, First Name.</returns>
        public override string ToString()
        {
            return _safeName;
        }
    }
}
