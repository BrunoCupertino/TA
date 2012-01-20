using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;
using System.Data.Objects;
using System.Data;

namespace TA.DataAccess.Base
{
    public abstract class RepositoryEF<E> : IRepository<E>
        where E : class, IEntity, new()
    {
        public RepositoryEF(ObjectContext objectContext)
        {
            this.Context = objectContext;
        }

        protected ObjectContext Context { get; private set; }
        protected abstract string EntitySetName { get; set; }

        protected ObjectSet<E> GetTable()
        {
            return this.Context.CreateObjectSet<E>();
        }

        #region IRepository<E> Members

        public E Create(E entityToCreate)
        {
            this.Context.AddObject(this.EntitySetName, entityToCreate);
            this.Context.SaveChanges();

            return entityToCreate;
        }

        public E Update(E entityToUpdate)
        {
            this.Context.ObjectStateManager.ChangeObjectState(entityToUpdate, EntityState.Modified);
            this.Context.SaveChanges();

            return entityToUpdate;
        }

        public void DeleteById(int id)
        {
            E entityToDelete = this.GetById(id);

            this.Context.DeleteObject(entityToDelete);
            this.Context.SaveChanges();
        }

        public void Delete(E entityToDelete)
        {
            this.Context.DeleteObject(entityToDelete);
            this.Context.SaveChanges();
        }

        public abstract E GetById(int id);

        public List<E> GetAll()
        {
            return this.GetTable().ToList();
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
