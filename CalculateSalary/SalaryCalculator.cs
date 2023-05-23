using System;


class SalaryCalculator
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter gross salary: ");
            double grossSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter employment insurance: ");
            double employmentInsurance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter income tax: ");
            double incomeTax = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Canada pension plan: ");
            double canadaPensionPlan = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter bonus: ");
            double bonus = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter allowance: ");
            double allowance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter number of dependents: ");
            int numberOfDependents = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter gender (M/F): ");
            char gender = Convert.ToChar(Console.ReadLine().ToUpper());

            double finalGrossSalary = 0;

            if (gender == 'M')
            {
                // Apply deductions based on the number of dependents
                if (numberOfDependents >= 4)
                {
                    double deductions = (grossSalary * (incomeTax - 0.04)) / 100 + (grossSalary * canadaPensionPlan) / 100 +
                        (grossSalary * employmentInsurance) / 100;// 4% deduction
                    finalGrossSalary = grossSalary - deductions + (bonus + allowance);

                }
                else if (numberOfDependents == 3)
                {
                    double deductions = (grossSalary * (incomeTax - 0.02)) / 100 + (grossSalary * canadaPensionPlan) / 100 +
                        (grossSalary * employmentInsurance) / 100;// 2% deduction
                    finalGrossSalary = grossSalary - deductions + (bonus + allowance);
                }

                else
                {
                    double deductions = ((grossSalary * incomeTax / 100) + (grossSalary * canadaPensionPlan / 100) +
                       (grossSalary * employmentInsurance / 100));
                    finalGrossSalary = grossSalary - deductions + (bonus + allowance);
                }
            }

            // Apply additional deduction for female gender
            if (gender == 'F')
            {
                // Apply deductions based on the number of dependents
                if (numberOfDependents >= 4)
                {
                    double deductions = (grossSalary * (incomeTax - 0.06)) / 100 + (grossSalary * canadaPensionPlan) / 100 +
                        (grossSalary * employmentInsurance)/100;// 4% deduction + 2% deduction for being female
                    finalGrossSalary = grossSalary - deductions + (bonus + allowance);

                }
                else if (numberOfDependents == 3)
                {
                    double deductions = (grossSalary * (incomeTax - 0.04)) / 100 + (grossSalary * canadaPensionPlan) / 100 +
                        (grossSalary * employmentInsurance) / 100;// 2% deduction + 2% deduction for being female
                    finalGrossSalary = grossSalary - deductions + (bonus + allowance);
                }
                else
                {
                    double deductions = ((grossSalary * (incomeTax-0.02)) / 100) + (grossSalary * canadaPensionPlan / 100) +
                       (grossSalary * employmentInsurance/100);
                    finalGrossSalary = grossSalary - deductions + (bonus + allowance);
                }
            }
            Console.WriteLine("Final gross salary: " + finalGrossSalary);
        }catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}