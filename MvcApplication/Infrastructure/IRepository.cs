﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Infrastructure
{
    public interface  IRepository<TEntity,TIdentity>
    {
        IQueryable<TEntity> GetAll();
        TEntity GetDetails(TIdentity identity);
        void CreateNew(TEntity item);
        void Update(TEntity item);
        void Delete(TIdentity identity);

    }
}