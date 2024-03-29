﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TA.Domain.Entity;

namespace TA.DataAccess.EF.Base
{
    public interface IRepository<E> : IDisposable
        where E : class, IEntidade, new()
    {
        E Create(E entityToCreate);
        E Update(E entityToUpdate);
        void DeleteById(int id);
        void Delete(E entityToDelete);
        E GetById(int id);
        List<E> GetAll();
    }
}
