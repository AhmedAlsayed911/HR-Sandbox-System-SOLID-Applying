# HR System - Object-Oriented Programming Project

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-Educational-blue.svg)](LICENSE)
[![Build](https://img.shields.io/badge/Build-Passing-brightgreen.svg)](https://github.com/AhmedAlsayed911/HR-Sandbox-System-SOLID-Applying)

## 📋 Overview
A comprehensive Human Resources Management System built with C# and .NET 8.0, demonstrating OOP principles including inheritance, polymorphism, abstraction, and SOLID principles.

## 🏗️ Architecture

The project follows a clean, layered architecture organized into the following folders:

```
OOP_HRSystem/
├── Models/              # Domain entities and business models
├── Interfaces/          # Contract definitions
├── Services/            # Business logic and services
├── Repositories/        # Data access layer
└── Program.cs          # Application entry point with tests
```

### 📁 Folder Structure Details

#### **Models/** - Domain Entities
- `Entity.cs` - Base entity with ID
- `Person.cs` - Abstract person with name and birth date
- `Employee.cs` - Abstract employee base class
- `SalariedEmployee.cs` - Full-time employees with fixed salary + benefits
- `HourlyEmployee.cs` - Part-time employees paid by hour
- `InternEmployee.cs` - Interns with fixed stipend
- `CEO.cs` - Executive-level employee (non-dismissable)
- `Applicant.cs` - Job applicants
- `DissmisableEmployee.cs` - Employees that can be dismissed
- `PayItem.cs` - Payslip line item

#### **Interfaces/** - Contracts
- `IRepository<T>` - Basic CRUD operations
- `IDeletableRepository<T>` - Delete capability
- `IUpdatableRepository<T>` - Update capability
- `INotifier` - Notification service contract

#### **Services/** - Business Logic
- `SalaryCalculator.cs` - Abstract salary calculator
- `SalariedEmployeeSalaryCalculator.cs` - Calculator for salaried employees
- `HourlyEmployeeSalaryCalculator.cs` - Calculator for hourly employees
- `InternEmployeeSalaryCalculator.cs` - Calculator for interns
- `PayslipGenerator.cs` - Generates and sends payslips
- `Notifier.cs` - Email notification service

#### **Repositories/** - Data Access
- `Repository<T>` - Generic in-memory repository

## 🎯 Features

### Employee Management
- **Multiple Employee Types**: Salaried, Hourly, Intern, CEO
- **Salary Calculations**: Different calculation methods per employee type
- **Tax Handling**: Support for tax deductions and bonuses
- **Employee Dismissal**: Policy-based dismissal rules

### Payroll System
- **Payslip Generation**: Automated payslip creation
- **Email Notifications**: Send payslips via email
- **Detailed Breakdowns**: Itemized salary components

### Repository Pattern
- **CRUD Operations**: Create, Read, Update, Delete
- **Generic Implementation**: Works with any entity type
- **In-Memory Storage**: Simple list-based storage

## 🧪 Running Tests

The `Program.cs` contains comprehensive tests covering all major functionality:

```bash
cd OOP_HRSystem
dotnet run
```

### Test Coverage

1. **Employee Types and Salary Calculations**
   - Creating different employee types
   - Calculating salaries with various parameters
   - Testing tax deductions and bonuses

2. **Repository Operations (CRUD)**
   - Adding employees to repository
   - Retrieving employees by ID
   - Listing all employees
   - Deleting employees

3. **Payslip Generation & Notifications**
   - Configuring email notifier
   - Generating payslips for different employee types
   - Sending notifications

4. **Employee Dismissal Policy**
   - Dismissing regular employees
   - Protecting CEO from dismissal
   - Policy enforcement

5. **Salary Calculator Pattern**
   - Testing calculator implementations
   - Verifying calculation accuracy
   - Comparing with direct methods

## 🛠️ Technologies

- **Language**: C# 12
- **Framework**: .NET 8.0
- **Architecture**: Layered/Clean Architecture
- **Patterns**: Repository, Strategy (Salary Calculator), Dependency Injection

## 📐 Design Patterns

### Strategy Pattern
Used in salary calculation where different employee types have different calculation strategies.

### Repository Pattern
Abstracts data access logic, making it easy to swap implementations.

### Dependency Injection
Services depend on interfaces rather than concrete implementations.

## 🔑 Key OOP Principles

- **Inheritance**: Employee hierarchy, Person → Employee → Specific Types
- **Polymorphism**: Different salary calculations for different employee types
- **Abstraction**: Abstract classes and interfaces define contracts
- **Encapsulation**: Private fields with controlled access
- **SOLID Principles**:
  - Single Responsibility: Each class has one clear purpose
  - Open/Closed: Easy to extend with new employee types
  - Liskov Substitution: Derived types can replace base types
  - Interface Segregation: Focused interfaces
  - Dependency Inversion: Depend on abstractions

## 🚀 Building the Project

```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run

# Run in release mode
dotnet run -c Release
```

## 📝 Usage Example

```csharp
// Create an employee
var employee = new SalariedEmployee
{
    Email = "john.doe@company.com",
    BasicSalary = 5000,
    Housing = 2000,
    Transportation = 800
};
employee.setName("John", "Doe");
employee.BirthDate = new DateOnly(1990, 1, 1);

// Calculate salary
var salary = employee.GetSalary();
var salaryWithTax = employee.GetSalary(10); // 10% tax
var salaryWithBonus = employee.GetSalary(10, 500); // 10% tax + $500 bonus

// Add to repository
var repository = new Repository<Employee>();
repository.Add(employee);

// Generate payslip
var notifier = new Notifier("smtp.server.com", 587, "hr@company.com", "password");
var generator = new PayslipGenerator(notifier);
generator.Generate(employee);
```

## 📊 Class Diagram

```
Entity
  └── Person
       ├── Applicant
       └── Employee (abstract)
            ├── DissmisableEmployee (abstract)
            │    ├── SalariedEmployee
            │    ├── HourlyEmployee
            │    └── InternEmployee
            └── CEO
```

## 🤝 Contributing

This is an educational project demonstrating OOP concepts. Feel free to use it as a reference for learning.

## 📄 License

This project is for educational purposes.
