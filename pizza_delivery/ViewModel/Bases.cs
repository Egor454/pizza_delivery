using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizza_delivery.View;

namespace pizza_delivery.ViewModel
{
    public class Bases: INotifyPropertyChanged
    {
        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value;
                var win = new Messeg(this);
                win.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                win.Show();
                Thread.Sleep(1500);
                win.Close();OnPropertyChanged("DisplayName");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName )
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
