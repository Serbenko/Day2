using System;
using System.Collections;
using NUnit.Framework;
using System.Diagnostics;
using GCD;

namespace GCDAlgorithmTest
{
    [TestFixture]
    public class GCDAlgorithmClassTest
    {
        #region EuclideanAlgorithmTests

        [Test]
        [TestCaseSource(typeof(DataClassAlgorithmTwoArgs), "PositiveData")]
        [TestCaseSource(typeof(DataClassAlgorithmTwoArgs), "SpecialCasesData")]
        public long GetGCDEuclideanAlgorithmTest(out long time, long a, long b)
        {
            long gcd = GCDClass.GetGCDEuclideanAlgorithm(out time, a, b);
            Debug.Write(time);
            return gcd;
        }

        [Test]
        [TestCaseSource(typeof(DataClassAlgorithmThreeArgs), "PositiveData")]
        [TestCaseSource(typeof(DataClassAlgorithmThreeArgs), "SpecialCasesData")]
        public long GetGCDEuclideanAlgorithmTest(out long time, long a, long b, long c)
        {
            long gcd = GCDClass.GetGCDEuclideanAlgorithm(out time, a, b,c);
            Debug.Write(time);
            return gcd;
        }

        [Test]
        [TestCaseSource(typeof(DataClassAlgorithm), "PositiveData")]
        public long GetGCDEuclideanAlgorithmTest(out long time, params long[] array)
        {
            long gcd = GCDClass.GetGCDEuclideanAlgorithm(out time, array);
            Debug.Write(time);
            return gcd;
        }
        #endregion

        #region BinaryAlgorithmTests
        [Test]
        [TestCaseSource(typeof(DataClassAlgorithmTwoArgs), "PositiveData")]
        [TestCaseSource(typeof(DataClassAlgorithmTwoArgs), "SpecialCasesData")]
        public long GetGCDBinaryAlgorithmTest(out long time, long a, long b)
        {
            long gcd = GCDClass.GetGCDBinaryAlgorithm(out time, a, b);
            Debug.WriteLine(time);
            return gcd;
        }

        [Test]
        [TestCaseSource(typeof(DataClassAlgorithmThreeArgs), "PositiveData")]
        [TestCaseSource(typeof(DataClassAlgorithmThreeArgs), "SpecialCasesData")]
        public long GetGCDBinaryAlgorithmTest(out long time, long a, long b, long c)
        {
            long gcd = GCDClass.GetGCDBinaryAlgorithm(out time, a, b, c);
            Debug.WriteLine(time);
            return gcd;
        }

        [Test]
        [TestCaseSource(typeof(DataClassAlgorithm), "PositiveData")]
        public long GetGCDBinaryAlgorithmTest(out long time, params long[] array)
        {
            long gcd = GCDClass.GetGCDBinaryAlgorithm(out time, array);
            Debug.WriteLine(time);
            return gcd;
        }
        #endregion

        #region DataClasses
        public class DataClassAlgorithmTwoArgs
        {
            public static IEnumerable PositiveData
            {
                get
                {
                    yield return new TestCaseData(0L, 18L, 9L).Returns(9L);
                    yield return new TestCaseData(0L, -10L, 470L).Returns(10L);
                    yield return new TestCaseData(0L, 45L, -39L).Returns(3L);
                    yield return new TestCaseData(0L, 0L, 15L).Returns(15L);
                    yield return new TestCaseData(0L, 197L, 0L).Returns(197L);
                    yield return new TestCaseData(0L, -185L, 0L).Returns(185L);
                }
            }
            public static IEnumerable SpecialCasesData
            {
                get
                {
                    yield return new TestCaseData(0L, Int64.MinValue + 100, Int64.MinValue).Returns(4L);
                    yield return new TestCaseData(0L, Int64.MinValue, Int64.MinValue + 100L).Returns(4L);
                    yield return new TestCaseData(0L, Int64.MinValue, Int64.MinValue).Throws(typeof(OverflowException));
                    yield return new TestCaseData(0L, Int64.MinValue, 0L).Throws(typeof(OverflowException));
                    yield return new TestCaseData(0L, 0L, Int64.MinValue).Throws(typeof(OverflowException));
                }
            }
        }

        public class DataClassAlgorithmThreeArgs
        {
            public static IEnumerable PositiveData
            {
                get
                {
                    yield return new TestCaseData(0L, 18L, 81L, 27L).Returns(9L);
                    yield return new TestCaseData(0L, 0L, 0L, 0L).Returns(0L);
                    yield return new TestCaseData(0L, 0L, 0L, 180L).Returns(180L);
                    yield return new TestCaseData(0L, 0L, 125L, 180L).Returns(5L);
                    yield return new TestCaseData(0L, 18L, -9L, 27L).Returns(9L);
                    yield return new TestCaseData(0L, 45L, -39L, -2820L).Returns(3L);
                    yield return new TestCaseData(0L, -20L, -80L, -9000L).Returns(20L);
                }
            }

            public static IEnumerable SpecialCasesData
            {
                get
                {
                    yield return new TestCaseData(0L, Int64.MinValue + 100, Int64.MinValue, Int64.MinValue+200).Returns(4L);
                    yield return new TestCaseData(0L, Int64.MinValue + 200, Int64.MinValue, Int64.MinValue + 100).Returns(4L);
                    yield return new TestCaseData(0L, Int64.MinValue, Int64.MinValue, Int64.MinValue + 100).Returns(4L);
                    yield return new TestCaseData(0L, Int64.MinValue, Int64.MinValue + 100, Int64.MinValue).Returns(4L);
                }
            }
        }

        public class DataClassAlgorithm
        {
            public static IEnumerable PositiveData
            {
                get
                {
                    yield return new TestCaseData(0L, new long[] { 15L, 9L, 18L, 102L, 126L }).Returns(3L);
                    yield return new TestCaseData(0L, new long[] { -100L, -25L, -150L, -250L, -150L, -2500L }).Returns(25L);
                    yield return new TestCaseData(0L, new long[] { 100L, 25L, 150L, 250L, -100L }).Returns(25L);
                    yield return new TestCaseData(0L, new long[] { 100L, -25L, 0L, -250L, 0L }).Returns(25L);
                    yield return new TestCaseData(0L, new long[] { -15L, 0L, 0L, -102L, -126L }).Returns(3L);
                    yield return new TestCaseData(0L, new long[] { 0L, 0L, 0L, 115L }).Returns(115L);
                    yield return new TestCaseData(0L, new long[] { 0L, 0L, 0L, 0L }).Returns(0L);
                }
            }
        }
        #endregion
    }
}
