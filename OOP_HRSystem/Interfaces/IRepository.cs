using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_HRSystem.Models;

namespace OOP_HRSystem.Interfaces
{
    internal interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
    }
}
