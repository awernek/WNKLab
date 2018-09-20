using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WNKLab.Application.Adapter;
using WNKLab.Application.Interfaces;
using WNKLab.Application.ModelView;

namespace WNKLab.Application.API.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IProdutoApplication produtoApplication;

        public ProdutoController(IProdutoApplication _produtoApplication)
        {
            this.produtoApplication = _produtoApplication;
        }

        // GET: api/Produto
        public List<ProdutoViewModel> Get()
        {
            var produtosViewModel = ProdutoAdapter.ToProdutoViewModelList(produtoApplication.RetornarTodos().ToList());
            return produtosViewModel;

            //return new string[] { "value1", "value2" };
        }

        // GET: api/Produto/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Produto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Produto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Produto/5
        public void Delete(int id)
        {
        }
    }
}
