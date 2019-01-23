using ControlePedidos.Aplicacao.Interface;
using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlePedido.Web.UI.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly IClienteAppServico  _clienteAppServico;
        private readonly IEnderecoAppServico _enderecoAppServico;
        private readonly IEstadoAppServico   _estadoAppServico;
        private readonly ICidadeAppServico   _cidadeAppServico;
        private readonly IProdutoAppServico  _produtoAppServico;
        private readonly IOrcamentoAppServico _orcamentoAppServico;


        public OrcamentoController(IClienteAppServico  clienteAppServico,
                                   IEnderecoAppServico enderecoAppServico,
                                   IEstadoAppServico   estadoAppServico,
                                   ICidadeAppServico   cidadeAppServico,
                                   IProdutoAppServico  produtoAppServico,
                                   IOrcamentoAppServico  orcamentoAppServico
                                 )
        {
            _clienteAppServico  = clienteAppServico;
            _enderecoAppServico = enderecoAppServico;
            _estadoAppServico   = estadoAppServico;
            _cidadeAppServico   = cidadeAppServico;
            _produtoAppServico  = produtoAppServico;
            _orcamentoAppServico = orcamentoAppServico;
        }

        public ActionResult Index()
        {
            var orcamentos = _orcamentoAppServico.ObterTodos();
            return View(orcamentos);
        }


        [HttpGet]
        public ActionResult CadastrarOrcamento()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult BuscarProduto(string nomeProduto)
        {
            var retorno = _produtoAppServico.ObterProdutoPorNome(nomeProduto);
            return PartialView("BuscarProduto", retorno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarOrcamento(OrcamentoViewModel orcamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                _orcamentoAppServico.Adcionar(orcamentoViewModel);
                return RedirectToAction("Index");
            }
            else
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var orcamento = _orcamentoAppServico.ObterPorId(id);
            return View(orcamento);

        }

        public ActionResult ListarOrcamentos()
        {
            var orcamentos =  _orcamentoAppServico.ObterTodos();
            return View(orcamentos);
        }
    }
}
