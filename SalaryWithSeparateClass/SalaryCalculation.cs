
using System.Reflection;
using System.Text.RegularExpressions;

namespace CSharpSalaryCalculator
{
    class SalaryCalculation
    {
        private string Name;
        private double Salary;
        private double IncomeTax;
        private double Cpp;
        private double Ei;
        private double Bonus;
        private double Allowance;
        private int Dependents;
        private char Gender;

        public void GetInput()
        {
            Console.WriteLine("Enter Employee Name: ");
            Name = Console.ReadLine();

            while (!IsValidName(Name))
            {
                Name = Console.ReadLine(); // keep on taking the input until name is not valid
            }

            Console.WriteLine("Enter Gross Salary: "); 
            Salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Income Tax: ");
            IncomeTax = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Canada Pension Plan: ");
            Cpp = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Employment Insurance: ");
            Ei = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter bonus: ");
            Bonus = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Allowance: ");
            Allowance = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Number of Dependents: ");
            Dependents = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Gender (M/F): ");
            Gender = Convert.ToChar(Console.ReadLine());
        }

        public bool IsValidName(string Name) // this method checks if name is valid
        {
            return Regex.IsMatch(Name,@"^[a-zA-z ]+$"); // this method checks if name has only alphabetical characters and spaces only
        }

        public void CalculateFinalGrossSalary()
        {
            double TotalDeductions = CalculateDeductions();
            double finalSalary = Salary - TotalDeductions + (Bonus + Allowance);
            Console.WriteLine("Deductions: " + TotalDeductions);
            Console.WriteLine("Final Gross Salary After applying additions and deductions is: " + finalSalary);
        }

        public double CalculateDeductions()
        {
            double deductions = 0;

            if (Gender == 'M')
            {
                // Apply deductions based on the number of dependents
                if (Dependents >= 4)
                {
                    deductions = (Salary * (IncomeTax - 0.04)) / 100 + (Salary * Cpp) / 100 +
                        (Salary * Ei) / 100;// 4% deduction

                }
                else if (Dependents == 3)
                {
                    deductions = (Salary * (IncomeTax - 0.02)) / 100 + (Salary * Cpp) / 100 +
                        (Salary * Ei) / 100;// 2% deduction
                    
                }

                else
                {
                    deductions = ((Salary * IncomeTax / 100) + (Salary * Cpp / 100) +
                       (Salary * Ei / 100));
                    
                }
            }

            // Apply additional deduction for female gender
            if (Gender == 'F')
            {
                // Apply deductions based on the number of dependents
                if (Dependents >= 4)
                {
                    deductions = (Salary * (IncomeTax - 0.06)) / 100 + (Salary * Cpp) / 100 +
                        (Salary * Ei) / 100;// 4% deduction + 2% deduction for being female
                   

                }
                else if (Dependents == 3)
                {
                    deductions = (Salary * (IncomeTax - 0.04)) / 100 + (Salary * Cpp) / 100 +
                        (Salary * Ei) / 100;// 2% deduction + 2% deduction for being female
                   
                }
                else
                {
                    deductions = ((Salary * (IncomeTax - 0.02)) / 100) + (Salary * Cpp / 100) +
                       (Salary * Ei / 100);
                    
                }
            }
            return deductions;
        }
    }
    
}
