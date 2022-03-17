// See https://aka.ms/new-console-template for more information


using ClinicManagementUpdated.DataAccess;

PatientDataAccess data = new PatientDataAccess();


bool exit = false;
Console.WriteLine("Hello, Welcome Doctor!!\n" +
                  "what you want to do today");
do
{
    Console.WriteLine("1.Register New Patient\n" +
                      "2.Operate on Patient\n" +
                      "3.View existing Patient record\n" +
                      "4.Today's Collection report\n" +
                      "5.ClearScreen\n" +
                      "6.Exit\n");
    int doctorInput = Convert.ToInt32(Console.ReadLine());

    switch (doctorInput)
    {
        case 1:

            data.registerNewPatient();
            break;


        case 2:
            

            data.operatePatient();
            break;

        case 3:

            Console.WriteLine("Enter the id of patient whose record you want to check");
            int viewId = Convert.ToInt32(Console.ReadLine());
            data.viewRecord(viewId);
            break;

        case 4:

            data.dailyCollection();
            break;

        case 5:

            Console.Clear();
            break;

        case 6:

            exit = true;
            break;

        default:

            Console.WriteLine("Invalid Choice Doctor....TRY AGAIN!\n");
            break;
    }



} while (exit == false);