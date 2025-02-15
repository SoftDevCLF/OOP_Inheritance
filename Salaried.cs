using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Inheritance
{
    //Salaried class derived from the Employee class
    public class Salaried: Employee
    {
        //Property for the salary of the employee
        public double Salary { get; set; }

        //Constructor for the Salaried class, adding the properties of the class, referencing the base class Employee and adding the salary property
        public Salaried(string id, string name, string address, string phone, long sin, string birthdate, string departmentName, double salary) : base(id, name, address, phone, sin, birthdate, departmentName)
        {
            Salary = salary;
                     
        }

        //Overriding the CalculateWeeklyPay method from the Employee class.
        public override double CalculateWeeklyPay()
        {
            //Returns only the salary of the employee, because the salary is the same every week.
            return Salary;
        }
    }
}
