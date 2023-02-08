using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManeHelper
{
    public class ArrayHelper
    {
        public double[][] SortWithSecondObject(double[][] input)
        {
            double[][] nums = input;
            Array.Sort(nums, (x, y) => x[1].CompareTo(y[1]));
            return nums;
        }
    }
}
