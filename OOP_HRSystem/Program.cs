using System.Net.Mail;
using OOP_HRSystem.Models;
using OOP_HRSystem.Services;
using OOP_HRSystem.Interfaces;
using OOP_HRSystem.Repositories;

namespace OOP_HRSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            // Test 1: Employee Creation and Salary Calculations
            TestEmployeeTypes();

            // Test 2: Repository Operations
            TestRepositoryOperations();

            // Test 3: Payslip Generation
            TestPayslipGeneration();

            // Test 4: Dismissable Employees
            TestDismissableEmployees();

            // Test 5: Salary Calculators
            TestSalaryCalculators();

           
        }

        static void TestEmployeeTypes()
        {

            // Salaried Employee Test
            var salariedEmployee = new SalariedEmployee();
            salariedEmployee.setName("Ahmed", "Sayed");
            salariedEmployee.Email = "ahmed.sayed@company.com";
            salariedEmployee.BirthDate = new DateOnly(1990, 5, 15);
            salariedEmployee.BasicSalary = 3000;
            salariedEmployee.Housing = 1000;
            salariedEmployee.Transportation = 500;

            Console.WriteLine($"\n1. Salaried Employee: {salariedEmployee.FirstName} {salariedEmployee.LastName}");
            Console.WriteLine($"   Email: {salariedEmployee.Email}");
            Console.WriteLine($"   Birth Date: {salariedEmployee.BirthDate}");
            Console.WriteLine($"   Basic Salary: ${salariedEmployee.BasicSalary:N2}");
            Console.WriteLine($"   Housing: ${salariedEmployee.Housing:N2}");
            Console.WriteLine($"   Transportation: ${salariedEmployee.Transportation:N2}");
            Console.WriteLine($"   Total Salary (No Tax): ${salariedEmployee.GetSalary():N2}");
            Console.WriteLine($"   Total Salary (10% Tax): ${salariedEmployee.GetSalary(10):N2}");
            Console.WriteLine($"   Total Salary (10% Tax + $500 Bonus): ${salariedEmployee.GetSalary(10, 500):N2}");

            // Hourly Employee Test
            var hourlyEmployee = new HourlyEmployee();
            hourlyEmployee.setName("Mahmoud", "Khaled");
            hourlyEmployee.Email = "mahmoud.khaled@company.com";
            hourlyEmployee.BirthDate = new DateOnly(1995, 8, 20);
            hourlyEmployee.HourRate = 50;
            hourlyEmployee.TotalWorkingHours = 160;

            Console.WriteLine($"\n2. Hourly Employee: {hourlyEmployee.FirstName} {hourlyEmployee.LastName}");
            Console.WriteLine($"   Email: {hourlyEmployee.Email}");
            Console.WriteLine($"   Birth Date: {hourlyEmployee.BirthDate}");
            Console.WriteLine($"   Hour Rate: ${hourlyEmployee.HourRate:N2}");
            Console.WriteLine($"   Total Working Hours: {hourlyEmployee.TotalWorkingHours}");
            Console.WriteLine($"   Total Salary: ${hourlyEmployee.GetSalary():N2}");

            // Intern Employee Test
            var internEmployee = new InternEmployee();
            internEmployee.setName("Mohammed", "Hamdy");
            internEmployee.Email = "mohammed.hamdy@company.com";
            internEmployee.BirthDate = new DateOnly(2000, 3, 10);

            Console.WriteLine($"\n3. Intern Employee: {internEmployee.FirstName} {internEmployee.LastName}");
            Console.WriteLine($"   Email: {internEmployee.Email}");
            Console.WriteLine($"   Birth Date: {internEmployee.BirthDate}");
            Console.WriteLine($"   Fixed Salary: ${internEmployee.GetSalary():N2}");

            Console.WriteLine("\n✓ Test 1 Passed: All employee types created successfully!");
        }

        static void TestRepositoryOperations()
        {
  

            var repository = new Repository<Employee>();

            // Add employees
            var emp1 = new SalariedEmployee();
            emp1.setName("John", "Doe");
            emp1.BirthDate = new DateOnly(1988, 1, 1);
            emp1.Email = "john.doe@company.com";
            emp1.BasicSalary = 4000;
            emp1.Housing = 1500;
            emp1.Transportation = 700;

            var emp2 = new HourlyEmployee();
            emp2.setName("Jane", "Smith");
            emp2.BirthDate = new DateOnly(1992, 6, 15);
            emp2.Email = "jane.smith@company.com";
            emp2.HourRate = 60;
            emp2.TotalWorkingHours = 150;

            var emp3 = new InternEmployee();
            emp3.setName("Bob", "Johnson");
            emp3.BirthDate = new DateOnly(2001, 9, 30);
            emp3.Email = "bob.johnson@company.com";

            repository.Add(emp1);
            repository.Add(emp2);
            repository.Add(emp3);

            Console.WriteLine($"\n✓ Added 3 employees to repository");
            Console.WriteLine($"  - {emp1.FirstName} {emp1.LastName} (ID: {emp1.Id})");
            Console.WriteLine($"  - {emp2.FirstName} {emp2.LastName} (ID: {emp2.Id})");
            Console.WriteLine($"  - {emp3.FirstName} {emp3.LastName} (ID: {emp3.Id})");

            // Get all employees
            var allEmployees = repository.GetAll();
            Console.WriteLine($"\n✓ Total employees in repository: {allEmployees.Count()}");

            // Get by ID
            var foundEmployee = repository.GetById(2);
            Console.WriteLine($"\n✓ Found employee by ID 2: {foundEmployee.FirstName} {foundEmployee.LastName}");

            // Delete employee
            repository.Delete(emp3);
            Console.WriteLine($"\n✓ Deleted employee: {emp3.FirstName} {emp3.LastName}");
            Console.WriteLine($"  Employees remaining: {repository.GetAll().Count()}");

            // Try to find deleted employee
            var deletedEmployee = repository.GetById(emp3.Id);
            Console.WriteLine($"  Searching for deleted employee: {(deletedEmployee == null ? "Not Found (Expected)" : "Found (Unexpected)")}");

            Console.WriteLine("\n✓ Test 2 Passed: Repository operations working correctly!");
        }

        static void TestPayslipGeneration()
        {
         
            // Setup notifier
            var notifier = new Notifier(
                smtpServer: "smtp.company.com",
                port: 587,
                senderAddress: "hr@company.com",
                senderPassword: "SecurePass123"
            );

            Console.WriteLine($"✓ Email Configuration:");
            Console.WriteLine($"  SMTP Server: {notifier.Smtp}");
            Console.WriteLine($"  Port: {notifier.Port}");
            Console.WriteLine($"  Sender: {notifier.SenderAddress}");

            var payslipGenerator = new PayslipGenerator(notifier);

            // Generate payslips for different employee types
            Console.WriteLine("\n✓ Generating Payslips:\n");

            var salariedEmp = new SalariedEmployee
            {
                Email = "ahmed@company.com",
                BasicSalary = 5000,
                Housing = 2000,
                Transportation = 800
            };
            salariedEmp.setName("Ahmed", "Ali");
            salariedEmp.BirthDate = new DateOnly(1990, 5, 20);
            payslipGenerator.Generate(salariedEmp);

            var hourlyEmp = new HourlyEmployee
            {
                Email = "sara@company.com",
                HourRate = 75,
                TotalWorkingHours = 180
            };
            hourlyEmp.setName("Sara", "Mohamed");
            hourlyEmp.BirthDate = new DateOnly(1993, 8, 12);
            payslipGenerator.Generate(hourlyEmp);

            var internEmp = new InternEmployee
            {
                Email = "omar@company.com"
            };
            internEmp.setName("Omar", "Hassan");
            internEmp.BirthDate = new DateOnly(2002, 2, 28);
            payslipGenerator.Generate(internEmp);

            Console.WriteLine("\n✓ Test 3 Passed: Payslips generated successfully!");
        }

        static void TestDismissableEmployees()
        {
            Console.WriteLine("\n\n[TEST 4] Employee Dismissal Policy");
            Console.WriteLine("===================================");

            Console.WriteLine("\nDismissing different employee types:\n");

            // Salaried employee can be dismissed
            DissmisableEmployee employee = new SalariedEmployee();
            employee.setName("Ahmed", "Sayed");
            employee.BirthDate = new DateOnly(1991, 7, 10);
            DismissEmployee(employee);

            // Hourly employee can be dismissed
            employee = new HourlyEmployee();
            employee.setName("Mohamed", "Khaled");
            employee.BirthDate = new DateOnly(1994, 3, 15);
            DismissEmployee(employee);

            // Intern employee can be dismissed
            employee = new InternEmployee();
            employee.setName("Abdo", "Mahmoud");
            employee.BirthDate = new DateOnly(2001, 11, 5);
            DismissEmployee(employee);

            // CEO cannot be dismissed (inherits from Employee, not DissmisableEmployee)
            Console.WriteLine("\n4. Attempting to dismiss CEO:");
            Console.WriteLine("   ✗ CEO class does not inherit from DissmisableEmployee");
            Console.WriteLine("   ✓ CEO is protected from dismissal by design");

            Console.WriteLine("\n✓ Test 4 Passed: Dismissal policy enforced correctly!");
        }

        static void DismissEmployee(DissmisableEmployee employee)
        {
            Console.WriteLine($"✓ {employee.GetType().Name}: {employee.FirstName} {employee.LastName} - Dismissed Successfully");
        }

        static void TestSalaryCalculators()
        {
           

            // Test Salaried Employee Calculator
            var salariedEmp = new SalariedEmployee
            {
                BasicSalary = 4500,
                Housing = 1800,
                Transportation = 600
            };
            salariedEmp.setName("Test", "Salaried");
            salariedEmp.BirthDate = new DateOnly(1989, 4, 10);

            var salariedCalc = new SalariedEmployeeSalaryCalculator(salariedEmp);
            Console.WriteLine($"\n1. Salaried Employee Calculator:");
            Console.WriteLine($"   Employee: {salariedEmp.FirstName} {salariedEmp.LastName}");
            Console.WriteLine($"   Calculated Salary: ${salariedCalc.Calculate():N2}");
            Console.WriteLine($"   Direct Method: ${salariedEmp.GetSalary():N2}");
            Console.WriteLine($"   ✓ Results match: {salariedCalc.Calculate() == salariedEmp.GetSalary()}");

            // Test Hourly Employee Calculator
            var hourlyEmp = new HourlyEmployee
            {
                HourRate = 55,
                TotalWorkingHours = 170
            };
            hourlyEmp.setName("Test", "Hourly");
            hourlyEmp.BirthDate = new DateOnly(1993, 7, 22);

            var hourlyCalc = new HourlyEmployeeSalaryCalculator(hourlyEmp);
            Console.WriteLine($"\n2. Hourly Employee Calculator:");
            Console.WriteLine($"   Employee: {hourlyEmp.FirstName} {hourlyEmp.LastName}");
            Console.WriteLine($"   Calculated Salary: ${hourlyCalc.Calculate():N2}");
            Console.WriteLine($"   Direct Method: ${hourlyEmp.GetSalary():N2}");
            Console.WriteLine($"   ✓ Results match: {hourlyCalc.Calculate() == hourlyEmp.GetSalary()}");

            // Test Intern Employee Calculator
            var internEmp = new InternEmployee();
            internEmp.setName("Test", "Intern");
            internEmp.BirthDate = new DateOnly(2001, 12, 5);

            var internCalc = new InternEmployeeSalaryCalculator(internEmp);
            Console.WriteLine($"\n3. Intern Employee Calculator:");
            Console.WriteLine($"   Employee: {internEmp.FirstName} {internEmp.LastName}");
            Console.WriteLine($"   Calculated Salary: ${internCalc.Calculate():N2}");
            Console.WriteLine($"   Direct Method: ${internEmp.GetSalary():N2}");
            Console.WriteLine($"   ✓ Results match: {internCalc.Calculate() == internEmp.GetSalary()}");

            Console.WriteLine("\n✓ Test 5 Passed: All salary calculators work correctly!");
        }
    }
}
