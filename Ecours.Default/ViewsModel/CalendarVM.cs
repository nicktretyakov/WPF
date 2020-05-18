using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Default.ViewModel
{
    public enum Tenor {
        Day, 
        Week
    }

    public class CalendarVM: BindableBase
    {
        Tenor tenor = Tenor.Day;

        public Tenor Tenor
        {
            get { return tenor; }
            set
            {
                if (tenor == value)
                    return;

                tenor = value;
               
                RaisePropertyChanged("Tenor");
                RaisePropertyChanged("IsDay");
                RaisePropertyChanged("IsWeek");
                RaisePropertyChanged("GetResult");
            }
        }

        public bool IsDay
        {
            get { return Tenor == Tenor.Day; }
            set { Tenor = value ? Tenor.Day : Tenor; }
        }

        public bool IsWeek
        {
            get { return Tenor == Tenor.Week; }
            set { Tenor = value ? Tenor.Week : Tenor; }
        }

        public string GetResult
        {
            get
            {
                switch (Tenor)
                {
                    case Tenor.Day:
                        return System.DateTime.Now.ToLongDateString();
                    case Tenor.Week:                        
                        return  String.Format("{0} - {1}", System.DateTime.Now.Day - 1, System.DateTime.Now.AddDays(5).ToLongDateString());                                                   
                }
                return "";
            }
        }

    }
}
