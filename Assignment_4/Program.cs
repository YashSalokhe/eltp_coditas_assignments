using System;

namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

           MathClass m = new MathClass();
            MathClass m1 = new MathClass(); 
            MathClass m2 = new MathClass();





            Console.WriteLine("Enter num1");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter num2");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"The addition of the numbers {num1} , {num2} is {m.addNumber(num1, num2)} \n");

            Console.WriteLine($"{num1} raised to {num2} is {m.GetPower(num1, num2)} \n");

            Console.WriteLine($"Factorial of {num1} is {m.Factorial(num1)}\n");
            Console.WriteLine($"Factorial of {num2} is {m.Factorial(num2)}\n");

            Console.WriteLine($"CubeRoot of {num1} is {m.CubeRoot(num1)}");
            Console.WriteLine($"CubeRoot of {num2} is {m.CubeRoot(num2)}");

            string str = "James Bond is a fictional character created by novelist Ian Fleming in 1953. A British secret agent working for MI6 under the codename 007, he has been portrayed on film by actors Sean Connery, David Niven, George Lazenby, Roger Moore, Timothy Dalton, Pierce Brosnan and Daniel Craig in twenty-seven productions. All but two films were made by Eon Productions, which now holds the adaptation rights to all of Fleming\'s Bond novels.[1][2]In 1961, producers Albert R.Broccoli and Harry Saltzman purchased the filming rights to Fleming\'s novels.[3] They founded Eon Productions and, with financial backing by United Artists, produced Dr. No, directed by Terence Young and featuring Connery as Bond.[4] Following its release in 1962, Broccoli and Saltzman created the holding company Danjaq to ensure future productions in the James Bond film series.[5] The series currently has twenty-five films, with the most recent, No Time to Die, released in September 2021. With a combined gross of nearly $7 billion to date, it is the fifth-highest-grossing film series.[6] Accounting for inflation, it has earned over $14 billion at current prices.[a] The films have won five Academy Awards: for Sound Effects (now Sound Editing) in Goldfinger (at the 37th Awards), to John Stears for Visual Effects in Thunderball (at the 38th Awards), to Per Hallberg and Karen Baker Landers for Sound Editing, to Adele and Paul Epworth for Original Song in Skyfall (at the 85th Awards) and to Sam Smith and Jimmy Napes for Original Song in Spectre (at the 88th Awards). Several of the songs produced for the films have been nominated for Academy Awards for Original Song, including Paul McCartney's \"Live and Let Die\", Carly Simon\'s \"Nobody Does It Better\" and Sheena Easton\'s \"For Your Eyes Only\".In 1982 Albert R. Broccoli received the Irving G.Thalberg Memorial Award.[8]";
            Console.WriteLine($"The number of statements in string are {str.NumberOfStatements()}");
        }   
    }

    //Sealed Class
    public sealed class MathClass
    {
        static MathClass()
        {
            Console.WriteLine("in Constructor of Math Class");
        }
        public int addNumber(int x , int y)
        {
            return x+ y;
        }
    }


    //Extension 
    public static class MyExtensionForMathClass
    {

        public static int GetPower(this MathClass m, int x ,int y)
        {
            int power = 1;

            for(int i = 0; i < y; i++)
            {
                power = power * x;
            }
            return power ;
        }

        public static int Factorial(this MathClass m ,int x)
        {
            int fact = 1,i;
            for (i = 1; i <= x; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        public static double CubeRoot(this MathClass m , int x)
        {
            double CRoot;
            CRoot = Math.Pow(x, (1.0 / 3.0));
            return CRoot;
        }

        

    }

    public static class MyExtensionForStringClass
    {
        public static int NumberOfStatements(this string s)
        {
            int count = 0;
            foreach(char c in s)
            {
                if (c == '.')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
