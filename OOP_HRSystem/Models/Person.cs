using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem.Models
{
    internal abstract class Person : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public void setName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException("Invalid Name!");
            FirstName = firstName;
            LastName = lastName;
        }
        private DateOnly _birthDate;
        public DateOnly BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                if (value < new DateOnly(1986, 9, 14))
                    throw new ArgumentException("Invalid Birth Date!");
                _birthDate = value;
            }
        }
    }
}