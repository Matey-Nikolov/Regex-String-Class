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
            Console.Write("Emter a num 1 - 7: ");
            int n = int.Parse(Console.ReadLine());
            while (n != 7)
            {
                switch (n)
                {
                    case 1: RegexTask(); break;
                    case 2: TextFilter(); break;
                    case 3: Articles(); break;
                    case 4: Console.WriteLine(CountWord()); break;
                    case 5: MatchNumberPhone(); break;
                    case 6: Students(); break;
                    case 7: return;

                }
                Console.Write("Emter a num 1, 2, 3 or 4: ");
                n = int.Parse(Console.ReadLine());
            }
        }

        public static void Students()
        {
            List<Student> students = new List<Student>();

            string[] nameLAstNameAgeCity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (nameLAstNameAgeCity[0] != "end")
            {
                string firstName = nameLAstNameAgeCity[0];
                string lastName = nameLAstNameAgeCity[1];
                int age = int.Parse(nameLAstNameAgeCity[2]);
                string city = nameLAstNameAgeCity[3];

                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    City = city
                };

                students.Add(student);

                nameLAstNameAgeCity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string filterCity = Console.ReadLine();

            List<Student> filteredStudents = students
                .Where(x => x.City == filterCity)
                .ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        public static void MatchNumberPhone()
        {
            string pattern = @"\+359([ |-])2\1[0-9]{3}\1[0-9]{4}";
            string phones = Console.ReadLine();

            var phonsMatches = Regex.Matches(phones, pattern);

            var matchedPhones = phonsMatches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }

        public static int CountWord()
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
