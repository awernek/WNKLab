using System.Collections.Generic;
using WNKLab.Domain.Entities;

namespace WNKLab.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> ProdutosDisponiveis();
    }
}
