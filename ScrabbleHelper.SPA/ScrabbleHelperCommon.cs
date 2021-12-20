using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ScrabbleHelper.SPA
{
    public class ScrabbleHelperCommon
    {
        Dictionary<string, int> PointByLetter = new Dictionary<string, int>();
        List<string> AllWords = new List<string>();

        public bool IsWordsLoaded = false;

        public ScrabbleHelperCommon()
        {
            LoadDictionaryInMemory();
            LoadPointByLetterDictionary();

            if (AllWords.Count > 0)
            {
                IsWordsLoaded = true;
            }
        }

        public Dictionary<int, string> SearchWords(string availableLetters)
        {
            //Build regular expression
            string regExp = string.Empty;
            foreach (var item in availableLetters)
            {
                regExp += $"(?=.*{item})";
            }

            //Search words
            var regularExp = new Regex(regExp);
            List<string> foundWords = AllWords.Where(f => regularExp.IsMatch(f)).ToList();

            //Get points by words
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            foreach (var item in foundWords)
            {
                dictionary.TryAdd(GetPointsForWord(item), item);
            }

            //Order by number of points asc
            dictionary = dictionary.OrderByDescending(o => o.Key).ToDictionary(o => o.Key, o => o.Value);

            return dictionary;
        }

        /// <summary>
        /// Return score for a letter in "letter" parameter
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        private int GetPointsForSingleLetter(string letter)
        {
            int points = 0;
            if (letter != "")
            {
                letter = RemoveDiacritics(letter.ToUpper());
                bool isLetterFound = this.PointByLetter.TryGetValue(letter.ToUpper(), out points);

                if (!isLetterFound)
                {
                    Console.WriteLine($"GetPointsForSingleLetter() - Letter {letter} not found in points dictionary.");
                    //throw new Exception($"GetPointsForSingleLetter() - Letter {letter} not found in points dictionary.");
                }
            }

            return points;
        }

        /// <summary>
        /// Return score for a word in "word" parameter
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int GetPointsForWord(string word)
        {
            int totalPoints = 0;

            foreach (var letter in word)
            {
                var points = GetPointsForSingleLetter(letter.ToString());
                totalPoints += points;
            }

            return totalPoints;
        }

        /// <summary>
        /// Static load for letter score
        /// </summary>
        private void LoadPointByLetterDictionary()
        {
            PointByLetter = new Dictionary<string, int>();

            //1 points letters
            PointByLetter.Add("A", 1);
            PointByLetter.Add("E", 1);
            PointByLetter.Add("O", 1);
            PointByLetter.Add("I", 1);
            PointByLetter.Add("S", 1);
            PointByLetter.Add("N", 1);
            PointByLetter.Add("L", 1);
            PointByLetter.Add("R", 1);
            PointByLetter.Add("U", 1);
            PointByLetter.Add("T", 1);

            //2 points letters
            PointByLetter.Add("D", 2);
            PointByLetter.Add("G", 2);

            PointByLetter.Add("C", 3);
            PointByLetter.Add("B", 3);
            PointByLetter.Add("M", 3);
            PointByLetter.Add("P", 3);

            PointByLetter.Add("H", 4);
            PointByLetter.Add("F", 4);
            PointByLetter.Add("V", 4);
            PointByLetter.Add("Y", 4);
            PointByLetter.Add("W", 4);

            PointByLetter.Add("CH", 5);
            PointByLetter.Add("Q", 5);
            PointByLetter.Add("K", 5);

            PointByLetter.Add("J", 8);
            PointByLetter.Add("LL", 8);
            PointByLetter.Add("Ñ", 8);
            PointByLetter.Add("RR", 8);
            PointByLetter.Add("X", 8);

            PointByLetter.Add("Z", 10);
        }

        /// <summary>
        /// Dictionary from https://raw.githubusercontent.com/titoBouzout/Dictionaries/ Thanks!
        /// </summary>
        private void LoadDictionaryInMemory()
        {
            using (StreamReader sr = new StreamReader("./Dictionaries/DictionarySpanish.txt"))
            {
                string _line;
                while ((_line = sr.ReadLine()) != null)
                {
                    AllWords.Add(_line.ToLower());
                }
            }
        }

        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
