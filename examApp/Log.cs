﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace examApp
{
    public class Log
    {
        public interface IRepository<T>
        {
            void Insert(T entity);
            void Insert(ICollection<T> entities);
        }


        public class Repository<T> : IRepository<T> where T : class
        {
            protected DbSet<T> DbSet;

            public Repository(DbContext dataContext)
            {
                DbSet = dataContext.Set<T>();
            }

            public void Insert(T entity)
            {
                DbSet.Add(entity);
            }

            public void Insert(ICollection<T> entities)
            {
                DbSet.AddRange(entities);
            }
        }


        public class Singleton
        {
            private static Lazy<Exam_System_DBEntities> _instance = new Lazy<Exam_System_DBEntities>();

            public static Exam_System_DBEntities Instance
            {
                get
                {
                    if (
                        _instance.Value.Database.Connection.State ==
                        System.Data.ConnectionState.Closed
                       )
                        _instance.Value.Database.Connection.Open();

                    return _instance.Value;
                }
            }
        }
    }
}