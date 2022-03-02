using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {   bool continueOperation = true;
            string content = "James Bond is a fictional character created by novelist Ian Fleming in 1953. A British secret agent working for MI6 under the codename 007, he has been portrayed on film by actors Sean Connery, David Niven, George Lazenby, Roger Moore, Timothy Dalton, Pierce Brosnan and Daniel Craig in twenty-seven productions. All but two films were made by Eon Productions, which now holds the adaptation rights to all of Fleming\'s Bond novels.[1][2]In 1961, producers Albert R.Broccoli and Harry Saltzman purchased the filming rights to Fleming\'s novels.[3] They founded Eon Productions and, with financial backing by United Artists, produced Dr. No, directed by Terence Young and featuring Connery as Bond.[4] Following its release in 1962, Broccoli and Saltzman created the holding company Danjaq to ensure future productions in the James Bond film series.[5] The series currently has twenty-five films, with the most recent, No Time to Die, released in September 2021. With a combined gross of nearly $7 billion to date, it is the fifth-highest-grossing film series.[6] Accounting for inflation, it has earned over $14 billion at current prices.[a] The films have won five Academy Awards: for Sound Effects (now Sound Editing) in Goldfinger (at the 37th Awards), to John Stears for Visual Effects in Thunderball (at the 38th Awards), to Per Hallberg and Karen Baker Landers for Sound Editing, to Adele and Paul Epworth for Original Song in Skyfall (at the 85th Awards) and to Sam Smith and Jimmy Napes for Original Song in Spectre (at the 88th Awards). Several of the songs produced for the films have been nominated for Academy Awards for Original Song, including Paul McCartney's \"Live and Let Die\", Carly Simon\'s \"Nobody Does It Better\" and Sheena Easton\'s \"For Your Eyes Only\".In 1982 Albert R. Broccoli received the Irving G.Thalberg Memorial Award.[8]";
            do {
                Console.WriteLine("\nEnter the operation which you want to perform\n" +
                    "1.Find out number of 'Blank Spaces' in the string\n" +
                    "2.Find out number of 'Words'\n" +
                    "3.Find out number of '.'\n" +
                    "4.Find out number of statements\n" +
                    "5.Find out number of digits\n" +
                    "6.Find out number of vowels (a,e,i,o,u)\n" +
                    "7.Find out number of 'the', 'is', 'to', 'and' and their positions (indexes)\n" +
                    "8.Find out number and positions of comma (,)\n" +
                    "9.Reverse each word in string\n" +
                    "10.Reverse entire string\n" +
                    "11.Print each statement in separate line on console from the above string\n" +
                    "12.Print all words decorated using \"\" e.g. \"Live and Let Die\"\n" +
                    "13.Convert first character of each word in upper case.\n" +
                    "14.List 'month names' from the above list e.g. January, February, etc.\n" +
                    "15. Exit\n");

                content = content.ToLower();

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:

                        //BlankSpaces(content);
                        commonFunction(content, ' ');
                        break;

                    case 2:

                        CountWords(content);
                        break;

                    case 3:

                        //int result = NumberOfStatement(content);
                        //Console.WriteLine(result);
                        commonFunction(content, '.');
                        break;

                    case 4:

                        //int ans = NumberOfStatement(content);
                        //Console.WriteLine(ans);
                        commonFunction(content, '.');
                        break;


                    case 5:

                        NumberOfDigit(content);
                        break;

                    case 6:

                        CountVowel(content);
                        break;

                    case 7:

                        PrepositionAndPosition(content);
                        break;

                    case 8:

                        CountAndPosition(",", content);
                        break;

                    case 9:

                        ReverseWord("my name is yash");
                        break;

                    case 10:

                        ReverseString("my name is yash");
                        break;

                    case 11:


                        printStatements(content);
                        break;

                    case 12:

                        foreach (Match match in Regex.Matches(content, "\"([^\"]*)\""))
                            Console.WriteLine(match.ToString());
                        break;

                    case 13:

                        upperCase(content);
                        break;

                    case 14:

                        findMonths(content);
                        break;

                    case 15:

                        continueOperation = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (continueOperation);
        }

        static void BlankSpaces(string content)
        {
            int count = 0;
            foreach (char c in content)
            {
                if (c == ' ')
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        static void CountWords( string content)
        {
            int word = 0;
            foreach (char c in content)
            {
                if (c == ' ' || c == ',' || c == '.')
                {
                    word++;
                }
            }
            Console.WriteLine(word);
        }

        static int NumberOfStatement(string content)
        {
            int statements = 0;
            foreach (char c in content)
            {
                if (c == '.')
                {
                    statements++;
                }
            }
            return statements;
        }

        static void NumberOfDigit(string content)
        {
            int digit = 0;
            foreach (char c in content)
            {
                if (char.IsDigit(c))
                {
                    digit++;
                }
            }
            Console.WriteLine(digit);
        }

        static void CountVowel(string content)
        {
            int countVowel = 0;
            foreach (char c in content)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    countVowel++;
                }

            }
            Console.WriteLine(countVowel);
        }

        static void PrepositionAndPosition(string content)
        {
            int countNumber = 0;
            string[] sample = { "the", "is", "to", "and" };
            ArrayList index = new ArrayList();

            
            foreach (string item in sample)
            {

                for (int i = content.IndexOf(item); i >= 0; i = content.IndexOf(item, i + 1))
                {
                    countNumber++;
                    index.Add(i);
                }

                Console.WriteLine($"count of '{item}' in string is {countNumber} and the index position are as follows");
                
                foreach (int element in index)
                {
                    Console.WriteLine(element);
                }
                index.Clear();
            }
        }
       
        static void CountAndPosition(string find ,string content)
        {
            int countNumber = 0;
            ArrayList index = new ArrayList();
            for (int i = content.IndexOf(find); i >= 0; i = content.IndexOf(find, i + 1))
            {
                countNumber++;
                index.Add(i);
            }
            Console.WriteLine($"count of '{find}' in string is {countNumber} and the index position are as follows");

            foreach (int element in index)
            {
                Console.WriteLine(element);
            }
        }

        static void ReverseWord(string content)
        {
            string[] words = content.Split();
            ArrayList str  = new ArrayList();
            foreach (string word in words)
            {
                int len = word.Length;
                string temp = string.Empty;
                for(int i =word.Length-1; i>=0; i--)
                {
                    temp += word[i];
                }
                str.Add(temp);
            }
            foreach (string element in str)
            {
                Console.Write(element + " ");
            }
        }

        static void ReverseString(string content)
        {
            string reverse = String.Empty;
            for (int i = content.Length - 1; i >= 0; i--)
            {
                reverse += content[i];
            }

            Console.WriteLine(reverse);
        }

        static void printStatements( string content)
        {
            string[] substrings = content.Split(".");
            foreach(string substring in substrings)
            {
                Console.WriteLine(substring);
                Console.WriteLine("\n");
            }
        }

        static void upperCase(string content)
        {
            string[] words = content.Split(' ');
            foreach(string word in words)
            {
                Console.Write(char.ToUpper(word[0]) + word.Substring(1) + " ");
                
            }
        }

        static void findMonths(string content)
        {
            string[] months = { "january", "february", "march", "april", "may", "june", "july", "august","september", "october", "november","december" };
            foreach(string month in months)
            {
                if (content.Contains(month))
                {
                    Console.WriteLine(month);
                }
            }

        }

        static void commonFunction(string content , char character)
        {
            int count = 0;
            foreach (char c in content)
            {
                if (c == character)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }

}
