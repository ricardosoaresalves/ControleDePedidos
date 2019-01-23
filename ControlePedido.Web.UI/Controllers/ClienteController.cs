using ControlePedidos.Aplicacao.Interface;
using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ControlePedido.Web.UI.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        private readonly IClienteAppServico _clienteAppServico;
        private readonly IEnderecoAppServico _enderecoAppServico;
        private readonly IEstadoAppServico _estadoAppServico;
        private readonly ICidadeAppServico _cidadeAppServico;

        public ClienteController(IClienteAppServico clienteAppServico,
                                 IEnderecoAppServico enderecoAppServico
            )
        {
            _clienteAppServico = clienteAppServico;
            _enderecoAppServico = enderecoAppServico;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CadastrarCliente()
        {
            //return null;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarCliente(ClienteViewModel clienteViewModel)
        {

            if (ModelState.IsValid)
            {
                _clienteAppServico.Adicionar(clienteViewModel);
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View();
        }

        [HttpPost]
        public PartialViewResult ListarClientes()
        {
            var clientesViewModel = _clienteAppServico.ObterTodos();
            return PartialView("_listaClientes", clientesViewModel);
        }

        [HttpGet]
        public ActionResult EditarCliente(Int64 id)
        {
            var clienteViewModel = _clienteAppServico.ObterPorId(id);
            return View("EditarCliente", clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCliente(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppServico.Atualizar(clienteViewModel);
                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public PartialViewResult BuscaPorNome(String nomeCliente)
        {
            var clientesViewModel = _clienteAppServico.BuscaPorNome(nomeCliente);
            return PartialView("_listClientes", clientesViewModel);
        }

        [HttpGet]
        public PartialViewResult Detalhes(int id)
        {
            var cliente = _clienteAppServico.Detalhe(id);
            return PartialView("_Detalhes", cliente);
        }

        [HttpGet]
        public bool Excluir(int id)
        {
            var retorno = true;

            try
            {
                if (id > 0)
                {
                    _clienteAppServico.ExcluirCliente(id);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                retorno = false;
            }
            return retorno;
        }

    }

}