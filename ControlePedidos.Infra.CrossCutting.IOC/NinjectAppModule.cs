using Ninject.Modules;
using ControlePedidos.Aplicacao;
using ControlePedidos.Aplicacao.Interface;

namespace ControlePedidos.Infra.CrossCutting.IOC
{
    public class NinjectAppModule : NinjectModule
    {
        public override void Load()
        {
            //App
            Bind<IClienteAppServico>().To<ClienteAppServico>();
            Bind<IProdutoAppServico>().To<ProdutoAppServico>();            
            Bind<IEnderecoAppServico>().To<EnderecoAppService>();
            Bind<IEstadoAppServico>().To<EstadoAppServico>();
            Bind<ICidadeAppServico>().To<CidadeAppServico>();
            Bind<IOrcamentoAppServico>().To<OrcamentoAppServico>();
            Bind<IItemOrcamentoAppServico>().To<ItemOrcamentoAppServico>();
            Bind<IPedidoAppServico>().To<PedidoAppServico>();
            Bind<IItemPedidoAppServico>().To<ItemPedidoAppServico>();

        }
    }
}
