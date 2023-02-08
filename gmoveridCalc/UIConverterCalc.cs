using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmoveridCalc
{
    public class UIConverterCalc : INotifyPropertyChanged
    {

		private double inputNumber;

		public double InputNumber
		{
			get { return inputNumber; }
			set { inputNumber = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumber"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberString"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberStringu"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberStringn"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberStringm"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberStringMH"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberStringGH"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberStringmF"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberStringuF"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberStringpF"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberStringnF"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputNumberStringfF"));
			}
		}


		// for UI
		public string InputNumberString
		{
			get { return "Input Number = " + inputNumber.ToString(); }
		}

		public string InputNumberStringu
		{
			get { return (inputNumber/Math.Pow(10,-6)).ToString() + "u"; }
		}

		public string InputNumberStringn
		{
			get { return (inputNumber/Math.Pow(10,-9)).ToString() + "n"; }
		}

		public string InputNumberStringm
		{
			get { return (inputNumber/Math.Pow(10,-3)).ToString() + "m"; }
		}

        public string InputNumberStringMH
        {
            get { return (inputNumber / Math.Pow(10, 6)).ToString() + "M"; }
        }

        public string InputNumberStringGH
        {
            get { return (inputNumber / Math.Pow(10, 9)).ToString() + "G"; }
        }

		// Cap
        public string InputNumberStringmF
        {
            get { return (inputNumber / Math.Pow(10, -3)).ToString() + "m"; }
        }

        public string InputNumberStringuF
        {
            get { return (inputNumber / Math.Pow(10, -6)).ToString() + "u"; }
        }

        public string InputNumberStringnF
        {
            get { return (inputNumber / Math.Pow(10, -9)).ToString() + "n"; }
        }

        public string InputNumberStringpF
        {
            get { return (inputNumber / Math.Pow(10, -12)).ToString() + "p"; }
        }

        public string InputNumberStringfF
        {
            get { return (inputNumber / Math.Pow(10, -15)).ToString() + "f"; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
