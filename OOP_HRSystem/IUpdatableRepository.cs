using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem
{
    internal interface IUpdatableRepository<T> where T : Entity
    {
        void Update(T entity);
    }
}
