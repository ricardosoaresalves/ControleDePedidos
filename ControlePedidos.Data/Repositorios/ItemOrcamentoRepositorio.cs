using ControlePedidos.Dominio.Entidades;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace ControlePedidos.Data.Repositorios
{
    public class ItemOrcamentoRepositorio : RepositorioBase<ItemDoOrcamento>, IItemOrcamentoRepositorio
    {
        public void Adicionar(IEnumerable<ItemDoOrcamento> ItensOrcameto)
        {
            var db = contexto;
            db.ItemDoOrcamento.AddRange(ItensOrcameto);
        }

        public IEnumerable<ItemDoOrcamento> ObterItensOrcamento(long orcamentoId)
        {
            var db = contexto;

            var itens = (from i in db.ItemDoOrcamento
                         where i.OrcamentoId.Equals(orcamentoId)
                         select i);
            return itens;
        }
    }
}
