using Ninject.Modules;
using ControlePedidos.Aplicacao.Interface;
using ControlePedidos.Aplicacao;
using ControlePedidos.Dominio.Interfaces.Servico;
using ControlePedidos.Dominio.Servicos;
using ControlePedidos.Dominio.Interfaces.Repositorio;
using ControlePedidos.Data.Repositorios;
using ControlePedidos.Infra.Data.Interfaces;
using ControlePedidos.Infra.Data.Contexto;
using ControlePedidos.Data.UoW;

namespace ControlePedidos.Infra.CrossCutting.IOC
{
    public class NinjectModulo : NinjectAppModule
    {
        public override void Load()
        {
            //domain service
            Bind<IClienteServico>().To<ClienteServico>();
            Bind<ICidadeServico>().To<CidadeServico>();
            Bind<IEnderecoServico>().To<EnderecoServico>();
            Bind<IEstadoServico>().To<EstadoServico>();
            Bind<IProdutoServico>().To<ProdutoServico>();
            Bind<IOrcamentoServico>().To<OrcamentoServico>();
            Bind<IItemOrcamentoServico>().To<ItemOrcamentoServico>();
            Bind<IPedidoServico>().To<PedidoServico>();
            Bind<IItemPedidoServico>().To<ItemPedidoServico>();

            //data
            Bind<ICidadeRepositorio>().To<CidadeRepositorio>();
            Bind<IClienteRepositorio>().To<ClienteRepositorio>();
            Bind<IEnderecoRepositorio>().To<EnderecoRepositorio>();
            Bind<IEstadoRepositorio>().To<EstadoRepositorio>();
            Bind<IProdutoRepositorio>().To<ProdutoRepositorio>();
            Bind<IOrcamentoRepositorio>().To<OrcamentoRepositorio>();
            Bind<IItemOrcamentoRepositorio>().To<ItemOrcamentoRepositorio>();
            Bind<IPedidoRepositorio>().To<PedidoRepositorio>();
            Bind<IItemPedidoRepositorio>().To<ItemPedidoRepositorio>();

            Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            
            //Data
            Bind<IContextManager>().To<GerenciadorContexto>();
            Bind<IUnitOfWork>().To<UnitOfWork>();

        }
    }
}
