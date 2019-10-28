using Framework.Data.Serialize.CSV;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.Data.Tests.Exception
{
    [TestClass]
    public class UnrecognizedCSVHeaderPropertyTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var exception = new UnrecognizedCSVHeaderProperty("MyProperty");
            Assert.AreEqual("MyProperty", exception.PropertyName);
        }

        [TestMethod]
        public void TestToString()
        {
            var exception = new UnrecognizedCSVHeaderProperty("MyProperty");
            Assert.AreEqual("Unrecognized CSV header property: MyProperty", exception.ToString());
        }
    }
}
