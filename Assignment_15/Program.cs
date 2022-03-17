// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");




List<object> objectlist = new List<object>()
{
    new List<string>{"Yash" , "Harsh" , "Mayur" , "Suyog" , "Onkar", "Sassy" , "Jahanavi" , "Shreya"},
    new List<char>{'a' , 'b','c','d','e','f','g','h','i'},
    new List<Employee> 
    {
        new Employee {EmpNo = 1 , EmpName = "Yash" , Designation = "Intern" , Salary = 9900},
        new Employee {EmpNo = 2 , EmpName = "Harsh" ,Designation ="Intern" , Salary = 11000},
        new Employee {EmpNo = 3 , EmpName = "Suyog" , Designation = "Manager" , Salary = 99000},
        new Employee {EmpNo = 4 , EmpName = "Mayur" ,Designation ="Lead" , Salary = 110020},
        new Employee {EmpNo = 5 , EmpName = "Onkar" , Designation = "Intern" , Salary = 19900},
        new Employee {EmpNo = 6 , EmpName = "Sasi" ,Designation ="Lead" , Salary = 110030},
        new Employee {EmpNo = 7 , EmpName = "Shreya" , Designation = "Lead" , Salary = 91900},
        new Employee {EmpNo = 8 , EmpName = "Jahanavi" ,Designation ="Manager" , Salary = 181000},
        new Employee {EmpNo = 9 , EmpName = "Jay" , Designation = "Intern" , Salary = 99003},
        new Employee {EmpNo = 10, EmpName = "Sahil" ,Designation ="Manager" , Salary = 110300},
    },
    new List<int>{10,20,30,40,50 },
    1.0,1.1,1.2,1.3,1.4,1.5,1.6,1.7,1.8,1.9,2.0,
    60,61,62,63,64,65,66,67,68,69,70,
    new List<DateTime>{
        new DateTime(2012,1,1),
        new DateTime(2013,1,1),
        new DateTime(2014,1,1),
        new DateTime(2015,1,1),
        new DateTime(2016,1,1),
        new DateTime(2017,1,1),
        new DateTime(2018,1,1),
        new DateTime(2019,1,1),
        new DateTime(2020,1,1),
        new DateTime(2021,1,1),
        new DateTime(2022,1,1),
    }
};

    



ProcessCollection( objectlist, out List<DateTime> listDateTime, out List<int> listInt ,out List<string> listString , out List<char> listChar, out List<double> listDouble , out List<Employee> listEmployees);


foreach (var date in listDateTime)
{
    Console.WriteLine(date);
}

foreach(var i in listInt)
{
    Console.WriteLine(i);
}

foreach(var str in listString)
{
    Console.WriteLine(str);
}

foreach (var ch in listChar)
{
    Console.WriteLine(ch);
}

foreach (var doub in listDouble)
{
    Console.WriteLine(doub);
    
}

foreach(var emp in listEmployees)
{
    Console.WriteLine($"{emp.EmpNo} {emp.EmpName} {emp.Designation} {emp.Salary}");
}



void ProcessCollection(List<object> values , out List<DateTime> listDateTime, out List<int> listInt, out List<string> listString, out List<char> listChar, out List<double> listDouble, out List<Employee> listEmployees)
{

    listDateTime = new List<DateTime>();
    listInt = new List<int>();
    listString = new List<string>();
    listChar = new List<char>();
    listDouble = new List<double>();
    listEmployees = new List<Employee>();
    foreach (object val in values)
    {
        switch (val)
        {
            case IEnumerable<int> intList:

                foreach (int i in intList)
                {
                    listInt.Add(i);
                }
                
                break;

            case IEnumerable<string> strList:
                foreach (var item in strList)
                {
                   listString.Add(item);
                }
             
                break;
            case string s:
                
                listString.Add(s);

                break;

            case IEnumerable<Employee> employees:

                foreach(Employee employee in employees)
                {
                    listEmployees.Add(employee);
                }
                Console.WriteLine("employee list");
                break;

            case char c:
                listChar.Add(c);
                break;

            case double d:
                listDouble.Add(d);
                break;

            case int i:
                listInt.Add(i);
                break;
            case IEnumerable<DateTime>  data:

                foreach (DateTime i in data)
                {
                    listDateTime.Add(i);
                }
                break;
            
            default:
                Console.WriteLine("Finally.....");
                break;
        }
    }


   }



public class Employee
{
    public int EmpNo { get; set; }

    public string EmpName { get; set; }

    public int Salary { get; set; }

    public string Designation { get; set; }


}

