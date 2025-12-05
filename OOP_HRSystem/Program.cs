using System.Net.Mail;

namespace OOP_HRSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var employee = new Employee();
            //employee.setName("ahmed", "sayed");
            //employee.BirthDate = new DateOnly(2000, 1, 1);
            //employee.BasicSalary = 2550;
            //employee.TaxPercentage = 140;

            //Person person = new Employee();
            //person.setName("ahmed","sayed");
            //person.BirthDate = new DateOnly(2003,7,10);
            //PrintPersonDetails(person);
            //Console.WriteLine("--------------------------------------");
            //person = new Applicant();
            //person.setName("khaled", "mohamed");
            //person.BirthDate = new DateOnly(2005,8,4);
            //PrintPersonDetails(person);

            //Console.WriteLine($"Basic Salary : {employee.BasicSalary}");
            //Console.WriteLine($"Tax Percentage : {employee.TaxPercentage}");
            //}
            // static void PrintPersonDetails (Person person)
            // {
            //     Console.WriteLine($"Full Name : {person.FirstName} {person.LastName}");
            //     Console.WriteLine($"Birth Date : {person.BirthDate}");

            // var salariedEmployee = new SalariedEmployee();
            // salariedEmployee.setName("ahmed", "sayed");
            // salariedEmployee.Email = "salaried@test.com";
            // salariedEmployee.BasicSalary = 2000;
            // salariedEmployee.Housing = 1000;
            // salariedEmployee.Transportation = 500;
            // Console.WriteLine($"Salary of salaried employee(without taxes) is {salariedEmployee.GetSalary():0,00}");
            // Console.WriteLine($"Salary of salaried employee(with 10% taxes) is {salariedEmployee.GetSalary(10):0,00}");
            // Console.WriteLine($"Salary of salaried employee(with 10% taxes and 1000 bonus) is {salariedEmployee.GetSalary(10 , 1000):0,00}");
            //
            //var hourlyEmployee = new HourlyEmployee();
            //hourlyEmployee.setName("mahmoud", "khaled");
            // hourlyEmployee.Email = "salaried@test.com";
            // hourlyEmployee.HourRate = 100;
            // hourlyEmployee.TotalWorkingHours = 60;
            // Console.WriteLine($"Salary of salaried employee is {hourlyEmployee.GetSalary():0,00}");
            //
            // var internEmployee = new InternEmployee();
            // internEmployee.setName("mohammed", "hamdy");
            // internEmployee.Email = "salaried@test.com";
            // Console.WriteLine($"Salary of salaried employee is {internEmployee.GetSalary():0,00}");
            // Console.ForegroundColor = ConsoleColor.White;
            // Console.WriteLine("-----------------------------------------------------------");
            //
            //var notifier = new Notifier("mail@example.com", 25, "test@testtest.com", "Abc123");
            //Console.WriteLine($"smtp : {notifier.Smtp}");          // mail@example.com"
            //var paysLipGenerator = new PayslipGenerator(notifier);
            //paysLipGenerator.Generate(salariedEmployee);
            //paysLipGenerator.Generate(hourlyEmployee);
            //paysLipGenerator.Generate(internEmployee);
            //DissmisableEmployee employee = new SalariedEmployee();
            //employee.setName("ahmed", "sayed");
            //DismissEmployee(employee);
            //
            //employee = new HourlyEmployee();
            //employee.setName("mohamed", "sayed");
            //DismissEmployee(employee);
            //
            //employee = new InternEmployee();
            //employee.setName("abdo", "sayed");
            //DismissEmployee(employee);

            // employee = new CEO();       // can't dismiss.
            // employee.setName("abdo", "sayed");
            // DismissEmployee(employee);

            //var employee = new SalariedEmployee();
            //employee.setName("Ahmed","Sayed");
            //var repository = new Repository<Employee>();
            //repository.Add(employee);
            //Console.WriteLine($"employee {employee.FirstName} {employee.LastName} has id : {employee.Id}");           

            //var addedEmployee = repository.GetById(employee.Id);
            //Console.WriteLine(addedEmployee == null ? "Employee no Found" : "Employee has been added");

            //repository.Delete(employee);
            //addedEmployee = repository.GetById(employee.Id);
            //Console.WriteLine(addedEmployee == null ? "Employee no Found" : "Employee has been added");

            //var repo = new Repository<Applicant>();
            //var applicant = new Applicant();
            //applicant.setName("ahmed","sayed");
            //repo.Add(applicant);
            //repo.Delete(applicant);
            //var e = new SalariedEmployee { BasicSalary = 500, Housing = 500, Transportation = 500 };
            //Console.WriteLine(e.GetSalary());
            INotifier not = new Notifier("test" , 5,"test","test");
            not.Notify("test" , "testc" , "test");

        }
       //static void DismissEmployee(DissmisableEmployee employee)
       //{
       //    employee.setDismissed();
       //    Console.WriteLine($"Dear {employee.FirstName} {employee.LastName} you have been dismissed");
       //}
    }
}
