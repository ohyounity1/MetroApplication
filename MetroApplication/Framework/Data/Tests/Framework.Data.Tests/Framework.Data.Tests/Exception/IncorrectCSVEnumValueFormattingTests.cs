using System;
using Framework.Data.Serialize.CSV;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.Data.Tests.Exception
{
    [TestClass]
    public class IncorrectCSVEnumValueFormattingTests
    {
        public enum MyEnum
        { }

        [TestMethod]
        public void TestToString()
        {
            var exception = new IncorrectCSVEnumValueFormatting(typeof(MyEnum), "MyEnumProperty", "65");
            Assert.AreEqual("CSV Value MyEnumProperty is formatted incorrectly: 65, expected enum of type MyEnum", exception.ToString());
        }
    }
}
