using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class GetInfoAboutFile
    {
        private int employeeCounter;
        private int rightNumbeCounter;
        private int wrongNumberCounter;
        private int rightEmailCounter;
        private int wrongEmailCounter;

        public GetInfoAboutFile() { }

        public int EmployeeCounter { get => employeeCounter;}
        public int RightNumbeCounter { get => rightNumbeCounter; }
        public int WrongNumberCounter { get => wrongNumberCounter; }
        public int RightEmailCounter { get => rightEmailCounter; }
        public int WrongEmailCounter { get => wrongEmailCounter; }

        public void AnalyzeFile(string fullFileName)
        {
            using (StreamReader sr = new StreamReader(fullFileName))
            {
                string header = sr.ReadLine();
                if (!header.Equals("name\temail\tphone"))
                {
                    throw new WrongHeaderExeption(header);
                }
                while (!sr.EndOfStream)
                {
                    employeeCounter++;
                    AnalizeString(sr.ReadLine());
                }
            } 
        }

        public void AnalizeString(string nextString)
        {

            string[] masStrings = nextString.Split('\t');

            if (masStrings.Length != 3)
            {
                throw new WrongStringExeption(nextString);
            }

            string email = masStrings[1].Trim('\"');
            string phone = masStrings[2].Trim('\"');

            if (IsEmailCorrect(email))
                rightEmailCounter++;
            else
                wrongEmailCounter++;
            if (IsNumberCorrect(phone))
                rightNumbeCounter++;
            else
                wrongNumberCounter++;
        }

        public bool IsEmailCorrect(string email)
        {
            // сначала 1 буква, потом буквы и/или цифры, потом @, потом буквы, потом точка, потом окончание ru|com|net
            const string pattern = @"^[a-zA-Z]\w*\@[a-zA-Z]*\.(ru|com|net)$";
            return Regex.IsMatch(email, pattern);
        }

        public bool IsNumberCorrect(string number)
        {
            // Соответствие вариантам 
            // 111-11-11
            // 111-1111 
            // 1111111
            // (111) 111-11-11
            // (111)-111-11-11
            // (111)111-11-11
            // 111-111-11-11
            // (111)-111-1111 
            const string pattern = @"^(\(?\d{3}\)?[ -]?)?\d{3}-?\d{2}-?\d{2}$";
            return Regex.IsMatch(number, pattern);
        }

    }
}
