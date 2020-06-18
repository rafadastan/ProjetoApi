using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        void Update(T obj);
        void Delete(T obj);
        void insert(T obj);
        List<T> GetAll();
        T GetById(int id);
    }
}
