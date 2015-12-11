using System;
using System.Diagnostics;

namespace GCD
{
    public static class GCDClass
    {
        #region EuclideanAlgorithm
        private static long GetGCDEuclidean (long a, long b)
        {
            while (b != 0)
                b = a % (a = b);
            return Math.Abs(a);
        }

        public static long GetGCDEuclideanAlgorithm(out long time, long a, long b)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long gcd = GetGCDEuclidean(a, b);
            watch.Stop();
            time = watch.ElapsedTicks;
            return gcd;
        }

        public static long GetGCDEuclideanAlgorithm(out long time, long a, long b, long c)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long gcd = GetGCDEuclidean(GetGCDEuclidean(a, b), c);
            watch.Stop();
            time = watch.ElapsedTicks;
            return gcd;
        }

        public static long GetGCDEuclideanAlgorithm(out long time, params long[] array)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long a = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                a = GetGCDEuclidean(a, array[i]);
            }
            watch.Stop();
            time = watch.ElapsedTicks;
            return a;
        }
        #endregion

        #region BinaryAlgorithm
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

        public static long GetGCDBinaryAlgorithm(out long time, long a, long b)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long gcd = GetGCDBinary(a, b);
            watch.Stop();
            time = watch.ElapsedTicks;
            return gcd;
        }

        public static long GetGCDBinaryAlgorithm(out long time, long a, long b, long c)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long gcd = GetGCDBinary(GetGCDBinary(a, b), c);
            watch.Stop();
            time = watch.ElapsedTicks;
            return gcd;
        }

        public static long GetGCDBinaryAlgorithm(out long time, params long[] array)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long a = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                a = GetGCDBinary(a, array[i]);
            }
            watch.Stop();
            time = watch.ElapsedTicks;
            return a;
        }
        #endregion
    }
}
