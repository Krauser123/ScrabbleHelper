using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScrabbleHelper.Test
{
    [TestClass]
    public class ScrabbleHelperCommonTest
    {
        ScrabbleHelperCommon scrabbleHelperCommon = new ScrabbleHelperCommon();

        [TestMethod]
        public void Initialise()
        {
            Assert.IsTrue(scrabbleHelperCommon.IsWordsLoaded);
        }

        [TestMethod]
        public void RequestWord()
        {
            var foundWords = scrabbleHelperCommon.SearchWords("ajs");

            Assert.IsTrue(foundWords.Count > 0);
        }

        [TestMethod]
        public void CheckPoints()
        {
            var foundWords = scrabbleHelperCommon.GetPointsForWord("Hello");

            Assert.IsTrue(foundWords == 8);
        }

        [TestMethod]
        public void CheckPoints2()
        {
            var foundWords = scrabbleHelperCommon.GetPointsForWord("Xenomorph");

            Assert.IsTrue(foundWords == 23);
        }

        [TestMethod]
        public void CheckPoints3()
        {
            var foundWords = scrabbleHelperCommon.GetPointsForWord("Syndrome");

            Assert.IsTrue(foundWords == 14);
        }

        [TestMethod]
        public void CheckPointsNotValidWord()
        {
            Assert.ThrowsException<Exception>(()=>scrabbleHelperCommon.GetPointsForWord("S!ñyn!ñdr!ñome"));
        }
    }
}
