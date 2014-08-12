using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;

namespace BrailleConverter
{
    class convertingBraille
    {
        public string convertCapitalsToUnderscore(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            text = " " + text;

            text = text.Replace('.', '\'');
            text = text.Replace(',', '1');
            text = text.Replace('?', '5');
            text = text.Replace('!', '6');
            text = text.Replace(':', '3');
            text = text.Replace('=', '7');
            text = text.Replace('+', '4');
            text = text.Replace('*', '9');
            text = text.Replace('é', '=');

            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);

            bool firstCapLetterInWord = true;

            for (int i = 1; i < text.Length; i++)
            {
                char letter = text[i]; // Aktuell bokstav
                char nextLetter = ' '; // Nästa bokstav

                try
                {
                    nextLetter = text[i + 1];
                }
                catch
                {

                }

                // Är det stor bokstav?
                if (char.IsUpper(letter))
                {
                    // Är nästa bokstav stor?
                    if (char.IsUpper(nextLetter))
                    {
                        // Är det början av ett helt ord med caps?
                        if (firstCapLetterInWord)
                        {
                            newText.Append(",,"); // 2 st understräck framför ordet

                            firstCapLetterInWord = false; // Ändra så att inte nästa bokstav får 2 st understräck
                        }
                    }
                    else // Annars bara ett understräck
                    {
                        if (firstCapLetterInWord)
                        {
                            newText.Append(","); // Sätt understräck framför bokstav
                        }

                        firstCapLetterInWord = true; // Förbereda för nästa capsord
                    }
                }

                newText.Append(text[i]);
            }

            string finishedText = newText.ToString().TrimStart(); // Ta bort mellanslaget i början

            finishedText = finishedText.ToLower();

            finishedText = finishedText.Replace('å', '*');
            finishedText = finishedText.Replace('ä', '>');
            finishedText = finishedText.Replace('ö', '[');
            finishedText = finishedText.Replace("@", "^(");

            return finishedText;
        }

        public string convertNumbersToBrailleNumbers(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            text = " " + text;

            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);

            bool firstNumberInNumber = true;

            for (int i = 1; i < text.Length; i++)
            {
                char letter = text[i]; // Aktuell tecken
                char nextLetter = ' '; // Nästa tecken

                try
                {
                    nextLetter = text[i + 1];
                }
                catch
                {

                }

                char convertedChar = text[i];

                // Är tecknet en siffra?
                if (char.IsNumber(letter))
                {
                    // Är nästa tecken en siffra?
                    if (char.IsNumber(nextLetter))
                    {
                        // Är det början av ett flertaligt nummer?
                        if (firstNumberInNumber)
                        {
                            newText.Append('#'); // Brädkors framför nummret

                            firstNumberInNumber = false; // Ändra så att inte nästa siffra får brädkors
                        }
                    }
                    else // Annars bara ett understräck
                    {
                        if (firstNumberInNumber)
                        {
                            newText.Append('#'); // Sätt brädkors framför siffran

                        }

                        firstNumberInNumber = true; // Förbereda för nästa flertaliga nummer
                    }
                }

                newText.Append(convertedChar);
            }

            string finishedText = newText.ToString().TrimStart();

            finishedText = finishedText.Replace('1', 'a');
            finishedText = finishedText.Replace('2', 'b');
            finishedText = finishedText.Replace('3', 'c');
            finishedText = finishedText.Replace('4', 'd');
            finishedText = finishedText.Replace('5', 'e');
            finishedText = finishedText.Replace('6', 'f');
            finishedText = finishedText.Replace('7', 'g');
            finishedText = finishedText.Replace('8', 'h');
            finishedText = finishedText.Replace('9', 'i');
            finishedText = finishedText.Replace('0', 'j');

            return finishedText;
        }

        public string convertBackToPrint(string oldText)
        {
            string newText = oldText.Replace(",", "");
            newText = newText.Replace("*", "å");
            newText = newText.Replace(">", "ä");
            newText = newText.Replace("[", "ö");
            newText = newText.Replace('\'', '.');
            newText = newText.Replace('1', ',');
            newText = newText.Replace('5', '?');
            newText = newText.Replace('6', '!');
            newText = newText.Replace('3', ':');
            newText = newText.Replace('7', '=');
            newText = newText.Replace('4', '+');
            newText = newText.Replace('9', '*');
            newText = newText.Replace('=', 'é');

            var numberMatcher = new Regex(@"#\w+");
            var firstMatch = numberMatcher.Match(newText);
            string alteredMatch = convertToNum(firstMatch.ToString());
            string yourNewText = numberMatcher.Replace(newText, alteredMatch);

            return yourNewText;
        }

        private string convertToNum(string oldText)
        {
            string newText = "";

            newText = oldText.Replace("a", "1");
            newText = newText.Replace("b", "2");
            newText = newText.Replace("c", "3");
            newText = newText.Replace("d", "4");
            newText = newText.Replace("e", "5");
            newText = newText.Replace("f", "6");
            newText = newText.Replace("g", "7");
            newText = newText.Replace("h", "8");
            newText = newText.Replace("i", "9");
            newText = newText.Replace("j", "0");
            newText = newText.Replace("#", "");

            return newText;
        }
    }
}
