using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrabbleHelper.SPA;

namespace ScrabbleHelper.Test
{
    [TestClass]
    public class ScrabbleHelperCommonTest
    {
        ScrabbleHelperCommon ScrabbleHelperCommon = new ScrabbleHelperCommon();

        [TestMethod]
        public void Initialise()
        {
            Assert.IsTrue(ScrabbleHelperCommon.IsWordsLoaded);
        }

        [TestMethod]
        public void RequestWord()
        {
            var foundWords = ScrabbleHelperCommon.SearchWords("ajs");

            Assert.IsTrue(foundWords.Count > 0);
        }

        [TestMethod]
        public void CheckPoints()
        {
            var foundWords = ScrabbleHelperCommon.GetPointsForWord("Hello");

            Assert.IsTrue(foundWords == 8);
        }

        [TestMethod]
        public void CheckPoints2()
        {
            var foundWords = ScrabbleHelperCommon.GetPointsForWord("Xenomorph");

            Assert.IsTrue(foundWords == 23);
        }

        [TestMethod]
        public void CheckPoints3()
        {
            var foundWords = ScrabbleHelperCommon.GetPointsForWord("Syndrome");

            Assert.IsTrue(foundWords == 14);
        }

        [TestMethod]
        public void CheckPointsNotValidWord()
        {
            var foundWords = ScrabbleHelperCommon.GetPointsForWord("S!ñyn!ñdr!ñome");

            Assert.IsTrue(foundWords == 17);
        }
    }
}
