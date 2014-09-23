using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payment_history
{
    public static class myExtensions
    {
        public static int Dispertion(this int[] source)
        {
            return source.Max() - source.Min();
        }
        public static int Median(this int[] source)
        {
            List<int> values = new List<int>(source);
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
