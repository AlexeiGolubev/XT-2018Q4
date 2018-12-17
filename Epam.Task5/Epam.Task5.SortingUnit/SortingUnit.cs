using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Epam.Task5.CustomSort;

namespace Epam.Task5.SortingUnit
{
    public class SortingUnit<T>
    {
        private readonly object lockOn = new object();

        public delegate void SortingHandler(string message);

        public event SortingHandler EndOfSorting;

        public Thread SortingUnitThread { get; private set; }

        public void QuickSort(T[] array, Func<T, T, int> compare)
        {
            if (compare == null)
            {
                throw new NullReferenceException("No compare function.");
            }

            lock (this.lockOn)
            {
                Sorting.QuickSort(array, compare);
                this.EndOfSorting?.Invoke(Thread.CurrentThread.Name);
            }
        }

        public void RunSortInNewThread(T[] array, Func<T, T, int> compare, string threadName)
        {
            if (compare == null)
            {
                throw new NullReferenceException("No compare function.");
            }

            this.SortingUnitThread = new Thread(() => this.QuickSort(array, compare));
            this.SortingUnitThread.Start();
            this.SortingUnitThread.Name = threadName;
        }
    }
}
