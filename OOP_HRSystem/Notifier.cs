using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem
{
    internal class Notifier : INotifier
    {
        public Notifier(string smtpServer , int port , string senderAddress , string senderPassword) 
        { 
            Smtp = smtpServer;
            Port = port;
            SenderAddress = senderAddress;
            SenderPassword = senderPassword;
        }
        public string Smtp {get;}
        public int Port {get;}
        public string SenderAddress {get;}
        public string SenderPassword {get;}
        public void Notify(string email , string subject , string body)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"you have a new email from'{SenderAddress}' with subject '{subject}'");
            Console.WriteLine(body);
            Console.WriteLine($"message sent successfully to '{email}' ");
            Console.WriteLine("***************************************");
            Console.ForegroundColor= ConsoleColor.White; 
        }
    }
}
