using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Assignment_7
{
    internal class DirectoryOperations
    {
        public void CreateDirectoiry(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            else
            {
                Console.WriteLine($"Directory {dirName} is already present");
            }
        }

        public List<string> storeFile(string dirName)
        {
            List<string> filesStore = new List<string>();

            var files = from file in Directory.GetFiles(dirName, "*.txt", SearchOption.AllDirectories)
                        select file.Substring(66);
            //stor = files;
            foreach (var file in files)
            {
                //Console.WriteLine(file);
                filesStore.Add(file);
            }
            return filesStore;
        }

        public void ReadFromFile(string dirName , string userInput )
        {
            string filepath = $"{dirName}\\{userInput}";
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            sr.Close();
            Console.WriteLine(line);
            fs.Close();

        }
   
        public void printFile(List<string>filestore)
        {
            foreach (var file in filestore) Console.WriteLine(file);

        }

        public void ReadFromFileSingle(string dirName, string userInput)
        {
            string filepath = $"{dirName}\\{userInput}";
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            sr.Close();
            Console.WriteLine(line);
            fs.Close();

        }

        public void ReadFromUserInput(string dirName, string userInput)
        {
            Console.WriteLine("Enter the line number");
            int lineInput = int.Parse(Console.ReadLine());
            string filepath = $"{dirName}\\{userInput}";
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            
           // string line = File.ReadLines().Skip(lineInput - 1).Take(1).FirstOrDefault();
            sr.Close();
           // Console.WriteLine(line);
            fs.Close();

        }

        public void FileInfo(int EmployeeNo)
        {
            string filePath = $@"C:\Users\Coditas\source\repos\ELTP_DotNET\Assignment_6\SalarySlip\Salary-for-February 2022-{EmployeeNo}.txt";
            FileInfo fileInfo = new FileInfo(filePath);
            Console.WriteLine($"FileName = {fileInfo.Name}  |  Extension = {fileInfo.Extension}  |  Size = {fileInfo.Length} Bytes  |  Last Modified on {fileInfo.LastWriteTime} ");
        }
    }
}