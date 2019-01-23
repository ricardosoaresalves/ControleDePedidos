using ControlePedidos.Aplicacao.Interface;
using ControlePedidos.Aplicacao.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ControlePedido.Web.UI.Controllers
{
    public class ItensOrcamentoController : Controller
    {
        private readonly IItemOrcamentoAppServico _itemOrcamentoAppServico;

        public ItensOrcamentoController(IItemOrcamentoAppServico itemOrcamentoAppServico)
        {
            _itemOrcamentoAppServico = itemOrcamentoAppServico;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult ObterItensOrcamento(int orcamentoId)
        {
            var itens = _itemOrcamentoAppServico.ObterItensOrcamento(orcamentoId);
            return PartialView("ObterItensOrcamento", itens);
        }
    }
}
