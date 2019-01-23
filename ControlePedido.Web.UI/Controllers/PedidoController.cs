using System;
using System.Linq;
using System.Web.Mvc;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Aplicacao.Interface;
using Rotativa;
using Rotativa.Options;

namespace ControlePedido.Web.UI.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoAppServico _pedidoAppServico;
        private readonly IItemPedidoAppServico _itemAppServico;
        private readonly IClienteAppServico _clienteAppServico;

        public PedidoController(IPedidoAppServico pedidoAppServico,
                                IItemPedidoAppServico itemAppServico,
                                IClienteAppServico clienteAppServico)
        {
            _pedidoAppServico = pedidoAppServico;
            _itemAppServico = itemAppServico;
            _clienteAppServico = clienteAppServico;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult IncluirPedido(PedidoViewModel pedidoViewModel)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CadastrarPedido()
        {
            return View();
        }

        public ActionResult Listar()
        {
            var x = _pedidoAppServico.ListarTodos();
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarPedido(PedidoViewModel pedidoViewModel)
        {
            pedidoViewModel.DataCompra = DateTime.Today;

            if (ModelState.IsValid)
            {
                _pedidoAppServico.Adicionar(pedidoViewModel);
                return RedirectToAction("Index", "Pedido");

            }
            else
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors);
            }

            return View();
        }

        [HttpPost]
        public PartialViewResult ObterTodos()
        {
            var pedidos = _pedidoAppServico.ListarTodos();
            return PartialView("_listarPedidos", pedidos);
        }

        [HttpGet]
        public ActionResult EditarPedido(long id)
        {
            if (id > 0)
            {
                var viewModel = _pedidoAppServico.ObterPorId(id);
                return View(viewModel);
            }
            return View();
        }

        [HttpGet]
        public PartialViewResult ObterPedidoId(long pedidoId)
        {
            var pedido = _pedidoAppServico.ObterPorId(pedidoId);
            return PartialView("_DetalhesPedido", pedido);
        }

        [HttpGet]
        public PartialViewResult ObterCliente(string nomeCliente)
        {
            var clientesViewModel = _clienteAppServico.BuscaPorNome(nomeCliente);
            return PartialView("_BuscaClientes", clientesViewModel);
        }

        [HttpGet]
        public void Excluir(long pedidoId)
        {
            _pedidoAppServico.ExcluirPedido(pedidoId);
        }

        public ActionResult ImprimirPedido(long pedidoId)
        {
            var pedido = _pedidoAppServico.ObterPorId(pedidoId);
            return new Rotativa.ViewAsPdf("ImprimirPedido", pedido);
            
            //return new RazorPDF.PdfResult(pedido, "ImprimirPedido");
        }
        
    }
}