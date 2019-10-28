using Framework.Utility.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.Utility.Tests.Patterns
{
    [TestClass]
    public class EnumerationExtensionsTests
    {
        [TestMethod]
        public void TestEnumerate()
        {
            var ints = new int[] { 1, 2, 3, 4 };

            var index = 0;
            ints.ForEach((i) => Assert.AreEqual(i, ints[index++]));
        }
    }
}
