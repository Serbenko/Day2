using System;
using System.Diagnostics;

namespace GCD
{
    public static class GCDClass
    {
        #region EuclideanAlgorithm
        public static int GetGCDEuclideanAlgorithm(int a, int b, Stopwatch watch)
        {
            if (a == Int32.MinValue && b == Int32.MinValue)
                throw new OverflowException("Numbers should be less then " + Int32.MinValue);
            watch.Start();
            while (b != 0)
                b = a % (a = b);
            watch.Stop();
            return Math.Abs(a);
        }

        public static int GetGCDEuclideanAlgorithm(int a, int b, int c, Stopwatch watch)
        {
            watch.Start();
            return GetGCDEuclideanAlgorithm(GetGCDEuclideanAlgorithm(a, b, watch), c, watch);
        }

        public static int GetGCDEuclideanAlgorithm(Stopwatch watch, params int[] array)
        {
            watch.Start();
            int a = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                a = GetGCDEuclideanAlgorithm(a, array[i], watch);
            }
            return a;
        }
        #endregion

        #region BinaryAlgorithm
        //public static int GetGCDBinaryAlgorithm(int a, int b, ref long time)
        //{
        //    Stopwatch watch = new Stopwatch();
        //    watch.Start();
        //    if (a == b)
        //    {
        //        watch.Stop();
        //        time += watch.ElapsedMilliseconds;
        //        return a;
        //    }
        //    a = Math.Abs(a);
        //    b = Math.Abs(b);
        //    if (a == 0)
        //    {
        //        watch.Stop();
        //        time += watch.ElapsedMilliseconds;
        //        return b;
        //    }
        //    if (b == 0)
        //    {
        //        watch.Stop();
        //        time += watch.ElapsedMilliseconds;
        //        return a;
        //    }
        //    if ((~a & 1) != 0)
        //    {
        //        if ((b & 1) != 0)
        //        {
        //            watch.Stop();
        //            time += watch.ElapsedMilliseconds;
        //            return GetGCDBinaryAlgorithm(a >> 1, b, ref time);
        //        }
        //        else
        //        {
        //            watch.Stop();
        //            time += watch.ElapsedMilliseconds;
        //            return GetGCDBinaryAlgorithm(a >> 1, b >> 1, ref time) << 1;
        //        }
        //    }
        //    if ((~b & 1) != 0)
        //    {
        //        watch.Stop();
        //        time += watch.ElapsedMilliseconds;
        //        return GetGCDBinaryAlgorithm(a, b >> 1, ref time);
        //    }
        //    if (a > b)
        //    {
        //        watch.Stop();
        //        time += watch.ElapsedMilliseconds;
        //        return GetGCDBinaryAlgorithm((a - b) >> 1, b, ref time);
        //    }
        //    return GetGCDBinaryAlgorithm((b - a) >> 1, a, ref time);
        //}

        public static int GetGCDBinaryAlgorithm(int a, int b, Stopwatch watch)
        {
            if (((a == Int32.MinValue || b == Int32.MinValue) && (a == 0 || b == 0)) || (a == Int32.MinValue && b == Int32.MinValue))
                throw new OverflowException("Numbers should be less then " + Int32.MinValue);
            watch.Start();
            if (a == 0)
            {
                watch.Stop();
                return Math.Abs(b);
            }
            if (b == 0)
            {
                watch.Stop();
                return Math.Abs(a);
            }
            if (a == b)
            {
                watch.Stop();
                return Math.Abs(b);
            }
            if ((a % 2 == 0) && (b % 2 == 0))
            {
                return 2 * GetGCDBinaryAlgorithm(a / 2, b / 2, watch);
            }
            if ((a % 2 == 0) && (b % 2 != 0))
            {
                return GetGCDBinaryAlgorithm(a / 2, b, watch);
            }

            if ((a % 2 != 0) && (b % 2 == 0))
            {
                return GetGCDBinaryAlgorithm(a, b / 2, watch);
            }
            return GetGCDBinaryAlgorithm(b, Math.Abs(a - b), watch);
        }

        public static int GetGCDBinaryAlgorithm(int a, int b, int c, Stopwatch watch)
        {
            watch.Start();
            return GetGCDBinaryAlgorithm(GetGCDBinaryAlgorithm(a, b, watch), c, watch);
        }

        public static int GetGCDBinaryAlgorithm(Stopwatch watch, params int[] array)
        {
            watch.Start();
            int a = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                a = GetGCDBinaryAlgorithm(a, array[i], watch);
            }
            return a;
        }
        #endregion
    }
}
