using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regex_Class_String
{
    class Regex_Task
    {
        public void Regexfurniture()
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

        public void RegexStudentGrade()
        {
            Dictionary<string, List<double>> studentsGrade = new Dictionary<string, List<double>>();

            string pattern = @"(?<name>[A-Z][a-z]+) (?<grade>[2-5](.?\d+)?|6)";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            while (input != "end")
            {

                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);

                    string name = match.Groups["name"].Value;
                    double grade = double.Parse(match.Groups["grade"].Value);

                    if (!studentsGrade.ContainsKey(name))
                    {
                        studentsGrade.Add(name, new List<double>());
                    }

                    studentsGrade[name].Add(grade);
                }

                input = Console.ReadLine();
            }

            foreach (var st in studentsGrade)
            {
                Console.WriteLine($"{st.Key} -> {st.Value.Average()}");
            }
        }

        public void MatchNumberPhone()
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
    }
}
