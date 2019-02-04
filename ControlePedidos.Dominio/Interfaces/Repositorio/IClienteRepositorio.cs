using ControlePedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ControlePedidos.Dominio.Interfaces.Repositorio
{
    public interface IClienteRepositorio:IRepositorioBase<Cliente>
    {
        Cliente Detalhe(long? id);        
        IEnumerable<Cliente> BuscaPorNome(String nomeCliente);
        void ExcluirCliente(int id);
    }
}
