using Dapper;
using System.Collections.Generic;
using System.Data;
using WNKLab.Domain.Entities;
using WNKLab.Domain.Interfaces.Repositories;
using WNKLab.Infra.Repository.Infrastructure;

namespace WNKLab.Infra.Repository.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        IConnectionFactory _connectionFactory;

        public ProdutoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Produto> ProdutosDisponiveis()
        {
            var query = "usp_GetAllBlogPostByPageIndex";
            var param = new DynamicParameters();
            //param.Add("@PageIndex", pageIndex);
            //param.Add("@PageSize", pageSize);
            var list = SqlMapper.Query<Produto>(_connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return list;
        }
    }
}
