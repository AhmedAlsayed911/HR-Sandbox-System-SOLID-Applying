using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem
{
    internal class Notifieerz : INotifier
    {
        public void Notify(string email, string subject, string body)
        {
            Console.WriteLine("HIIII");
        }
    }
}
