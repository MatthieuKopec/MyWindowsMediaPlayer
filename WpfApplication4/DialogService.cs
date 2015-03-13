using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApplication4
{
    class DialogService : IDialogService
    {
        public String PathName { get; set; }
        public String SafeName{ get; set; }

        public bool GetOpenFileDialog(string title, string filter)
        {
            var dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.Multiselect = false;
            dialog.Title = title;
            dialog.Filter = filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PathName = dialog.FileName;
                SafeName = dialog.SafeFileName;
                return true;
            }
            return false;
        }

        public string GetSaveFileDialog(string title, string filter)
        {
            var dialog = new SaveFileDialog();
            dialog.Title = title;
            dialog.Filter = filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return "";
        }
    }
}
