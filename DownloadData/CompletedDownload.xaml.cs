using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for CompletedDownload.xaml
    /// </summary>
    public partial class CompletedDownload : UserControl
    {
        private DownloadParameters _downloadedParameters => (DownloadParameters) DataContext;

        public CompletedDownload()
        {
            InitializeComponent();
        }


        private void LabelLinkToFile_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Process.Start("explorer", $"/select, {_downloadedParameters.FileName.FullName}" );
        }

        private void ButtonDone_OnClick(object sender, RoutedEventArgs e)
        {
           this.SwitchTo(new HomePage());
        }
    }
}
