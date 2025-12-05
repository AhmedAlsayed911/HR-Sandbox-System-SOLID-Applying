using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem
{
    internal class Repository<T> :  IRepository<T> where T : Entity // --> Entity may be employee , applicant or person.
    {
        private List<T> _entities = new();
       
        public IEnumerable<T> GetAll()
        {
            return _entities.AsReadOnly();
        }
        public T GetById(int id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }
        public void Add(T entity)
        {
            entity.Id = _entities.Count + 1;
            _entities.Add(entity);
        }
        public void Update(T entity)
        {
            var originalEntity = GetById(entity.Id);
            //TODO : map entity to original entity to copy new data.
        }
        public void Delete(T entity)
        {
           //if (entity is Applicant)
           //    throw new ArgumentException("Can't delete Apllicant Entity");
            _entities.Remove(entity);
        }
    }
}
