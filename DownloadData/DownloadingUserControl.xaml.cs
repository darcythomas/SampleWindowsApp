using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private readonly DownloadParameters _downloadParameters;
        private readonly DownloadFromEndpointProvider _downloader;
        readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();


        //public DownloadingUserControl()
        //{
        //    _downloader = new DownloadFromEndpointProvider(Dispatcher);

        //    InitializeComponent();

        //    _downloadParameters = (DownloadParameters)DataContext;
        //    StartDownload();
        //}

        public DownloadingUserControl(DownloadParameters downloadParameters)
        {
            _downloader = new DownloadFromEndpointProvider(this.Dispatcher);
            _downloadParameters = downloadParameters;

            InitializeComponent();
            StartDownload(downloadParameters);
        }

        private void StartDownload(DownloadParameters downloadParameters)
        {
            Task.Run(() => _downloader.DownloadAndSave(_downloadParameters, _cancellationTokenSource.Token, Progress, DownloadFailed));
        }





        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource.Cancel();
            this.SwitchTo(new HomePage());
        }

        public void Progress(int percentDone, bool completed)
        {
            ProgressBarDownload.IsIndeterminate = false;
            if (completed)
            {
                ProgressBarDownload.Value = 100;
                Done();
            }

            ProgressBarDownload.Value = percentDone;
        }

        public void Done()
        {
            this.SwitchTo(new CompletedDownload());
        }
        public void DownloadFailed()
        {
            this.SwitchTo(new ErrorDownloading());
        }
    }
}
