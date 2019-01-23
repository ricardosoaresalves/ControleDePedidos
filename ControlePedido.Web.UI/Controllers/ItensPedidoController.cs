using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Aplicacao.Interface;

namespace ControlePedido.Web.UI.Controllers
{
    public class ItensPedidoController : Controller
    {
        private readonly IItemPedidoAppServico _itemPedidoAppServico;

        public ItensPedidoController(IItemPedidoAppServico itemPedidoAppServico)
        {
            _itemPedidoAppServico = itemPedidoAppServico;
        }

        [HttpGet]
        public PartialViewResult ObterItensPedido(long pedidoId)
        {
            if (pedidoId > 0)
            {
                return PartialView(
                                    "_ListarItensPedido",
                                    _itemPedidoAppServico.ObterItensPedido(pedidoId)
                                  );
            }
            return PartialView();
        }
    }
}
