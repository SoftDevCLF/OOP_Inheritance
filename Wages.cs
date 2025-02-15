using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_2_Inheritance
{
    //Wages class derived from the Employee class
    public class Wages : Employee
    {
        //Properties for the hourly rate and work hours of the employee
        public double HourlyRate { get; set; }
        public double WorkHours { get; set; }

        //Constructor for the Wages class, adding the properties of the class, referencing the base class Employee and adding the hourly rate and work hours properties
        public Wages(string id, string name, string address, string phone, long sin, string birthdate, string departmentName, double hourlyRate, double workHours) : base(id, name, address, phone, sin, birthdate, departmentName) 
        {
            HourlyRate = hourlyRate;
            WorkHours = workHours;

        }

        //Overriding the CalculateWeeklyPay method from the Employee class.
        public override double CalculateWeeklyPay()
        {
            //Returns the rate multiplied by the hours worked by the employee, according to the rule: (hourly_rate * work_hours) overtime paid at time and a half for any hours worked over 40 in one week
            //If the work hours are less than or equal to 40, the employee will be paid the regular rate
            if (WorkHours <= 40)
            {
                double wagesWeeklyPay = HourlyRate * WorkHours;
                return wagesWeeklyPay;
            }
            // If work hours are more than 40, the employee is paid at regular rate for the first 40 hours and time and a half for the overtime hours
            else
            {
                double wagesWeeklyPay = (HourlyRate * 40) + ((WorkHours - 40) * (HourlyRate * 1.5));
                return wagesWeeklyPay;
            }
        }
    }
}
