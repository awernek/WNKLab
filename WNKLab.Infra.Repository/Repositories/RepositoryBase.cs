using System;
using System.Collections.Generic;
using WNKLab.Domain.Interfaces.Repositories;

namespace WNKLab.Infra.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public void Adicionar(T obj)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(T obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(T obj)
        {
            throw new NotImplementedException();
        }

        public T RetornarPor(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> RetornarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
