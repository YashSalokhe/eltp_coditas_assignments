using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Assignment_10.Models;
using Assignment_10.Operations;

namespace Assignment_10
{
    internal class Program
    {
        static void Main(string[] args)
        {   Employee emp = new Employee();
            StoreData storeData = new StoreData();
            emp = storeData.GetData();

            //Thread t1 = new Thread(() => storeData.WriteDataToFile(emp));
            //Thread t2 = new Thread(() => storeData.WriteDataToDB(emp));
            // Thread t3 = new Thread(() => storeData.readFromDataBase());
            // Thread t4 = new Thread(() => storeData.readFromFile());
            // 3. start thread
            //t1.Start();
            //t2.Start();
            //t3.Start();
            //t4.Start();
            //storeData.readFromDataBase();
            //storeData.readFromFile();

            Parallel.Invoke(() =>
            {
                storeData.WriteDataToFile(emp);
                storeData.readFromDataBase();
                storeData.readFromFile();
            });
            Console.ReadLine();
        }
    }
}
