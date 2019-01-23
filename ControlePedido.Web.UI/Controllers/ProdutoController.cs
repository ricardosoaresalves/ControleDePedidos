using ControlePedidos.Aplicacao.Interface;
using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlePedido.Web.UI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppServico _produtoAppService;

        public ProdutoController(IProdutoAppServico produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public ActionResult Index()
        {
            /*var viewModel = _produtoAppService.ObterTodos();
            return View(viewModel);
            */
            return View();
        }

        [HttpGet]
        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarProduto(ProdutoViewModel produtoViewModel)
        {
            
            if (ModelState.IsValid)
            {
                _produtoAppService.Adicionar(produtoViewModel);
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditarProduto(long id)
        {
            var viewModal = _produtoAppService.ObterPorId(id);
            return View("EditarProduto", viewModal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProduto(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _produtoAppService.Atualizar(produtoViewModel);
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            return View();
        }

        [HttpGet]
        public PartialViewResult BuscarProduto(string nomeProduto)
        {
            var produtos = _produtoAppService.ObterProdutoPorNome(nomeProduto);
            return PartialView("BuscarProduto", produtos);
        }

        [HttpGet]
        public void ExcluirProduto(long id)
        {
            if (id > 0)
            {
                _produtoAppService.ExcluirProduto(id);
            }
        }

        [HttpPost]
        public PartialViewResult ObterTodos()
        {
            var produtos = _produtoAppService.ObterTodos();
            return PartialView("_listProdutos", produtos);
        }
    }
}