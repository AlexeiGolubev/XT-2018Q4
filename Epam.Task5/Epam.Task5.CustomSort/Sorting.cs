using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.CustomSort
{
    public class Sorting
    {
        public static void QuickSort<T>(T[] array, Func<T, T, int> compare)
        {
            if (compare == null)
            {
                throw new NullReferenceException("No compare function.");
            }

            QuickSort(array, 0, array.Length - 1, compare);
        }

        protected static void QuickSort<T>(T[] array, int l, int r, Func<T, T, int> compare)
        {
            if (compare == null)
            {
                throw new NullReferenceException("No compare function.");
            }

            int i = l;
            int j = r;
            T p = array[l + ((r - l) / 2)];

            while (i <= j)
            {
                while (compare(array[i], p) < 0)
                {
                    i++;
                }

                while (compare(array[j], p) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (l < j)
            {
                QuickSort(array, l, j, compare);
            }

            if (i < r)
            {
                QuickSort(array, i, r, compare);
            }
        }
    }
}
