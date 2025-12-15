using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_HRSystem.Models;

namespace OOP_HRSystem.Interfaces
{
    internal interface IDeletableRepository<T> where T : Entity
    {
        void Delete(T entity);
    }
}
