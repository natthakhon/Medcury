using Medury;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Medcury.Test
{
    [TestClass]
    public class WUBTest
    {
        [TestMethod]
        public void RemoveTest()
        {
            string testString = "WUBAWUBBWUBCWUB";
            WUBRemover remover = new WUBRemover(testString);
            Assert.AreEqual(remover.GetResult(), "A B C");
        }
    }
}
