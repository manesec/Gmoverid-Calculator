using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmoveridCalc
{
    public class UIMessage : INotifyPropertyChanged
    {
        private string process_bar_message;

        public string Process_bar_message
        {
            get { return process_bar_message; }
            set { process_bar_message = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Process_bar_message"));
            }
        }

        private int process_bar_value;

        public int Process_bar_value
        {
            get { return process_bar_value; }
            set { process_bar_value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Process_bar_value"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


}
