using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.NumberArraySum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            byte[] byteArray = { 1, 2, 3 };
            sbyte[] sbyteArray = { 1, 2, 3 };
            short[] shortArray = { 1, 2, 3 };
            ushort[] ushortArray = { 1, 2, 3 };
            int[] intArray = { 1, 2, 3 };
            uint[] uintArray = { 1, 2, 3 };
            long[] longArray = { 1, 2, 3 };
            ulong[] ulongArray = { 1, 2, 3 };
            float[] floatArray = { 1, 2, 3 };
            double[] doubleArray = { 1, 2, 3 };
            decimal[] decimalArray = { 1, 2, 3 };

            Console.Write($"{byteArray.GetType().Name} = ");
            foreach (var item in byteArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {byteArray.GetType().Name} = {byteArray.ArraySum()}");
            Console.WriteLine();

            Console.Write($"{sbyteArray.GetType().Name} = ");
            foreach (var item in sbyteArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {sbyteArray.GetType().Name} = {sbyteArray.ArraySum()}");
            Console.WriteLine();

            Console.Write($"{shortArray.GetType().Name} = ");
            foreach (var item in shortArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {shortArray.GetType().Name} = {shortArray.ArraySum()}");
            Console.WriteLine();

            Console.Write($"{ushortArray.GetType().Name} = ");
            foreach (var item in ushortArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {ushortArray.GetType().Name} = {ushortArray.ArraySum()}");
            Console.WriteLine();

            Console.Write($"{intArray.GetType().Name} = ");
            foreach (var item in intArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {intArray.GetType().Name} = {intArray.ArraySum()}");
            Console.WriteLine();

            Console.Write($"{uintArray.GetType().Name} = ");
            foreach (var item in uintArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {uintArray.GetType().Name} = {uintArray.ArraySum()}");
            Console.WriteLine();

            Console.Write($"{longArray.GetType().Name} = ");
            foreach (var item in longArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {longArray.GetType().Name} = {longArray.ArraySum()}");
            Console.WriteLine();

            Console.Write($"{ulongArray.GetType().Name} = ");
            foreach (var item in ulongArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {ulongArray.GetType().Name} = {ulongArray.ArraySum()}");
            Console.WriteLine();

            Console.Write($"{floatArray.GetType().Name} = ");
            foreach (var item in floatArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {floatArray.GetType().Name} = {floatArray.ArraySum()}");
            Console.WriteLine();

            Console.Write($"{doubleArray.GetType().Name} = ");
            foreach (var item in doubleArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {doubleArray.GetType().Name} = {doubleArray.ArraySum()}");
            Console.WriteLine();

            Console.Write($"{decimalArray.GetType().Name} = ");
            foreach (var item in decimalArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Sum {decimalArray.GetType().Name} = {decimalArray.ArraySum()}");
            Console.WriteLine();
        }
    }
}
