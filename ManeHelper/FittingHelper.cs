using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManeHelper
{
    public class FittingHelper
    {
        public bool CanPredict = false;

        private double[] rawdata_x;

        private double[] rawdata_y;

        private double[] Poli_XToY { get; set; }
        private double[] Poli_YToX { get; set; }

        public void Fit(double[] x, double[] y,int prediction_count)
        {
            rawdata_x = x;
            rawdata_y = y;
            Poli_XToY = MathNet.Numerics.Fit.Polynomial(x,y, prediction_count);
            Poli_YToX = MathNet.Numerics.Fit.Polynomial(y,x, prediction_count);
            CanPredict = true;
        }

        public double PredictY(double x)
        {
            double result = 0.0;
            for (int i = 0; i < Poli_XToY.Count(); i++)
            {
                result += Poli_XToY[i] * Math.Pow(x, i);
            }
            return result;
        }


        public double[] PredictArrayY(double[] x)
        {
            double[] return_array = new double[x.Length];
            for (int index = 0;index<x.Length;index ++)
            {
                return_array[index] = PredictY(x[index]);
            }
            return return_array;
        }


        public double PredictX(double y)
        {
            double result = 0.0;
            for (int i = 0; i < Poli_YToX.Count(); i++)
            {
                result += Poli_YToX[i] * Math.Pow(y, i);
            }
            return result;
        }

        public double[] GetRawDataX()
        {
            return rawdata_x;
        }

        public double[] GetRawDataY()
        {
            return rawdata_y;
        }


        public string CheckErrorXYPercentage()
        {
            if (CanPredict)
            {
                double avg_error = 0.0;
                int Total = rawdata_x.Length;
                for (int index = 0;index < rawdata_x.Length; index++)
                {
                    double real_y = rawdata_y[index];
                    double pre_y =  PredictY(rawdata_x[index]);
                    double error = Math.Abs((real_y - pre_y) / real_y) / Total;
                    avg_error += error;
                }
                return (Math.Round(avg_error,6)*100).ToString() + "%";
            }
            return "No data";
        } 

        public bool CheckOk()
        {
            foreach(double x in Poli_XToY)
            {
                if (Double.IsNaN(x))
                {
                    return false;
                }
            }

            foreach (double x in Poli_YToX)
            {
                if (Double.IsNaN(x))
                {
                    return false;
                }
            }

            return true;
        }
        public bool CheckOkXToYOnly()
        {
            foreach (double x in Poli_XToY)
            {
                if (Double.IsNaN(x))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
