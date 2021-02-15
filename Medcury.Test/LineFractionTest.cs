using Medury;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Medcury.Test
{
    [TestClass]
    public class LineFractionTest
    {
        [TestMethod]
        public void TestFractionPhone()
        {
            string testString = ";+1-541-914-3010!";
            LineFraction lineFractionType = new LineFraction(testString);
            Dictionary<fractionType, string> result = lineFractionType.GetResult();
            Assert.AreEqual(result.Keys.First(), fractionType.Phone);
            Assert.AreEqual(result.Values.First(), "1-541-914-3010");
        }

        [TestMethod]
        public void TestFractionFirstName()
        {
            string testString = "<E";
            LineFraction lineFractionType = new LineFraction(testString);
            Dictionary<fractionType, string> result = lineFractionType.GetResult();
            Assert.AreEqual(result.Keys.First(), fractionType.FirstName);
            Assert.AreEqual(result.Values.First(), "E");
        }

        [TestMethod]
        public void TestFractionLastName()
        {
            string testString = "Kustur>";
            LineFraction lineFractionType = new LineFraction(testString);
            Dictionary<fractionType, string> result = lineFractionType.GetResult();
            Assert.AreEqual(result.Keys.First(), fractionType.LastName);
            Assert.AreEqual(result.Values.First(), "Kustur");
        }

        [TestMethod]
        public void TestFractionFullName()
        {
            string testString = "<Anastasia>";
            LineFraction lineFractionType = new LineFraction(testString);
            Dictionary<fractionType, string> result = lineFractionType.GetResult();
            Assert.AreEqual(result.Keys.First(), fractionType.FullName);
            Assert.AreEqual(result.Values.First(), "Anastasia");
        }

        [TestMethod]
        public void TestFractionAddress()
        {
            string testString = "Alphand_St.";
            LineFraction lineFractionType = new LineFraction(testString);
            Dictionary<fractionType, string> result = lineFractionType.GetResult();
            Assert.AreEqual(result.Keys.First(), fractionType.Address);
            Assert.AreEqual(result.Values.First(), "Alphand_St.");
        }
    }
}
