using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Lab_2_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Open the file with the employees information using the path 
            string employeesFilePath = @"D:\C# Projects\Lab_2_Inheritance\res\employees.txt";

            //Create a list to store the employees
            List<Employee> employeesList = new List<Employee>();

            //Loop to read the lines of the file
            foreach (string line in File.ReadAllLines(employeesFilePath))
            {
                //Split the line by the colon to get the data of the employee
                string[] employeeData = line.Split(':');

                //Get the first character of the employee ID to determine the type of employee depending on the first digit of the ID.
                string employeeId = employeeData[0];

                //The method Contains is used to check if the first digit of the ID is in the string, if it is, it will create a new employee of that type.
                //According to the rule, salaried employees have ID numbers starting with 0–4.
                if ("01234".Contains(employeeId[0]))
                {
                    //Create a new Salaried employee and add it to the list of employees
                    employeesList.Add(new Salaried(employeeData[0], employeeData[1], employeeData[2], employeeData[3], long.Parse(employeeData[4]), (employeeData[5]), employeeData[6], double.Parse(employeeData[7])));
                }

                //Wage employee’s IDs start with 5–7  
                else if ("567".Contains(employeeId[0]))
                {
                    //Create a new Wage employee and add it to the list of employees
                    employeesList.Add(new Wages(employeeData[0], employeeData[1], employeeData[2], employeeData[3], long.Parse(employeeData[4]), (employeeData[5]), employeeData[6], double.Parse(employeeData[7]), double.Parse(employeeData[8])));
                }

                //Part-time employee’s IDs start with 8–9
                else if ("89".Contains(employeeId[0]))
                {
                    //Create a new Part-time employee and add it to the list of employees
                    employeesList.Add(new PartTime(employeeData[0], employeeData[1], employeeData[2], employeeData[3], long.Parse(employeeData[4]), (employeeData[5]), employeeData[6], double.Parse(employeeData[7]), double.Parse(employeeData[8])));
                }

            }


            averageWeeklyPay(employeesList);

            wagesHighestPaid(employeesList);

            salaryLowestPaid(employeesList);

            percentagePerCategory(employeesList);

        }

        //Method to calculate the average weekly pay of all employees
        static void averageWeeklyPay(List<Employee> employees)
        {
            //Start the average at 0
            double average = 0;

            //Loop through the list of employees and add the weekly pay of each employee to the average
            foreach (Employee employee in employees)
            {
                //Call the CalculateWeeklyPay method to get the weekly pay of the employee
                average += employee.CalculateWeeklyPay();
            }

            //Calculate the average by dividing the total weekly pay by the number of employees
            double weeklyAverage = average / employees.Count;

            //Print the average weekly pay of all employees
            Console.WriteLine($"The average weekly pay for all employees is ${weeklyAverage:N2}.");
        }

        //Method to find the highest paid wage employee
        static void wagesHighestPaid(List<Employee> employees)
        {
            //Set the highest pay to 0 and the highest paid employee to an empty string
            double highestPay = 0;
            string highestPaidEmployee = "";

            //For each employee in the list of employees, if the employee is a wage employee, calculate the weekly pay
            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    double weeklyPay = employee.CalculateWeeklyPay();

                    //If the weekly pay is higher than the highest pay, set the highest pay as the weekly pay and the highest paid employee as the name of the employee
                    if (weeklyPay > highestPay)
                    {
                        highestPay = weeklyPay;
                        highestPaidEmployee = employee.Name;
                    }
                }
            }

            //Print the highest paid wage employee and the amount they make every week
            Console.WriteLine($"{highestPaidEmployee} is the highest paid wage employee, making ${highestPay:N2} every week.");

        }

        //Method to find the lowest paid salary employee
        static void salaryLowestPaid(List<Employee> employees)
        {
            //Set the lowest pay to the maximum value of a double and the lowest paid employee to an empty string
            double lowestPay = double.MaxValue;
            string lowestPaidEmployee = "";

            //For each employee in the list of employees, if the employee is a salaried employee, calculate the weekly pay
            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    double weeklyPay = employee.CalculateWeeklyPay();

                    //If the weekly pay is lower than the lowest pay, set the lowest pay as the weekly pay and the lowest paid employee as the name of the employee
                    if (weeklyPay < lowestPay)
                    {
                        lowestPay = weeklyPay;
                        lowestPaidEmployee = employee.Name;
                    }
                }
            }
            //Print the lowest paid salary employee and the amount they make every week
            Console.WriteLine($"{lowestPaidEmployee} is the lowest paid salary employee, making ${lowestPay:N2} every week.");
        }

        //Method to calculate the percentage of each employee's category
        static void percentagePerCategory(List<Employee> employees)
        {
            //Set the count of each type of employee to 0 as starting point 
            double wageEmployeesCount = 0;
            double salaryEmployeesCount = 0;
            double partTimeEmployeesCount = 0;

            //For each employee in the list of employees, check the type of employee and increment the count of that type
            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    wageEmployeesCount++;
                }
                else if (employee is Salaried)
                {
                    salaryEmployeesCount++;
                }
                else if (employee is PartTime)
                {
                    partTimeEmployeesCount++;
                }
            }
            //Calculate the total number of employees
            double totalEmployees = wageEmployeesCount + salaryEmployeesCount + partTimeEmployeesCount;

            //Calculate the percentage of each type of employee: amount of employees of that type divided by the total number of employees times 100
            double wageEmployeesPercentage = (double)wageEmployeesCount / totalEmployees * 100;
            double salaryEmployeesPercentage = (double)salaryEmployeesCount / totalEmployees * 100;
            double partTimeEmployeesPercentage = (double)partTimeEmployeesCount / totalEmployees * 100;

            //Print the percentage of each type of employee
            Console.WriteLine($"{wageEmployeesPercentage:N2}% of the personnel in the company are wage employees.");
            Console.WriteLine($"{salaryEmployeesPercentage:N2}% of the personnel in the company are salaried employees.");
            Console.WriteLine($"{partTimeEmployeesPercentage:N2}% of the personnel in the company are part-time employees.");



        }
    }
}
