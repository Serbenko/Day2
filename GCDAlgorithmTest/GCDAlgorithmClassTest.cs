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
        public int GetGCDEuclideanAlgorithmTest(int a, int b, Stopwatch watch)
        {
            return GCDClass.GetGCDEuclideanAlgorithm(a, b, watch);
        }

        [Test]
        [TestCaseSource(typeof(DataClassAlgorithmThreeArgs), "PositiveData")]
        public int GetGCDEuclideanAlgorithmTest(int a, int b, int c, Stopwatch watch)
        {
            return GCDClass.GetGCDEuclideanAlgorithm(a, b, c, watch);
        }

        [Test]
        [TestCaseSource(typeof(DataClassAlgorithm), "PositiveData")]
        public int GetGCDEuclideanAlgorithmTest(Stopwatch watch, params int[] array)
        {
            return GCDClass.GetGCDEuclideanAlgorithm(watch, array);
        }
        #endregion

        #region BinaryAlgorithmTests
        [Test]
        [TestCaseSource(typeof(DataClassAlgorithmTwoArgs), "PositiveData")]
        [TestCaseSource(typeof(DataClassAlgorithmTwoArgs), "SpecialCasesData")]
        public int GetGCDBinaryAlgorithmTest(int a, int b, Stopwatch watch)
        {
            return GCDClass.GetGCDBinaryAlgorithm(a, b, watch);
        }

        [Test]
        [TestCaseSource(typeof(DataClassAlgorithmThreeArgs), "PositiveData")]
        [TestCaseSource(typeof(DataClassAlgorithmThreeArgs), "SpecialCasesData")]
        public int GetGCDBinaryAlgorithmTest(int a, int b, int c, Stopwatch watch)
        {
            return GCDClass.GetGCDBinaryAlgorithm(a, b, c, watch);
        }

        [Test]
        [TestCaseSource(typeof(DataClassAlgorithm), "PositiveData")]
        public int GetGCDBinaryAlgorithmTest(Stopwatch watch, params int[] array)
        {
            return GCDClass.GetGCDBinaryAlgorithm(watch, array);
        }
        #endregion

        #region DataClasses
        public class DataClassAlgorithmTwoArgs
        {
            public static IEnumerable PositiveData
            {
                get
                {
                    yield return new TestCaseData(18, 9, new Stopwatch()).Returns(9);
                    yield return new TestCaseData(-10, 470, new Stopwatch()).Returns(10);
                    yield return new TestCaseData(45, -39, new Stopwatch()).Returns(3);
                    yield return new TestCaseData(0, 15, new Stopwatch()).Returns(15);
                    yield return new TestCaseData(197, 0, new Stopwatch()).Returns(197);
                    yield return new TestCaseData(-185, 0, new Stopwatch()).Returns(185);
                }
            }
            public static IEnumerable SpecialCasesData
            {
                get
                {
                    yield return new TestCaseData(Int32.MinValue + 100, Int32.MinValue, new Stopwatch()).Returns(4);
                    yield return new TestCaseData(Int32.MinValue, Int32.MinValue + 100, new Stopwatch()).Returns(4);
                    yield return new TestCaseData(Int32.MinValue, Int32.MinValue, new Stopwatch()).Throws(typeof(OverflowException));
                    yield return new TestCaseData(Int32.MinValue, 0, new Stopwatch()).Throws(typeof(OverflowException));
                    yield return new TestCaseData(0, Int32.MinValue, new Stopwatch()).Throws(typeof(OverflowException));
                }
            }
        }

        public class DataClassAlgorithmThreeArgs
        {
            public static IEnumerable PositiveData
            {
                get
                {
                    yield return new TestCaseData(18, 81, 27, new Stopwatch()).Returns(9);
                    yield return new TestCaseData(0, 0, 0, new Stopwatch()).Returns(0);
                    yield return new TestCaseData(0, 0, 180, new Stopwatch()).Returns(180);
                    yield return new TestCaseData(0, 125, 180, new Stopwatch()).Returns(5);
                    yield return new TestCaseData(18, -9, 27, new Stopwatch()).Returns(9);
                    yield return new TestCaseData(45, -39, -2820, new Stopwatch()).Returns(3);
                    yield return new TestCaseData(-20, -80, -9000, new Stopwatch()).Returns(20);
                }
            }

            public static IEnumerable SpecialCasesData
            {
                get
                {
                    yield return new TestCaseData(Int32.MinValue + 100, Int32.MinValue, Int32.MinValue+200, new Stopwatch()).Returns(4);
                    yield return new TestCaseData(Int32.MinValue + 200, Int32.MinValue, Int32.MinValue + 100, new Stopwatch()).Returns(4);
                    yield return new TestCaseData(Int32.MinValue, Int32.MinValue, Int32.MinValue + 100, new Stopwatch()).Returns(4);
                    yield return new TestCaseData(Int32.MinValue, Int32.MinValue + 100, Int32.MinValue,  new Stopwatch()).Returns(4);
                }
            }
        }

        public class DataClassAlgorithm
        {
            public static IEnumerable PositiveData
            {
                get
                {
                    yield return new TestCaseData(new Stopwatch(), new int[] { 15, 9, 18, 102, 126 }).Returns(3);
                    yield return new TestCaseData(new Stopwatch(), new int[] { -100, -25, -150, -250, -150, -2500 }).Returns(25);
                    yield return new TestCaseData(new Stopwatch(), new int[] { 100, 25, 150, 250, -100 }).Returns(25);
                    yield return new TestCaseData(new Stopwatch(), new int[] { 100, -25, 0, -250, 0 }).Returns(25);
                    yield return new TestCaseData(new Stopwatch(), new int[] { -15, 0, 0, -102, -126 }).Returns(3);
                    yield return new TestCaseData(new Stopwatch(), new int[] { 0, 0, 0, 115 }).Returns(115);
                    yield return new TestCaseData(new Stopwatch(), new int[] { 0, 0, 0, 0 }).Returns(0);
                }
            }
        }
        #endregion
    }
}
