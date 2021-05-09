namespace Regex_Class_String
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            Console.Write("Emter a num 1, 2, 3 or 4: ");
            int n = int.Parse(Console.ReadLine());
            while (n == 3)
            {
                switch (n)
                {
                    case 1: RegexTask(); break;
                    case 2: TextFilter(); break;
                    case 3: Articles(); break;
                    case 4: return;
                }
                Console.Write("Emter a num 1, 2, 3 or 4: ");
                n = int.Parse(Console.ReadLine());
            }
        }

        public static void Articles()
        {
            string[] someOrNo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string rename = someOrNo[0];
            string edit = someOrNo[1];
            string changeAuthor = someOrNo[2];

            Article article = new Article(rename, edit, changeAuthor);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] text = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string renameEditChangeAuthor = text[0];
                string message = text[1];

                switch (renameEditChangeAuthor)
                {
                    case "Edit":
                        article.Edit(message);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(message);
                        break;
                    case "Rename":
                        article.Rename(message);
                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }

        public static void TextFilter()
        {
            string[] banWords = Console.ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (string banWord in banWords)
                text = text.Replace(banWord, new string('*', banWord.Length));
             
            Console.WriteLine(text);
        }

        public static void RegexTask()
        {
            Regex rg = new Regex(@">>([A-Za-z]+)<<([\d,]*)!([0-9])");
            List<string> furniture = new List<string>();

            string input = Console.ReadLine();
            float TotalPrice = 0;

            while (input != "Purchase")
            {
                string name = "";
                float currentMoney = 0;
                int quantity = 0;

                Match match = rg.Match(input);

                if (match.Success)
                {
                    name = match.Groups[1].Value;
                    currentMoney = float.Parse(match.Groups[2].Value);
                    quantity = int.Parse(match.Groups[3].Value);

                    furniture.Add(name);
                    TotalPrice += currentMoney * quantity;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (string nameFurniture in furniture)
                Console.WriteLine(nameFurniture);

            Console.WriteLine($"Total money spend: {TotalPrice:f2}");
        }
    }
}
