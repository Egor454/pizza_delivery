using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizza_delivery.Model;
namespace pizza_delivery.ViewModel
{
    public class Statistica:Bases
    {
        ReportModel report;

        private List<ReportData> data;
        public List<ReportData> Data
        {
            get { return data; }
            set { data = value; OnPropertyChanged("Data"); }
        }

      public  Statistica()
      {

            report = new ReportModel();
      }
        private decimal setnumber;
        private DateTime date_Start=DateTime.Now;
        private DateTime date_End=DateTime.Now.AddMonths(1);

        public decimal Setnumber
        {
            get { return setnumber; }
            set { setnumber = value; OnPropertyChanged("Setnumber"); }
        }
        public DateTime Date_Start
        {
            get { return date_Start; }
            set { date_Start = value; OnPropertyChanged("Date_Start"); }
        }
        public DateTime Date_End
        {
            get { return date_End; }
            set { date_End = value; OnPropertyChanged("Date_End"); }
        }
        private RelayCommand watch;
        public RelayCommand Wath
        {
            get
            {
                return watch ??
                  (watch = new RelayCommand(obj =>
                  {
                      Data = report.Otchet(date_Start, date_End, setnumber);
                  },
                  (obj) => (date_End> date_Start)));

            }
        }
    }
}
