﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleRssReader.Domain.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
