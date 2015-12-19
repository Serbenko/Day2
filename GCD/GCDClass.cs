using System;
using System.Diagnostics;

namespace GCD
{
    public static class GCDClass
    {
        private delegate long GCDAlgorithm(long a, long b);

        #region EuclideanAlgorithm


        public static long GetGCDEuclideanAlgorithm(out long time, long a, long b)
        {
            return GetGCD(out time, a, b, GetGCDEuclidean);
        }

        public static long GetGCDEuclideanAlgorithm(out long time, long a, long b, long c)
        {
            return GetGCD(out time, a, b, c, GetGCDEuclidean);
        }

        public static long GetGCDEuclideanAlgorithm(out long time, params long[] array)
        {
            return GetGCD(out time, GetGCDEuclidean, array);
        }
        #endregion

        #region BinaryAlgorithm

        public static long GetGCDBinaryAlgorithm(out long time, long a, long b)
        {
            return GetGCD(out time, a, b, GetGCDBinary);
        }

        public static long GetGCDBinaryAlgorithm(out long time, long a, long b, long c)
        {
            return GetGCD(out time, a, b, c, GetGCDBinary);
        }

        public static long GetGCDBinaryAlgorithm(out long time, params long[] array)
        {
            return GetGCD(out time, GetGCDBinary, array);
        }
        #endregion

        #region Private Methods

        private static long GetGCDEuclidean(long a, long b)
        {
            while (b != 0)
                b = a % (a = b);
            return Math.Abs(a);
        }

        private static long GetGCDBinary(long a, long b)
        {
            if (a == 0)
            {
                return Math.Abs(b);
            }
            if (b == 0)
            {
                return Math.Abs(a);
            }
            if (a == b)
            {
                return Math.Abs(b);
            }
            if ((a % 2 == 0) && (b % 2 == 0))
            {
                return 2 * GetGCDBinary(a / 2, b / 2);
            }
            if ((a % 2 == 0) && (b % 2 != 0))
            {
                return GetGCDBinary(a / 2, b);
            }

            if ((a % 2 != 0) && (b % 2 == 0))
            {
                return GetGCDBinary(a, b / 2);
            }
            return GetGCDBinary(b, Math.Abs(a - b));
        }


        private static long GetGCD(out long time, long a, long b, GCDAlgorithm algorithm)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long gcd = algorithm(a, b);
            watch.Stop();
            time = watch.ElapsedTicks;
            return gcd;
        }

        private static long GetGCD(out long time, long a, long b, long c, GCDAlgorithm algorithm)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long gcd = algorithm(algorithm(a, b), c);
            watch.Stop();
            time = watch.ElapsedTicks;
            return gcd;
        }

        private static long GetGCD(out long time, GCDAlgorithm algorithm, params long[] array)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long a = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                a = algorithm(a, array[i]);
            }
            watch.Stop();
            time = watch.ElapsedTicks;
            return a;
        }

        #endregion
    }
}
