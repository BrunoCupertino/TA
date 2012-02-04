using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;
using System.Data.Objects;
using System.Data;
using System.Data.Entity;

namespace TA.DataAccess.EF.Base
{
    public abstract class EFRepository<E> : IRepository<E>
        where E : class, IEntidade, new()
    {
        public EFRepository(DbContext objectContext)
        {
            this.Context = objectContext;
        }

        protected DbContext Context { get; private set; }

        #region IRepository<E> Members

        public virtual E Create(E entityToCreate)
        {
            this.Context.Set<E>().Add(entityToCreate);
            this.Context.SaveChanges();

            return entityToCreate;
        }

        public virtual E Update(E entityToUpdate)
        {
            this.Context.Entry(entityToUpdate).State = EntityState.Modified;
            this.Context.SaveChanges();

            return entityToUpdate;
        }

        public virtual void DeleteById(int id)
        {
            E entityToDelete = this.GetById(id);

            this.Context.Set<E>().Remove(entityToDelete);
            this.Context.SaveChanges();
        }

        public virtual void Delete(E entityToDelete)
        {
            this.Context.Set<E>().Remove(entityToDelete);
            this.Context.SaveChanges();
        }

        public virtual E GetById(int id)
        {
            return this.Context.Set<E>().Find(id);
        }

        public virtual List<E> GetAll()
        {
            return this.Context.Set<E>().ToList();
        }        
 
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Context.Dispose();
        }

        #endregion
    }
}
