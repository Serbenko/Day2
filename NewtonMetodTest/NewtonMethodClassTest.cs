using System;
using System.Collections;
using NUnit.Framework;

namespace NewtonMetodTest
{
    [TestFixture]
    public class NewtonMethodClassTest
    {

        [Test]
        [TestCaseSource(typeof(DataClass), "PositiveData")]
        public bool GetRootByNewtonMethodTestBool(int power, double number, double accuransy)
        {

            double root = NewtonMethod.NewtonMethodClass.GetRootByNewtonMethod(power, number, accuransy);
            double testRoot = Math.Pow(number, 1.0 / (double)power);
            return root > testRoot - accuransy && root < testRoot + accuransy;
        }
      
        [Test]
        [TestCaseSource(typeof(DataClass), "SpesialCasesData")]
        [TestCaseSource(typeof(DataClass), "ExeptionData")]
        public double GetRootByNewtonMethodTest(int power, double number, double accuransy)
        {

            return NewtonMethod.NewtonMethodClass.GetRootByNewtonMethod(power, number, accuransy);
        }

        public class DataClass
        {
            public static IEnumerable PositiveData
            {
                get
                {
                    yield return new TestCaseData(2, 4.0, 1E-15).Returns(true);
                    yield return new TestCaseData(12, 129.0, 1E-8).Returns(true);
                    yield return new TestCaseData(2, 11.0, 1E-5).Returns(true);
                    yield return new TestCaseData(3, 145, 0.05).Returns(true);
                }
            }

            public static IEnumerable SpesialCasesData
            {
                get
                {
                    yield return new TestCaseData(0, 0.0 , 0.01).Returns(1.0);
                    yield return new TestCaseData(12, 0.0, 1E-15).Returns(0.0);
                    yield return new TestCaseData(-14, 0.0, 1E-15).Returns(Double.PositiveInfinity);
                    yield return new TestCaseData(6, -65.0, 1E-15).Returns(Double.NaN);
                }
            }

            public static IEnumerable ExeptionData
            {
                get
                {
                    yield return new TestCaseData(12, 5.0, 1.002).Throws(typeof(Exception));
                    yield return new TestCaseData(12, 5.0, -0.009).Throws(typeof(Exception));
                }
            }
        } 
    }
}
