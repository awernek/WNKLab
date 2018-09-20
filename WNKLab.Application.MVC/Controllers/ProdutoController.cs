using System.Linq;
using System.Web.Mvc;
using WNKLab.Application.Adapter;
using WNKLab.Application.Interfaces;

namespace WNKLab.Application.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoApplication produtoApplication;

        public ProdutoController(IProdutoApplication _produtoApplication)
        {
            this.produtoApplication = _produtoApplication;
        }

        // GET: Produto
        public ActionResult Index()
        {
            var produtosViewModel = ProdutoAdapter.ToProdutoViewModelList(produtoApplication.RetornarTodos().ToList());
            return View(produtosViewModel);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
