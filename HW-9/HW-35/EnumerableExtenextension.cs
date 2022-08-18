using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_35
{
    public static class EnumerableExtenextension
    {
        public static IEnumerable<T> Top<T>(this IEnumerable<T> a, double percent)
        {
            try
            {
                if (percent < 1 || percent > 100)
                {
                    throw new ArgumentException();
                    return null;
                }

                a = a.OrderByDescending(x => x).Take((int)Math.Ceiling(a.Count() * percent / 100));
                return a;
            }
            catch (ArgumentException ArgEx) { Console.WriteLine(ArgEx.Message); }
            return a;
        }
        public static IEnumerable<T> Top<T>(this IEnumerable<T> a, double percent, deleg<T> del)
        {
            try
            {
                if (percent < 1 || percent > 100)
                {
                    throw new ArgumentException();
                    return null;
                }

                return a.OrderBy(x => del).OrderByDescending(x => x).Take((int)Math.Ceiling(a.Count() * percent / 100));
            }
            catch (ArgumentException ArgEx) { Console.WriteLine(ArgEx.Message); }
            return a;
        }

        public delegate int deleg<T>(T delegArg);
    }
}
