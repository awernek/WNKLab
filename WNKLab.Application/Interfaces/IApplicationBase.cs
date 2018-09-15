using System.Collections.Generic;

namespace WNKLab.Application.Interfaces
{
    public interface IApplicationBase<T> where T : class
    {
        ICollection<T> RetornarTodos();
        T RetornarPor(int id);
        void Adicionar(T obj);
        void Atualizar(T obj);
        void Excluir(T obj);
    }
}
