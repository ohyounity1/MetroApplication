using Framework.Data.Serialize.CSV;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.Data.Tests.Exception
{
    [TestClass]
    public class IncorrectCSVBoolValueFormattingTests
    {
        [TestMethod]
        public void TestToString()
        {
            var exception = new IncorrectCSVBoolValueFormatting("MyProperty", "39");
            Assert.AreEqual("CSV Value MyProperty is formatted incorrectly: 39, expecting true/false", exception.ToString());
        }
    }
}
