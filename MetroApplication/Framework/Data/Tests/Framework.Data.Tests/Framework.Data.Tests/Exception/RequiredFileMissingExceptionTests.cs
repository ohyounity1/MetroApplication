using Framework.Data.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.Data.Tests.Exception
{
    [TestClass]
    public class RequiredFileMissingExceptionTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            var exception = new RequiredFileMissingException("MissingFile");
            Assert.AreEqual("MissingFile", exception.FileName);
        }

        [TestMethod]
        public void TestToString()
        {
            var exception = new RequiredFileMissingException("Missing File");
            Assert.AreEqual("Required file Missing File is missing!", exception.ToString());
        }
    }
}
