
using ClinicManagementUpdated.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClinicManagementUpdated.DataAccess
{

    public class PatientDataAccess
    {
        ClinicContext ctx;
        public PatientDataAccess()
        {
            ctx = new ClinicContext();
        }
        async public void registerNewPatient()
        {
       

            Console.WriteLine("Enter Patient's Name\n");
            string PatientName = Console.ReadLine();


            Console.WriteLine("Enter Mobile Number\n");
            string PatientMobileNumber = Console.ReadLine();


            Console.WriteLine("Enter Patient's Age");
            int PatientAge = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Enter Address\n");
            string? Address = Console.ReadLine();


            Console.WriteLine("Enter weight ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter height ");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Patients BP\n");
            string? bp = Console.ReadLine();

            Console.WriteLine("Patients Cholestrol\n");
            string? Cholestrol = Console.ReadLine();

            Console.WriteLine("is patient diabetic (Yes or No)\n");
            string? diabetic = Console.ReadLine();

            Console.WriteLine("Medicine referred\n");
            string? med = Console.ReadLine();

            Console.WriteLine("next Appointment Date\n");
            DateTime ApDate = Convert.ToDateTime( Console.ReadLine());


            PatientInfoUpdated patient = new PatientInfoUpdated()
            {
                PatientName = PatientName,
                MobileNumber = PatientMobileNumber,
                Age = PatientAge,
                PatientAddress = Address,
                PatientWeight = weight,
                PatientHeight = height,
                BloodPressure = bp,
                Cholestrol = Cholestrol,
                Sugar = diabetic,
                MedicineSubscribed = med,
                AppointmentDate = ApDate

            };

            var newPatient = await ctx.PatientInfoUpdateds.AddAsync(patient);
            await ctx.SaveChangesAsync();
        }

        async public void operatePatient()
        {

            Console.WriteLine("Enter the id of the patient you want to operate");
            int pId = Convert.ToInt32(Console.ReadLine());
            var patientFind = await ctx.PatientInfoUpdateds.FindAsync(pId);
            
           
           
           if(patientFind != null)
            {
                Console.WriteLine("Patient found\n");
                Console.WriteLine($"currently operating on patient {patientFind.PatientId} {patientFind.PatientName}\n");
                Console.WriteLine($"what you want to update in records\n" +
                                  $"1. Weight\n");
            }
            Console.WriteLine($"{patientFind.PatientId} {patientFind.PatientName} {patientFind.Age}");
        }
        async public void viewRecord(int id)
        {
            var p = await ctx.PatientInfoUpdateds.FindAsync(id);
            Console.WriteLine($"{p.PatientId} {p.PatientName} {p.Age}");
        }

        public void dailyCollection()
        {

        }
    }

}
