using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace DownloadData
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }


        private void TextBoxSaveToLocation_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            TextBoxSaveToLocation.Text = dialog.SelectedPath;
        }




        private void ButtonDownLoad_OnClick(object sender, RoutedEventArgs e)
        {
            this.Switch(new DownloadingUserControl("hi"));
        }
    }
}
