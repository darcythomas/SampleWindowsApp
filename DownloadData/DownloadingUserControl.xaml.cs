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

namespace DownloadData
{
    /// <summary>
    /// Interaction logic for DownloadingUserControl.xaml
    /// </summary>
    public partial class DownloadingUserControl : UserControl
    {
        public DownloadingUserControl()
        {
            InitializeComponent();
        }

        public DownloadingUserControl(String labelContent)
        {
            InitializeComponent();
            labelx.Content = labelContent;
            
        }

       
    }
}
