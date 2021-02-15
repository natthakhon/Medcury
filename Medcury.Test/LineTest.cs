using Medury;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Medcury.Test
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void TestLineFractionsCount()
        {
            string testString = " 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010!";
            Line line = new Line(testString);
            Assert.AreEqual(line.Fractions.Count, 7);
        }

        [TestMethod]
        public void TestLineFractionsName()
        {
            string testString = " 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010!";
            Line line = new Line(testString);
            Assert.AreEqual(line.Name, "E Kustur");
        }

        [TestMethod]
        public void TestLineFractionsFullName()
        {
            string testString = "<Anastasia> +48-421-674-8974 Via Quirinal Roma";
            Line line = new Line(testString);
            Assert.AreEqual(line.Name, "Anastasia");
        }

        [TestMethod]
        public void TestLineFractionsPhone()
        {
            string testString = "<Anastasia> +48-421-674-8974 Via Quirinal Roma";
            Line line = new Line(testString);
            Assert.AreEqual(line.Phone, "48-421-674-8974");
        }
    }
}
