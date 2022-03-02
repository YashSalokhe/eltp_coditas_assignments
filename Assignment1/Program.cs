using System;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Taking input from the user
            Console.WriteLine("Enter number 1");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number 2");
            int num2 = int.Parse(Console.ReadLine());


            //method for addition
            //int sum = Add(num1, num2);
            //int Add(int x, int y)
            //{
            //    if (x <= 0 || y <= 0)
            //    {
            //        return 0;
            //    }
            //    return x + y;
            //}
            //Console.WriteLine("Addition of the two numbers is " + sum);


            //method for Subtraction
            //int Sub(int x,int y)
            //{
            //    if (x <= 0 || y <= 0)
            //    {
            //        return 0;
            //    }
            //    return x - y;
            //}
            //Console.WriteLine("Subtraction of the two numbers is  " + Sub(num1, num2));


            //method for Multiplication
            //int Mult(int x,int y)
            //{   
            //    if(x <= 0 || y <= 0)
            //    {
            //        return 0;
            //    }
            //    return x * y;
            //}
            //Console.WriteLine("Multiplication of the two numbers is " + Mult(num1, num2));


            //method for division
            //int Divide(int x,int y)
            //{
            //    if (y == 0)
            //    {
            //        return -1;
            //    }
            //    return x / y;
            //}
            //Console.WriteLine("Division of two numbers is " + Divide(num1, num2));


            //method for finding square
            //Console.WriteLine("Enter the number whose square you want to find\n");
            //int sq = int.Parse(Console.ReadLine());
            //int Square(int x)
            //{
            //    if (x <= 0)
            //    {
            //        return 0;
            //    }
            //    return x * x;
            //}
            //Console.WriteLine("Square of the number is " + Square(sq));


            Console.WriteLine("which operation you want to perform \nadd\nsub\nmult\ndiv");
            string st = Console.ReadLine();
            int ans = Process(num1,num2,st);
            Console.WriteLine(ans);


            Console.WriteLine("Angle for which you want to find trignometric sin,cos,tan (IN DEGREE)");
            double trignometricAngle = double.Parse(Console.ReadLine());

           //As Math class takes angle in radians we need to convert it 
            Trignometry((Math.PI / 180) * trignometricAngle);
            MathClass();
        }

        static int Process(int x, int y, string z)
        {
            if (x > 0 && y > 0)
            {
                switch (z)
                {
                    case "add":

                        return x + y;
                        
                    case "sub":
                        return x - y;
                        
                    case "mult":
                        return x* y;
                        
                    case "div":
                        return x / y;
                        
                    default:
                        Console.WriteLine("Invalid option selected");
                        break;

                }
               
                //if (z == "add")
                //{
                //    return x + y;
                //}

                //if (z == "sub")
                //{
                //    return x - y;
                //}

                //if (z == "mult")
                //{
                //    return x * y;
                //}

                //if (z == "div")
                //{
                    
                //    return x / y;
                //}

                
            }
            
           return 0;
        }

        static double Trignometry(double angle)
        {


            Console.WriteLine("Sine of the angle  is {0}",Math.Sin(angle));
            Console.WriteLine("Cosine of the angle is {0}", Math.Cos(angle));
            Console.WriteLine("Tangent of the angle is {0}", Math.Tan(angle));
            return 0;
        }

        static void MathClass() 
        {
            Console.WriteLine("The sqroot of 4 is {0}",Math.Sqrt(4));
            Console.WriteLine("The round off value for 3.77 is {0}",Math.Round(3.77));
            Console.WriteLine("The floor value of 0.8 is {0}",Math.Floor(0.8));
            Console.WriteLine("The absolute value of -40 is {0}",Math.Abs(-40));

        }
    }
}
