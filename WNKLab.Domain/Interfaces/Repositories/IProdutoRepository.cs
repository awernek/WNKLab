using System.Collections.Generic;
using WNKLab.Domain.Entities;

namespace WNKLab.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> ProdutosDisponiveis();
    }
}
