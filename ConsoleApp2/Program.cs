using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static Dictionary<char, string> letterToMorse = new Dictionary<char, string>
        {
        {'a', ".-"}, {'b', "-..."}, {'c', "-.-."}, {'d', "-.."}, {'e', "."},
        {'f', "..-."}, {'g', "--."}, {'h', "...."}, {'i', ".."}, {'j', ".---"},
        {'k', "-.-"}, {'l', ".-.."}, {'m', "--"}, {'n', "-."}, {'o', "---"},
        {'p', ".--."}, {'q', "--.-"}, {'r', ".-."}, {'s', "..."}, {'t', "-"},
        {'u', "..-"}, {'v', "...-"}, {'w', ".--"}, {'x', "-..-"}, {'y', "-.--"},
        {'z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
        {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."},
        {'9', "----."}, {' ', "/"}
        };
        static Dictionary<string, char> morseToLetter = new Dictionary<string, char>();

        static void Main(string[] args)
        {
            foreach (var item in letterToMorse)
                morseToLetter[item.Value] = item.Key;

            while (true)
            {
                Console.Write("Выберите режим перевода: 1 - из азбуки морзе в текст, 2 - из текста в азбуку морзе: ");
                string mode = Console.ReadLine();
                string result = "";

                if (mode == "1")
                {
                    Console.Write("Введите текст на азбуке морзе: ");
                    string morseCode = Console.ReadLine();
                    result = DecodeMorse(morseCode);
                }
                else if (mode == "2")
                {
                    Console.Write("Введите текст на английском языке: ");
                    string englishText = Console.ReadLine().ToLower();
                    result = EncodeMorse(englishText);
                }
                else
                    Console.WriteLine("Ошибка! Выберите режим 1 или 2.");

                Console.WriteLine("Результат перевода: " + result);
                Console.WriteLine();
            }
        }

        static string DecodeMorse(string morseCode)
        {
            string[] words = morseCode.Split(new[] { " / " }, StringSplitOptions.None);
            string result = "";

            foreach (string word in words)
            {
                string[] letters = word.Split(' ');

                foreach (string letter in letters)
                    if (morseToLetter.ContainsKey(letter))
                        result += morseToLetter[letter];
                result += " ";
            }
            return result;
        }

        static string EncodeMorse(string englishText)
        {
            string result = "";
            foreach (char letter in englishText)
                if (letterToMorse.ContainsKey(letter))
                    result += letterToMorse[letter] + " ";
            return result.Trim();
        }
    }
}



