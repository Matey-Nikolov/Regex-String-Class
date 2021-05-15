using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex_Class_String
{
    class String_Task
    {
        public void TextFilter()
        {
            string[] banWords = Console.ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (string banWord in banWords)
                text = text.Replace(banWord, new string('*', banWord.Length));

            Console.WriteLine(text);
        }

        public void CountSubstring()
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            int count = 0;
            int index = text.IndexOf(pattern);

            while (index != -1)
            {
                count++;
                index = text.IndexOf(pattern, index + 1);
            }
            Console.WriteLine(count);
        }

        public int CountWord()
        {
            string word = Console.ReadLine();

            string text = Console.ReadLine().ToLower();

            int count = 0;
            int index = text.IndexOf(word);

            while (index != -1)
            {
                count++;
                index = text.IndexOf(word, index + 1);
            }
            return count;
        }
    }
}
