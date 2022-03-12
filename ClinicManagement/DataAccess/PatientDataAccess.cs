using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ClinicManagement.DataAccess
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
            try
            {
                string PatientName, PatientMobileNumber, Address, bp, Cholestrol, diabetic, med;
                DateTime ApDate;
                int PatientAge;
                double weight, height;
                bool isName = true, isNumber = true, isAge = true, isWeight = true, isHeight = true, isBloodPressure = true, isChoslestrol = true, isSugar = true, isDate = true;
                do
                {

                    Console.WriteLine("Enter Patient's Name");
                    PatientName = Console.ReadLine();
                    string regex = @"^[A-Z][a-z]";
                    Regex rx = new Regex(regex);
                    if (rx.IsMatch(PatientName))
                    {
                        isName = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Name");
                    }
                } while (isName == true);

                do
                {
                    Console.WriteLine("Enter Mobile Number");
                    PatientMobileNumber = Console.ReadLine();
                    if (PatientMobileNumber.Length == 10)
                    {
                        isNumber = false;
                    }
                } while (isNumber == true);

                do
                {
                    Console.WriteLine("Enter Patient's Age");
                    PatientAge = Convert.ToInt32(Console.ReadLine());
                    if (PatientAge > 0)
                    {
                        isAge = false;
                    }
                    else
                    {
                        Console.WriteLine("Age cannot be negative\n");
                    }
                } while (isAge == true);



                Console.WriteLine("Enter Address");
                Address = Console.ReadLine();


                do
                {
                    Console.WriteLine("Enter weight ");
                    weight = Convert.ToDouble(Console.ReadLine());
                    if (weight > 0)
                    {
                        isWeight = false;
                    }
                    else
                    {
                        Console.WriteLine("Weight cannot be negative\n");
                    }

                } while (isWeight == true);


                do
                {
                    Console.WriteLine("Enter height ");
                    height = Convert.ToDouble(Console.ReadLine());
                    if (height > 0)
                    {
                        isHeight = false;
                    }
                    else
                    {
                        Console.WriteLine("height cannot be negative\n");
                    }

                } while (isHeight == true);

                do
                {
                    Console.WriteLine("Patients BP (high / low / Normal)");
                    bp = Console.ReadLine().ToLower();
                    if (bp == "high" || bp == "low" || bp == "normal")
                    {
                        isBloodPressure = false;
                    }
                    else
                    {
                        Console.WriteLine("Blood Pressure can be high,low,normal\n");
                    }

                } while (isBloodPressure == true);


                do
                {
                    Console.WriteLine("Patients Cholestrol (CDL / HDL)");
                    Cholestrol = Console.ReadLine().ToUpper();
                    if (Cholestrol == "CDL" || Cholestrol == "HDL")
                    {
                        isChoslestrol = false;
                    }
                    else
                    {
                        Console.WriteLine("Cholestrol can either be HDL or CDL\n");
                    }

                } while (isChoslestrol == true);

                do
                {
                    Console.WriteLine("is patient diabetic (Yes or No)");
                    diabetic = Console.ReadLine().ToLower();
                    if (diabetic == "yes" || diabetic == "no")
                    {
                        isSugar = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter yes or no");
                    }
                } while (isSugar == true);


                Console.WriteLine("Medicine referred");
                med = Console.ReadLine();


                Console.WriteLine("next Appointment Date (Enter in format yyyy-mm-dd)");
                ApDate = Convert.ToDateTime(Console.ReadLine());



                PatientInfo patientInfo = new PatientInfo()
                {
                    PatientName = PatientName,
                    MobileNumber = PatientMobileNumber,
                    PatientAddress = Address,
                    Age = PatientAge
                };

                await ctx.PatientInfos.AddAsync(patientInfo);
                await ctx.SaveChangesAsync();



                Record record = new Record()
                {
                    PatientId = patientInfo.PatientId,
                    PatientName = PatientName,
                    PatientWeight = weight,
                    PatientHeight = height,
                    BloodPressure = bp,
                    Cholestrol = Cholestrol,
                    Sugar = diabetic,
                    MedicineSubscribed = med,
                    AppointmentDate = ApDate
                };
                await ctx.Records.AddAsync(record);
                await ctx.SaveChangesAsync();
                Console.WriteLine("Patient Registered successfully\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occured {ex.Message}");
                throw;
            }
            
        }

         public void operatePatient()
        {
            try
            {
                var showPatientList = ctx.PatientInfos.ToListAsync();
                foreach (var patient in showPatientList.Result)
                {
                    Console.WriteLine($"{patient.PatientId} {patient.PatientName} {patient.Age}");
                }







                Console.WriteLine("Enter the id of the patient you want to operate");
                int pId = Convert.ToInt32(Console.ReadLine());
                var patientFind = ctx.Records.Where(x => x.PatientId == pId).FirstOrDefault();


                if (patientFind.PatientId == pId)
                {
                    Console.WriteLine("Patient found\n");
                    Console.WriteLine($"currently operating on patient {patientFind.PatientId} {patientFind.PatientName}\n");
                    bool isOperating = true;
                    Record record = new Record()
                    {
                        PatientId = patientFind.PatientId,
                        PatientName = patientFind.PatientName,
                        PatientWeight = patientFind.PatientWeight,
                        PatientHeight = patientFind.PatientHeight,
                        BloodPressure = patientFind.BloodPressure,
                        Cholestrol = patientFind.Cholestrol,
                        Sugar = patientFind.Sugar,
                        MedicineSubscribed = patientFind.MedicineSubscribed,
                        AppointmentDate = patientFind.AppointmentDate
                    };
                    do
                    {

                        Console.WriteLine($"what you want to update in records\n" +
                                      $"1. Weight\n" +
                                      $"2. Height\n" +
                                      $"3. Blood Pressure\n" +
                                      $"4. Sugar\n" +
                                      $"5. Medicine Subscribed\n" +
                                      $"6. Appointment Date\n" +
                                      $"7. Done\n");
                        int updateInput = Convert.ToInt32(Console.ReadLine());
                        switch (updateInput)
                        {
                            case 1:
                                bool isUpdatedWeight = true;
                                do
                                {
                                    Console.WriteLine("Enter updated weight\n");
                                    double updatedWeight = Convert.ToDouble(Console.ReadLine());
                                    if (updatedWeight > 0)
                                    {
                                        record.PatientWeight = updatedWeight;
                                        isUpdatedWeight = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Weight Cannot be negative");
                                    }

                                } while (isUpdatedWeight == true);
                                break;

                            case 2:

                                bool isUpdatedHeight = true;

                                do
                                {
                                    Console.WriteLine("Enter updated Height\n");
                                    double updatedHeight = Convert.ToDouble(Console.ReadLine());
                                    if (updatedHeight > 0)
                                    {
                                        record.PatientHeight = updatedHeight;
                                        isUpdatedHeight = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Height cannot be negative");
                                    }
                                } while (isUpdatedHeight == true);
                                break;

                            case 3:
                                bool isBloodPressur = true;
                                do
                                {
                                    Console.WriteLine("Enter updated BloodPressure\n");
                                    string updatedBp = Console.ReadLine().ToLower();
                                    if (updatedBp == "high" || updatedBp == "low" || updatedBp == "normal")
                                    {
                                        record.BloodPressure = updatedBp;
                                        isBloodPressur = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("blood pressure can be high / low / normal\n");
                                    }
                                } while (isBloodPressur == true);
                                break;

                            case 4:

                                bool isUpdatedSugar = true;

                                do
                                {
                                    Console.WriteLine("Enter updated Sugar\n");
                                    string UpdatedSugar = Console.ReadLine().ToLower();
                                    if (UpdatedSugar == "yes" || UpdatedSugar == "no")
                                    {
                                        isUpdatedSugar = false;
                                        record.Sugar = UpdatedSugar;
                                    }
                                    else
                                    {
                                        Console.WriteLine("please enter yes or no");
                                    }
                                } while (isUpdatedSugar == true);
                                break;

                            case 5:

                                Console.WriteLine("Enter new Medicines given\n");
                                string UpdatedMed = Console.ReadLine();
                                record.MedicineSubscribed = UpdatedMed;
                                break;

                            case 6:

                                Console.WriteLine("Enter new appointment given\n");
                                string newAppointment = Console.ReadLine();
                                record.AppointmentDate = Convert.ToDateTime(newAppointment);
                                break;

                            case 7:

                                isOperating = false;
                                break;
                            default:

                                Console.WriteLine("Enter Valid choice");
                                break;

                        }

                    } while (isOperating == true);

                    ctx.Records.AddAsync(record);
                    ctx.SaveChangesAsync();
                    bill(record);
                }
                else
                {
                    Console.WriteLine("Patient Not Found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured {ex.Message}");
                throw;
            }
        }

        public void viewPatient()
        {
            var showPatientList = ctx.PatientInfos.ToListAsync();
            foreach (var patient in showPatientList.Result)
            {
                Console.WriteLine($"{patient.PatientId} {patient.PatientName} {patient.Age}");
            }
            Console.WriteLine("Enter patients name whose records you want to find");
            string recordHistory = Console.ReadLine();
            var view =  ctx.Records.Where(x=>x.PatientName == recordHistory).Where(y=>y.PatientName == recordHistory);
            
            if (view.Count() == 0)
            {
                Console.WriteLine("Patient does not exist");
            }
            else
            {
                foreach (var record in view)
                {
                    Console.WriteLine($"{record.PatientId} {record.PatientName} {record.PatientWeight} {record.PatientHeight} {record.BloodPressure} {record.Cholestrol} {record.Sugar} {record.MedicineSubscribed}");
                }
            }
        }

        public void bill(Record patient)
        {
            Console.WriteLine("Is this Patient's first time visiting? (Yes/No)\n");
            string visiting = Console.ReadLine().ToLower();
            int VisitingCharge = 0;
            if (visiting == "yes")
            {
                Console.WriteLine("1000/- would be charged since it's patient's first visit\n");
                VisitingCharge = 1000;
            }
            else
            {
                Console.WriteLine("850/- will be charged");
                VisitingCharge = 850;
            }
            PatientBill billing = new PatientBill()
            {
                PatientId = patient.PatientId,
                Fees = VisitingCharge
            };
           var fee = ctx.PatientBills.AddAsync(billing);
            ctx.SaveChangesAsync();
        }

        public void dailyCollection()
        {
          
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            var totalCollection = ctx.PatientBills.Where(x => x.Currentdate == dateTime).Sum(x=>x.Fees);
            Console.WriteLine($"Total collection for today was Rs{totalCollection}/-");
        }
    }
}
