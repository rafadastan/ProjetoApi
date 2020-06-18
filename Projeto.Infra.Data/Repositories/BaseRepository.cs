using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Delete(T obj)
        {
            dataContext.Entry(obj).State = EntityState.Deleted;
            dataContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return dataContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return dataContext.Set<T>().Find(id);
        }

        public void insert(T obj)
        {
            dataContext.Entry(obj).State = EntityState.Added;
            dataContext.SaveChanges();
        }

        public void Update(T obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            dataContext.SaveChanges();
        }
    }
}
