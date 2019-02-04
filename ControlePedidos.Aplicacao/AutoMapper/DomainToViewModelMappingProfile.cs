using AutoMapper;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Aplicacao.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>()
                .ForMember(dest => dest.ClienteId, m => m.MapFrom(a => a.ClienteId))
                .ForMember(dest => dest.Rua, m => m.MapFrom(a => a.Endereco.Rua))
                .ForMember(dest => dest.Cep, m => m.MapFrom(a => a.Endereco.CEP))
                .ForMember(dest => dest.Bairro, m => m.MapFrom(a => a.Endereco.Bairro))
                .ForMember(dest => dest.CidadeNome, m => m.MapFrom(a => a.Endereco.Cidade.CidadeNome))
                .ForMember(dest => dest.UF, m => m.MapFrom(a => a.Endereco.Estado.UF))
                .ForMember(dest => dest.EstadoId, m => m.MapFrom(a => a.Endereco.EstadoId))
                .ForMember(dest => dest.CidadeId, m => m.MapFrom(a => a.Endereco.CidadeId))
                .ForMember(dest => dest.Complemento, m => m.MapFrom(a => a.Endereco.Complemento))
                .ForMember(dest => dest.Numero, m => m.MapFrom(a => a.Endereco.Numero));

            Mapper.CreateMap<Endereco, EnderecoViewModel>();

            Mapper.CreateMap<Produto, ProdutoViewModel>();

            Mapper.CreateMap<Orcamento, OrcamentoViewModel>();

            Mapper.CreateMap<ItemDoOrcamento, ItemOrcamentoViewModel>()
                .ForMember(dest => dest.ItemDoOrcamentoId, m => m.MapFrom(a => a.ItemDoOrcamentoId))
                .ForMember(dest => dest.NomeItem, m => m.MapFrom(a => a.NomeItem))
                .ForMember(dest => dest.Valor, m => m.MapFrom(a => a.Valor))
                .ForMember(dest => dest.Qtd, m => m.MapFrom(a => a.Qtd))
                .ForMember(dest => dest.ProdutoId, m => m.MapFrom(a => a.ProdutoId))
                .ForMember(dest => dest.OrcamentoId, m => m.MapFrom(a => a.OrcamentoId));

            Mapper.CreateMap<NovoPedido, PedidoViewModel>()
                .ForMember(dest => dest.PedidoId, m => m.MapFrom(a => a.NovoPedidoId))
                .ForMember(dest => dest.ClienteId, m => m.MapFrom(a => a.ClienteId))
                .ForMember(dest => dest.Frete, m => m.MapFrom(a => a.Frete))
                .ForMember(dest => dest.DataCompra, m => m.MapFrom(a => a.DataCompra))
                .ForMember(dest => dest.DataEntrega, m => m.MapFrom(a => a.DataEntrega))
                .ForMember(dest => dest.Cliente, m => m.MapFrom(a => a.Cliente))
                .ForMember(dest => dest.NomeCliente, m => m.MapFrom(a => a.Cliente.Nome));
                


            Mapper.CreateMap<ItemPedido, ItemPedidoViewModel>()
                .ForMember(dest => dest.ItemPedidoId, ori => ori.MapFrom(a => a.ItemPedidoId))
                .ForMember(dest => dest.NomeProduto, ori => ori.MapFrom(a => a.nomeProduto))
                .ForMember(dest => dest.PedidoId, ori => ori.MapFrom(a => a.NovoPedidoId))
                .ForMember(dest => dest.QTD, ori => ori.MapFrom(a => a.Qtd))
                .ForMember(dest => dest.Valor, ori => ori.MapFrom(a => a.Valor))
                .ForMember(dest => dest.ProdutoId, ori => ori.MapFrom(a => a.ProdutoId));
        }
    }
}