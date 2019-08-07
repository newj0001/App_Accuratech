using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MenuModel : INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                    _id = value;
                RaisePropertyChanged("Id");
                RaisePropertyChanged("MenuItem");
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                if(_title != value)
                _title = value;
                RaisePropertyChanged("Title");
                RaisePropertyChanged("MenuItem");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if(_description != value)
                _description = value;
                RaisePropertyChanged("Description");
                RaisePropertyChanged("MenuItem");
            }
        }

        public string MenuItem
        {
            get {
                return _title + " " + _description;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
