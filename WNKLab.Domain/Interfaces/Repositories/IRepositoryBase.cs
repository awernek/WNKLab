using System.Collections.Generic;

namespace WNKLab.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> RetornarTodos();
        T RetornarPor(int id);
        void Adicionar(T obj);
        void Atualizar(T obj);
        void Excluir(T obj);
    }
}
