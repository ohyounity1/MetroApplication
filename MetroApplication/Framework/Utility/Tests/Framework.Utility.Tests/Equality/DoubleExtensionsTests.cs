using Framework.Utility.Equality;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.Utility.Tests.Equality
{
    [TestClass]
    public class DoubleExtensionsTests
    {
        [TestMethod]
        public void TestZeroEquals()
        {
            var @double = 0.0d;
            Assert.IsTrue(@double.EqualsWithin(0.0d));
        }

        [TestMethod]
        public void TestNonZeroEquals()
        {
            var @double = 3.14d;
            Assert.IsTrue(@double.EqualsWithin(3.14d));
        }

        [TestMethod]
        public void TestMaxEqualsPrecision()
        {
            var @double = 3.141593d;
            Assert.IsTrue(@double.EqualsWithin(3.141593d));
        }

        [TestMethod]
        public void TestPastEqualsPrecision()
        {
            var @double = 1.123456789d;
            Assert.IsTrue(@double.EqualsWithin(1.123456789d));
        }

        [TestMethod]
        public void TestWithinPrecisionFailure()
        {
            var @double = 3.14159d;
            Assert.IsFalse(@double.EqualsWithin(3.14158d));
        }

        [TestMethod]
        public void TestNaN()
        {
            var @double = double.NaN;
            Assert.IsTrue(@double.EqualsWithin(double.NaN));
        }

        [TestMethod]
        public void TestNegativeInfinity()
        {
            var @double = double.NegativeInfinity;
            Assert.IsTrue(@double.EqualsWithin(double.NegativeInfinity));
        }

        [TestMethod]
        public void TestPositiveInfinity()
        {
            var @double = double.PositiveInfinity;
            Assert.IsTrue(@double.EqualsWithin(double.PositiveInfinity));
        }
    }
}
