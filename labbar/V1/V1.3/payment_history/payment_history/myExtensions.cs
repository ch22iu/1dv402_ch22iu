using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payment_history
{
    public static class myExtensions
    {
        public static int Dispertion(this int[] thisArray)
        {
            return thisArray.Max() - thisArray.Min();
        }
        public static int Median(this int[] thisArray)
        {
            List<int> values = new List<int>(thisArray);
            values.Sort();

            while (values.Count() > 2)
            {
                values.RemoveAt(0);
                values.RemoveAt(values.Count() -1);
            }

            if (values.Count == 2)
            {
                return (int)Math.Round(values.Average());
                
            }
            else
            {
                return values[0];
            }
        }
    }
}
