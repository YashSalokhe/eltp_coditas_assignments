using System;
using Assignment_6.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
namespace Assignment_6
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Employees emp = new Employees();
            FileOperations fileOperations = new FileOperations();
            //  calculateTax(emp);
             Task.Factory.StartNew(() => calculateTax(emp))
                .ContinueWith(delegate { moveFile(); });
            Console.ReadLine();
            
        }

        static void calculateTax(IEnumerable<Employee> emps)
        {
            FileOperations file = new FileOperations();
            var taxGroup = from e in emps
                           group e by e.Designation into desig
                           select new
                           {
                               Designation = desig.Key,
                               Records = desig.ToList()
                           };

            //var startTimerNonParallel = Stopwatch.StartNew();

            //foreach (var item in taxGroup)
            //{
            //    foreach (var record in item.Records)
            //    {
            //        double HRA = 0;
            //        double TS = 0;
            //        double DA = 0;
            //        double gross = 0;
            //        double tax = 0;
            //        int netSalary = 0;
            //        if (record.Designation == "Manager")
            //        {
            //            HRA = (record.Salary * 10) / 100;
            //            TS = (record.Salary * 15) / 100;
            //            DA = (record.Salary * 20) / 100;

            //        }
            //        else if (record.Designation == "Director")
            //        {
            //            HRA = (record.Salary * 20) / 100;
            //            TS = (record.Salary * 30) / 100;
            //            DA = (record.Salary * 40) / 100;
            //        }

            //        gross = record.Salary + HRA + TS + DA;


            //        if (gross >= 500000 && gross <= 1000000)
            //        {
            //            tax = (gross * 20) / 100;
            //        }
            //        else if (gross >= 1000000 && gross <= 2000000)
            //        {
            //            tax = (gross * 25) / 100;
            //        }
            //        else if (gross > 2000000)
            //        {
            //            tax = (gross * 30) / 100;
            //        }

            //        netSalary = (int)(gross - tax);

            //        file.fileCreate(record, HRA, TS, DA, gross, tax, netSalary);
            //    }
            //}
            //Console.WriteLine($"Non-Parallel Process completed at {DateTime.Now}" +
            //  $"Total Time {startTimerNonParallel.Elapsed.TotalSeconds}");

            //------------------------------PARALLEL----------------------------------------------

            var startTimerParallel = Stopwatch.StartNew();
            //Parallel.ForEach(taxGroup, t =>
            //{
            //   foreach(var record in t.Records)
            //    {
            //        double HRA = 0;
            //        double TS = 0;
            //        double DA = 0;
            //        double gross = 0;
            //        double tax = 0;
            //        int netSalary = 0;
            //        if (record.Designation == "Manager")
            //        {
            //            HRA = (record.Salary * 10) / 100;
            //            TS = (record.Salary * 15) / 100;
            //            DA = (record.Salary * 20) / 100;

            //        }
            //        else if (record.Designation == "Director")
            //        {
            //            HRA = (record.Salary * 20) / 100;
            //            TS = (record.Salary * 30) / 100;
            //            DA = (record.Salary * 40) / 100;
            //        }

            //        gross = record.Salary + HRA + TS + DA;


            //        if (gross >= 500000 && gross <= 1000000)
            //        {
            //            tax = (gross * 20) / 100;
            //        }
            //        else if (gross >= 1000000 && gross <= 2000000)
            //        {
            //            tax = (gross * 25) / 100;
            //        }
            //        else if (gross > 2000000)
            //        {
            //            tax = (gross * 30) / 100;
            //        }
            //        Console.WriteLine($"Parallel Tax for Employee {record.EmpNo} ");
            //        netSalary = (int)(gross - tax);

            //        file.fileCreate(record, HRA, TS, DA, gross, tax, netSalary);
            //    }

            //});
            //Console.WriteLine($"Parallel Process completed at {DateTime.Now}" +
            //  $"Total Time {startTimerParallel.Elapsed.TotalSeconds}");



            //------------------OR----------------------------


            Parallel.ForEach(taxGroup, t =>
            {
                Parallel.ForEach(t.Records, t =>
                {
                    double HRA = 0;
                    double TS = 0;
                    double DA = 0;
                    double gross = 0;
                    double tax = 0;
                    int netSalary = 0;

                    if (t.Designation == "Manager")
                    {
                        HRA = (t.Salary * 10) / 100;
                        TS = (t.Salary * 15) / 100;
                        DA = (t.Salary * 20) / 100;

                    }
                    else if (t.Designation == "Director")
                    {
                        HRA = (t.Salary * 20) / 100;
                        TS = (t.Salary * 30) / 100;
                        DA = (t.Salary * 40) / 100;
                    }

                    gross = t.Salary + HRA + TS + DA;


                    if (gross >= 500000 && gross <= 1000000)
                    {
                        tax = (gross * 20) / 100;
                    }
                    else if (gross >= 1000000 && gross <= 2000000)
                    {
                        tax = (gross * 25) / 100;
                    }
                    else if (gross > 2000000)
                    {
                        tax = (gross * 30) / 100;
                    }
                    Console.WriteLine($"Parallel Tax for Employee {t.EmpNo} ");
                    netSalary = (int)(gross - tax);
                    items item = new items()
                    {
                        HRA = HRA,
                    TS = TS,
                    DA = DA,
                    gross = gross,
                    tax = tax,
                    netSalary = netSalary
                    };
                    //Parallel.Invoke(() =>
                    //{
                        file.fileCreate(t,item);
                    //});
                });

            });
            Console.WriteLine($"Parallel Process completed at {DateTime.Now}" +
              $"Total Time {startTimerParallel.Elapsed.TotalSeconds}");

        }

        static public void moveFile()
        {

            string sourcePath = @"C:\Users\Coditas\source\repos\ELTP_DotNET\Assignment_6\SalarySlipSerialize";
            string targetPath = @"C:\Users\Coditas\source\repos\ELTP_DotNET\Assignment_6\movedSlip";

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    string fileName = System.IO.Path.GetFileName(s);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    //string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                    //string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
                Console.WriteLine("Files moved");
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }



    }
}
