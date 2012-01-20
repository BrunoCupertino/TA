using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.DataAccess.Base
{
    public interface IRepository<E> : IDisposable
        where E : class, IEntity, new()
    {
        E Create(E entityToCreate);
        E Update(E entityToUpdate);
        void DeleteById(int id);
        void Delete(E entityToDelete);
        E GetById(int id);
        List<E> GetAll();
    }
}
