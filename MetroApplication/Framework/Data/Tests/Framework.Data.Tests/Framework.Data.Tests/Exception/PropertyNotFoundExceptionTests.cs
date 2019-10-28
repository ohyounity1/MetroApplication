using Framework.Data.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.Data.Tests.Exception
{
    [TestClass]
    public class PropertyNotFoundExceptionTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var exception = new PropertyNotFoundException("PropertyName");
            Assert.AreEqual("PropertyName", exception.PropertyName);
        }

        [TestMethod]
        public void TestToString()
        {
            var exception = new PropertyNotFoundException("TrainSimulator2019");
            Assert.AreEqual("The following required property was not found: TrainSimulator2019", exception.ToString());
        }
    }
}
