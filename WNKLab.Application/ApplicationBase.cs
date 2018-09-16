using System;
using System.Collections.Generic;
using WNKLab.Application.Interfaces;

namespace WNKLab.Application
{
    public class ApplicationBase<T> : IApplicationBase<T> where T : class
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

        public IEnumerable<T> RetornarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
