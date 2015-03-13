using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication4
{
    interface IDialogService
    {
        bool GetOpenFileDialog(string title, string filter);
        string GetSaveFileDialog(string title, string filter);
    }
}
