namespace Regex_Class_String
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            Console.Write("Enter a num 1 - 10: ");
            int n = int.Parse(Console.ReadLine());
            while (n != 10)
            {
                switch (n)
                {
                    case 1:
                        Regex_Task furnitureTask = new Regex_Task();
                        furnitureTask.Regexfurniture();
                        break; 
                    case 2:
                        String_Task textFilter = new String_Task();
                        textFilter.TextFilter();
                        break;
                    case 3: Articles(); break;
                    case 4:
                        String_Task countWord = new String_Task();
                        Console.WriteLine(countWord.CountWord());
                        break;
                    case 5:
                        Regex_Task matchNumberPhone = new Regex_Task();
                        matchNumberPhone.MatchNumberPhone();
                        break;
                    case 6: Students(); break;
                    case 7:
                        String_Task countSubstring = new String_Task();
                        countSubstring.CountSubstring();
                        break;
                    case 8:
                        Regex_Task studentGrade = new Regex_Task();
                        studentGrade.RegexStudentGrade();
                        break;
                    case 9:  NetherRealms(); break;
                    case 10: return;

                }
                Console.WriteLine("----------");
                Console.Write("Enter a num 1 - 10 : ");
                n = int.Parse(Console.ReadLine());
            }
        }

        public static void NetherRealms()
        {
                        //Dictionary<string, Dictionary<int, double>> nameHealthDamage = new Dictionary<string, Dictionary<int, double>>();

            List<NameHealthDamage> nameHealthDamages = new List<NameHealthDamage>();

            List<string> codeText = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int health = 0;
            double damage = 0;

            foreach (string text in codeText)
            {

                string patternWordHealth = @"[A-za-z]+";
                MatchCollection codeWordMatch = Regex.Matches(text, patternWordHealth);

                string letter = "";
                foreach (var chr in codeWordMatch)
                    letter += chr.ToString();

                foreach (char chr in letter)
                    health += (int)(chr);

                string patternDamage = @"[-?\d.?]+";
                MatchCollection codeNumbers = Regex.Matches(text, patternDamage);

                foreach (var digit in codeNumbers)
                    damage += double.Parse(digit.ToString());

                string paternMultiaOrDivision = @"[\/|*]+";
                MatchCollection MultiAndDivision = Regex.Matches(text, paternMultiaOrDivision);

                foreach (var item1 in MultiAndDivision)
                {
                    foreach (char item2 in item1.ToString())
                    {
                        if (item2 == '*')
                        {
                            damage *= 2;
                        }
                        else if (item2 == '/')
                        {
                            damage /= 2;
                        }
                    }
                }

                nameHealthDamages.Add(new NameHealthDamage()
                {
                    Name = text,
                    Health = health,
                    Damage = damage
                });

                health = 0;
                damage = 0;
            }

            foreach (var NHD in nameHealthDamages
                .OrderBy(x => x.Name))
            {
                Console.WriteLine($"{NHD.Name} - {NHD.Health} health, {NHD.Damage:f2} damage");
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
    }
}
