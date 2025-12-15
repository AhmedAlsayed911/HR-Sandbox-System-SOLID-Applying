using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_HRSystem.Models;
using OOP_HRSystem.Interfaces;

namespace OOP_HRSystem.Services
{
    internal class PayslipGenerator
    {
        private readonly INotifier _notifier;
        public PayslipGenerator(INotifier notifier)
        {
            _notifier = notifier;
        }
        public void Generate(Employee employee)
        {
            var payItems = employee.GetPayItems();
            var message = new StringBuilder();
            message.AppendLine($"Dear {employee.FirstName} {employee.LastName}");
            message.AppendLine("Please Find below your payslip details : ");
            foreach (var payItem in payItems)
                message.AppendLine($"{payItem.Name}\t\t{payItem.Value}");
            _notifier.Notify(employee.Email,"Payslip Generated!",message.ToString());
        }
    }
}
