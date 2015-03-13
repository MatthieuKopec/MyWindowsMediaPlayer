using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;
using WpfApplication4.ViewModels;

namespace WpfApplication4
{
    public class ViewableCollection<T> : ObservableCollection<T>
    {
        private ListCollectionView _view;
        /// <summary>
        /// A bindable view of this Observable Collection (of T) that supports filtering, sorting, and grouping.
        /// </summary>
        ///
        public ListCollectionView View
        {
            get
            {
                if (_view == null)
                {
                    _view = new ListCollectionView(this);
                }
                return _view;
            }
        }
    }
}
