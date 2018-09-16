using System;
using System.Collections.Generic;
using WNKLab.Domain.Interfaces.Services;

namespace WNKLab.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        public T RetornarPor(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> RetornarTodos()
        {
            throw new NotImplementedException();
        }

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
    }
}
