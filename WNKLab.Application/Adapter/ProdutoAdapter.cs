using System.Collections.Generic;
using WNKLab.Application.ModelView;
using WNKLab.Domain.Entities;

namespace WNKLab.Application.Adapter
{
    public static class ProdutoAdapter
    {
        public static Produto ToProduto(ProdutoViewModel produtoViewModel)
        {
            var produto = new Produto()
            {
                ProdutoId = produtoViewModel.ProdutoId,
                Nome = produtoViewModel.Nome,
                Disponivel = produtoViewModel.Disponivel,
                Valor = produtoViewModel.Valor
            };

            return produto;
        }

        public static ProdutoViewModel ToProdutoViewModel(Produto produto)
        {
            var produtoViewModel = new ProdutoViewModel()
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Disponivel = produto.Disponivel,
                Valor = produto.Valor
            };

            return produtoViewModel;
        }

        public static List<Produto> ToProdutoList(List<ProdutoViewModel> produtoViewModelList)
        {
            List<Produto> produtos = new List<Produto>();

            foreach (var produtoViewModel in produtoViewModelList)
            {
                produtos.Add(ToProduto(produtoViewModel));
            }

            return produtos;
        }

        public static List<ProdutoViewModel> ToProdutoViewModelList(List<Produto> produtos)
        {
            List<ProdutoViewModel> produtosViewModel = new List<ProdutoViewModel>();

            foreach (var produto in produtos)
            {
                produtosViewModel.Add(ToProdutoViewModel(produto));
            }

            return produtosViewModel;
        }
    }
}
