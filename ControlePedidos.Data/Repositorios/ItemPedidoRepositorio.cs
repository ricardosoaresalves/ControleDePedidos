using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePedidos.Data.Repositorios
{
    public class ItemPedidoRepositorio : RepositorioBase<ItemPedido>, IItemPedidoRepositorio
    {
        public void Adicionar(IEnumerable<ItemPedido> ItensPedido)
        {
            try
            {
                var db = contexto;
                db.ItensPedidos.AddRange(ItensPedido);
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public IEnumerable<ItemPedido> ObterItensPedido(long pedidoId)
        {
            var db = contexto;
            var itens = (from i in db.ItensPedidos
                         where i.NovoPedidoId.Equals(pedidoId)
                         select i);
            return itens;
        }
    }
}
