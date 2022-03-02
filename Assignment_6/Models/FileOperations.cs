using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Assignment_6.Models
{
    internal class FileOperations
    {
        public void fileCreate(Employee emp,double HRA , double TA ,double DA,double gross , double tax , int netSalary)
        {
            DateTime date = DateTime.Now;
            string path = @"C:\Users\Coditas\source\repos\ELTP_DotNET\Assignment_6\SalarySlip";
            string filePath = $"{path}\\Salary-for-{date.ToString("Y")}-{emp.EmpNo}.txt";
            if (File.Exists(filePath))
            {

                Console.WriteLine($"Specified File {filePath} is Already exists");
            }
            else
            {
                //Create a File

                writeData(filePath, emp, HRA, TA, DA, gross, tax, netSalary);
            }
        }

    

        public void writeData(string filePath,Employee emp, double HRA, double TA,double DA, double gross, double tax, int netSalary)
        {

            string NetSalaryWords = ConvertWholeNumber(netSalary.ToString());
            FileStream fs = File.Create(filePath);
            BinaryFormatter formatter = new BinaryFormatter();
            byte[] content = new UTF8Encoding(true).GetBytes(
                           $"-------------------------Salary Slip--------------------------\n" +
                           $"| EmpNo: {emp.EmpNo}            EmpName: {emp.EmpName}       |\n" +
                           $"| DeptName: {emp.DeptName}   Designation: {emp.Designation}  |\n" +
                           $"|____________________________________________________________|\n" +
                           $"|Income (Rs.)                  | Deduction (Rs.)             |\n" +
                           $"|------------------------------------------------------------|\n" +
                           $"|Basic Salary: {emp.Salary}    |                             |\n" +
                           $"|HRA: {HRA}                    |                             |\n" +
                           $"|TA: {TA}                      |                             |\n" +
                           $"|DA: {DA}                      |                             |\n" +
                           $"|------------------------------------------------------------|\n" +
                           $"|Gross: {gross}                |                             |\n" +
                           $"|------------------------------------------------------------|\n" +
                           $"|                              | Tax: {tax}                  |\n" +
                            $"|------------------------------------------------------------|\n" +
                           $"|NetSalary: {netSalary}        |                             |\n" +
                           $"|------------------------------------------------------------|\n" +
                           $"|NetSalary in Words:{NetSalaryWords} only                    |\n" +
                           $"--------------------------------------------------------------");
           // formatter.Serialize(fs, content);

            fs.Write(content, 0, content.Length);
            fs.Close();



        }

        public String ConvertWholeNumber(string Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX    
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))    
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping    
                    String place = "";//digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range    
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range    
                        case 5:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 6:
                            
                        case 7://Lakh's range    
                            pos = (numDigits % 6) + 1;
                            place = " Lakh ";
                            break;
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Crore ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...    
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)    
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }
                    //ignore digit grouping names    
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        public String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        public String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
    }
}

