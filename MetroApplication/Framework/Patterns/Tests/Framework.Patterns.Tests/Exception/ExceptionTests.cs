using Framework.Patterns.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.Patterns.Tests.Exception
{
    [TestClass]
    public class ExceptionTests
    {
        private class ExceptionDetails
        {
            public override string ToString() => "Exception Details Provided Here!";
        }

        [TestMethod]
        public void TestConstructor()
        {
            var exception = new Exception<ExceptionDetails>(new ExceptionDetails());
            Assert.IsInstanceOfType(exception.Details, typeof(ExceptionDetails));
        }

        [TestMethod]
        public void TestToString()
        {
            var exception = new Exception<ExceptionDetails>(new ExceptionDetails());
            Assert.AreEqual("Exception Details Provided Here!", exception.ToString());
        }

        [TestMethod]
        public void TestThrowsMethodHelper()
        {
            var exception = Framework.Patterns.Exception.Exception.Throw(new ExceptionDetails());
            Assert.IsInstanceOfType(exception, typeof(Exception<ExceptionDetails>));
        }
    }
}
