using System;
using WNKLab.Domain.Interfaces.Repositories;

namespace WNKLab.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProdutoRepository ProdutoRepository { get; }
        void Complete();
    }
}
