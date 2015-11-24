using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DownloadData
{
    public class DownloadFromEndpointProvider
    {
        private readonly Dispatcher _dispatcher;

        public DownloadFromEndpointProvider(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public async Task DownloadAndSave(DownloadParameters parameters, CancellationToken cancellationToken, Action<int, bool> progressCallback, Action downloadFailed)
        {
            try
            {
                int bufferSize = 4096;//Same size as a page size, seems a good size?!?
                using (HttpClient client = new HttpClient())
                {
                    var request = await client.GetAsync(parameters.EndpointUrl, cancellationToken);
                    if (request.IsSuccessStatusCode)
                    {
                        using (FileStream fs = parameters.FileName.OpenWrite())
                        using (var q = await request.Content.ReadAsStreamAsync())
                        {
                            await q.CopyToAsync(fs, bufferSize, cancellationToken);
                        }

                        _dispatcher.Invoke(progressCallback, 100, true);
                    }
                    _dispatcher.Invoke(downloadFailed);
                }
            }
            catch (Exception)
            {
                _dispatcher.Invoke(downloadFailed);
            }
        }


    }
}
