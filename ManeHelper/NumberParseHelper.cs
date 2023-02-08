using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManeHelper
{
    public static class NumberParseHelper
    {
        // u  n  conveter .
        public static double Decode(string input_number)
        {
            try { return double.Parse(input_number); } catch { };
            try
            {
                input_number = input_number.Trim();
                string begin = input_number.Substring(0,input_number.Length -1);
                string finalChar = input_number.Substring(input_number.Length - 1,1);
                switch (finalChar)
                {
                    case "u":
                        {
                            return double.Parse(begin)*Math.Pow(10,-6);
                        } break;

                    case "n":
                        {
                            return double.Parse(begin)*Math.Pow(10,-9);
                        } break;

                    case "m":
                        {
                            return double.Parse(begin) * Math.Pow(10, -3);
                        }
                        break;

                    case "p":
                        {
                            return double.Parse(begin) * Math.Pow(10, -12);
                        }
                        break;

                    case "f":
                        {
                            return double.Parse(begin) * Math.Pow(10, -15);
                        }
                        break;

                    case "G":
                        {
                            return double.Parse(begin) * Math.Pow(10, 9);
                        }
                        break;

                    case "M":
                        {
                            return double.Parse(begin) * Math.Pow(10, 6);
                        }
                        break;

                }
                return 0.0;
            }
            catch
            {
                return 0.0;
            }
        }
        public static string EncodeWith(double input_number,string d)
        {
            switch (d)
            {
                case "u":
                    {
                        return (input_number*Math.Pow(10,6)).ToString() + "u";
                    } break;
                case "n":
                    {
                        return (input_number*Math.Pow(10,9)).ToString() + "n";
                    } break;
            }

            return input_number.ToString();
        }

        public static string Encode(double input_number)
        {
            if (input_number <= Math.Pow(10, -6))
            {
                return EncodeWith(input_number,"n");
            }

            if (input_number <= Math.Pow(10, -3))
            {
                return EncodeWith(input_number, "u");
            }

            return input_number.ToString();
        }


    }
}
