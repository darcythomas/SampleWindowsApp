using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DownloadData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            var datacontext = new DownloadParameters
            {
                SaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                EndPoint = "http://musicbrainz.org/ws/2/artist/5b11f4ce-a62d-471e-81fc-a69a8278c7da?inc=aliases&fmt=json",
                StartDate = DateTime.Today.AddDays(-1),
                EndDate = DateTime.Today
            };




            DataContext = datacontext;


            HomePage initalPage = new HomePage();
            this.Content = initalPage;
        }

     
    }
}
