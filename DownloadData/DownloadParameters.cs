using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DownloadData
{
    public class DownloadParameters : INotifyPropertyChanged
    {
        private string _endPoint;
        private string _saveLocation;

        public Uri EndpointUrl => BuildUri();

        private Uri BuildUri()
        {
            var uriBuilder = new UriBuilder(EndPoint.Trim());
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["startdate"] = $"{StartDate:yyyyMMdd}";
            query["enddate"] = $"{EndDate:yyyyMMdd}";
            uriBuilder.Query = query.ToString();
            return uriBuilder.Uri;
            
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string SaveLocation
        {
            get { return _saveLocation; }
            set
            {
                _saveLocation = value;
                this.OnPropertyChanged("SaveLocation");
            }
        }

        public FileInfo FileName => new FileInfo(Path.Combine(SaveLocation, $"{EndpointUrl.Host}-{StartDate:yyyyMMdd}-{EndDate:yyyyMMdd}.json"));

        public String EndPoint
        {
            get { return _endPoint; }
            set
            {
                _endPoint = value;
                this.OnPropertyChanged("EndPoint");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
