# HR System Architecture Documentation

## 📂 Project Structure

```
HR System/
│
├── OOP_HRSystem.sln                          # Solution file
│
└── OOP_HRSystem/                             # Main project
    │
    ├── Program.cs                            # Entry point with comprehensive tests
    │
    ├── Models/                               # 📦 Domain Models & Entities
    │   ├── Entity.cs                         # Base entity (Id property)
    │   ├── Person.cs                         # Base person (FirstName, LastName, BirthDate)
    │   ├── Employee.cs                       # Abstract employee base
    │   ├── Applicant.cs                      # Job applicant model
    │   ├── SalariedEmployee.cs              # Full-time employee (Basic + Housing + Transportation)
    │   ├── HourlyEmployee.cs                # Part-time employee (HourRate × Hours)
    │   ├── InternEmployee.cs                # Intern (Fixed $2000)
    │   ├── CEO.cs                            # Executive (Non-dismissable)
    │   ├── DissmisableEmployee.cs           # Employees that can be dismissed
    │   └── PayItem.cs                        # Payslip line item (Name, Value)
    │
    ├── Interfaces/                           # 📋 Contracts & Abstractions
    │   ├── IRepository.cs                    # Generic repository interface
    │   ├── IDeletableRepository.cs          # Delete operation contract
    │   ├── IUpdatableRepository.cs          # Update operation contract
    │   └── INotifier.cs                      # Notification service contract
    │
    ├── Services/                             # ⚙️ Business Logic & Services
    │   ├── SalaryCalculator.cs              # Abstract salary calculator
    │   ├── SalariedEmployeeSalaryCalculator.cs   # Salaried employee calculator
    │   ├── HourlyEmployeeSalaryCalculator.cs     # Hourly employee calculator
    │   ├── InternEmployeeSalaryCalculator.cs     # Intern calculator
    │   ├── PayslipGenerator.cs              # Generates payslips
    │   └── Notifier.cs                       # Email notification implementation
    │
    ├── Repositories/                         # 💾 Data Access Layer
    │   └── Repository.cs                     # Generic in-memory repository
    │
    ├── bin/                                  # Build output
    ├── obj/                                  # Temporary build files
    └── OOP_HRSystem.csproj                  # Project configuration
```

## 🎯 Layer Responsibilities

### 1. **Models Layer** (Domain)
- Contains all business entities and domain models
- Pure data structures with business rules
- No dependencies on other layers
- Examples: Employee, Person, PayItem

**Namespace**: `OOP_HRSystem.Models`

### 2. **Interfaces Layer** (Contracts)
- Defines contracts for services and repositories
- Enables dependency inversion
- Facilitates testing and mocking
- Examples: IRepository, INotifier

**Namespace**: `OOP_HRSystem.Interfaces`

### 3. **Services Layer** (Business Logic)
- Implements business logic and operations
- Uses interfaces from Interfaces layer
- Depends on Models for data structures
- Examples: SalaryCalculator, PayslipGenerator, Notifier

**Namespace**: `OOP_HRSystem.Services`

### 4. **Repositories Layer** (Data Access)
- Handles data persistence and retrieval
- Implements repository interfaces
- Abstract data source details
- Examples: Repository<T>

**Namespace**: `OOP_HRSystem.Repositories`

## 🔄 Dependency Flow

```
Program.cs
    ↓
Services (uses Interfaces, Models)
    ↓
Repositories (uses Interfaces, Models)
    ↓
Models
```

## 📊 Class Inheritance Hierarchy

```
┌─────────┐
│ Entity  │ (Id)
└────┬────┘
     │
┌────▼────┐
│ Person  │ (FirstName, LastName, BirthDate)
└────┬────┘
     │
     ├─── Applicant
     │
     └─── Employee (abstract) ──────┐
              │                     │
              │                     └─── CEO (Non-dismissable)
              │
         ┌────▼────────────────┐
         │ DissmisableEmployee │
         └────┬────────────────┘
              │
              ├─── SalariedEmployee
              ├─── HourlyEmployee
              └─── InternEmployee
```

## 🧮 Salary Calculation Strategy

```
┌──────────────────┐
│SalaryCalculator  │ (abstract)
└────────┬─────────┘
         │
         ├─── SalariedEmployeeSalaryCalculator
         ├─── HourlyEmployeeSalaryCalculator
         └─── InternEmployeeSalaryCalculator
```

## 🔐 Design Principles Applied

### 1. **Separation of Concerns**
Each folder has a specific responsibility:
- Models: Data representation
- Interfaces: Contracts
- Services: Business logic
- Repositories: Data access

### 2. **Dependency Inversion**
- High-level modules (Services) depend on abstractions (Interfaces)
- Low-level modules (Repositories) implement abstractions

### 3. **Open/Closed Principle**
- Easy to add new employee types without modifying existing code
- New salary calculators can be added without changing the base

### 4. **Single Responsibility**
- Each class has one clear responsibility
- Models only contain data and validation
- Services only contain business logic
- Repositories only handle data operations

### 5. **Strategy Pattern**
- Salary calculation uses strategy pattern
- Different calculation strategies for different employee types

## 📋 Namespaces Overview

| Namespace | Purpose | Example Classes |
|-----------|---------|-----------------|
| `OOP_HRSystem.Models` | Domain entities | Employee, Person, PayItem |
| `OOP_HRSystem.Interfaces` | Contracts | IRepository, INotifier |
| `OOP_HRSystem.Services` | Business logic | PayslipGenerator, Notifier |
| `OOP_HRSystem.Repositories` | Data access | Repository<T> |
| `OOP_HRSystem` | Entry point | Program |

## 🧪 Test Coverage in Program.cs

The main program includes 5 comprehensive test suites:

1. **Test 1**: Employee Types & Salary Calculations
   - Tests all employee types
   - Validates salary calculations
   - Verifies tax and bonus calculations

2. **Test 2**: Repository Operations (CRUD)
   - Add, retrieve, and delete operations
   - ID generation
   - Data persistence

3. **Test 3**: Payslip Generation & Notifications
   - Email configuration
   - Payslip generation for all types
   - Notification system

4. **Test 4**: Employee Dismissal Policy
   - Dismissable employees
   - Protected employees (CEO)
   - Policy enforcement

5. **Test 5**: Salary Calculator Pattern
   - Calculator implementations
   - Calculation accuracy
   - Pattern validation

## 🚀 Getting Started

### Build
```bash
dotnet build
```

### Run Tests
```bash
dotnet run
```

### Add New Employee Type
1. Create new class in `Models/` inheriting from `DissmisableEmployee` or `Employee`
2. Implement `GetSalary()` and `GetPayItems()` methods
3. Optionally create calculator in `Services/`
4. Add test case in `Program.cs`

### Add New Service
1. Define interface in `Interfaces/`
2. Implement in `Services/`
3. Use dependency injection in constructors

## 📈 Future Enhancements

- Database integration (replace in-memory repository)
- Unit test project with xUnit or NUnit
- Web API layer with ASP.NET Core
- Authentication & authorization
- Advanced reporting features
- Performance tracking
