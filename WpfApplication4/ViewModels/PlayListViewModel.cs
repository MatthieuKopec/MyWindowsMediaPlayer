using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication4.ViewModels;

namespace WpfApplication4
{
    class PlayListViewModel : MyViewModel
    {
        public ViewableCollection<SongViewModel> listsongs = new ViewableCollection<SongViewModel>();
    }
}
