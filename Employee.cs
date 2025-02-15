using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Inheritance
{
    public class Employee
    {
        //Properties of the Employee class with getters and setters
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        //SIN is set as private because it should not be accessed outside the class, it is sensitive information
        private long Sin { get; set; }
        public string BirthDate { get; set; }

        public string DepartmentName { get; set; }

        //Constructor for the Employee class, adding the properties of the class
        public Employee( string id, string name, string address, string phone, long sin, string birthdate, string departmentName) 
        { 
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            BirthDate = birthdate;
            DepartmentName = departmentName;

        }

        //Virtual method to calculate the weekly pay of the employee, it will be overridden in the derived classes depending on the type of employee
        public virtual double CalculateWeeklyPay()
        {
            //Set to 0 as a placeholder.
            return 0 ;
        }
    }
}
