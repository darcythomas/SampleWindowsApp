using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DownloadData
{
    public static class Switcher
    {
        public static void SwitchTo(this UserControl currentPage, UserControl nextPage)
        {
            Window parentWindow = Window.GetWindow(currentPage);
            parentWindow.Content = nextPage;
        }
    }
}
