using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Inheritance
{
    //Part Time class derived to the Employee class
    public class PartTime: Employee
    {
        //Properties for the rate and hours of the employee
        public double HourlyRate { get; set; }
        public double WorkHours { get; set; }

        //Constructor for the PartTime class, adding the properties of the class, referencing the base class Employee and adding the rate and hours properties
        public PartTime(string id, string name, string address, string phone, long sin, string birthdate, string departmentName, double hourlyRate, double workHours) : base(id, name, address, phone, sin, birthdate, departmentName)
        {
            HourlyRate = hourlyRate;
            WorkHours = workHours;
        }

        //Overriding the CalculateWeeklyPay method from the Employee class.
        public override double CalculateWeeklyPay()
        {
            //Returns the rate multiplied by the hours worked by the employee, according to the rule: rate:(hourly_rate * work_hours) No overtime
            double partTimeWeeklyPay = HourlyRate * WorkHours;
            return partTimeWeeklyPay;
        }
    }
}
