using AutoMapper;
using ControlePedidos.Aplicacao.ViewModels;
using ControlePedidos.Dominio.Entidades;

namespace ControlePedidos.Aplicacao.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ClienteViewModel, Endereco>()
            .ForMember(dest => dest.EnderecoId, m => m.MapFrom(a => a.EnderecoId))
            .ForMember(dest => dest.CidadeId, m => m.MapFrom(a => a.CidadeId))
            .ForMember(dest => dest.Rua, m => m.MapFrom(a => a.Rua))
            .ForMember(dest => dest.Numero, m => m.MapFrom(a => a.Numero))
            .ForMember(dest => dest.CEP, m => m.MapFrom(a => a.Cep))
            .ForMember(dest => dest.Bairro, m => m.MapFrom(a => a.Bairro));

            Mapper.CreateMap<EnderecoViewModel, Endereco>();

            Mapper.CreateMap<ClienteViewModel, Cidade>()
              .ForMember(dest => dest.CidadeId, m => m.MapFrom(a => a.CidadeId))
              .ForMember(dest => dest.EstadoId, m => m.MapFrom(a => a.EstadoId))
              .ForMember(dest => dest.CidadeNome, m => m.MapFrom(a => a.CidadeNome));

            Mapper.CreateMap<ClienteViewModel, Estado>()
                .ForMember(dest => dest.EstadoId, m => m.MapFrom(a => a.EstadoId))
                .ForMember(dest => dest.UF, m => m.MapFrom(a => a.UF));

            Mapper.CreateMap<ProdutoViewModel, Produto>()
                .ForMember(dest => dest.NomeProduto, ori => ori.MapFrom(a => a.NomeProduto))
                .ForMember(dest => dest.Descricao, ori => ori.MapFrom(a => a.Descricao))
                .ForMember(dest => dest.ProdutoId, ori => ori.MapFrom(a => a.ProdutoId))
                .ForMember(dest => dest.Deletado, ori => ori.MapFrom(a => a.Deletado))
                .ForMember(dest => dest.Preco, ori => ori.MapFrom(a => a.Preco))
                .ForMember(dest => dest.ValorCusto, ori => ori.MapFrom(a => a.ValorCusto))
                .ForMember(dest => dest.LucroSugerido, ori => ori.MapFrom(a => a.LucroSugerido));


            Mapper.CreateMap<OrcamentoViewModel, Orcamento>();

            Mapper.CreateMap<ItemOrcamentoViewModel, ItemDoOrcamento>()
                .ForMember(dest => dest.ItemDoOrcamentoId, ori => ori.MapFrom(a => a.ItemDoOrcamentoId))
                .ForMember(dest => dest.NomeItem, ori => ori.MapFrom(a => a.NomeItem))
                .ForMember(dest => dest.Valor, ori => ori.MapFrom(a => a.Valor))
                .ForMember(dest => dest.Qtd, ori => ori.MapFrom(a => a.Qtd));

            Mapper.CreateMap<OrcamentoViewModel, ItemDoOrcamento>()
                .ForMember(dest => dest.OrcamentoId, ori => ori.MapFrom(a => a.OrcamentoId));

            Mapper.CreateMap<PedidoViewModel, NovoPedido>()
                .ForMember(dest => dest.NovoPedidoId, ori => ori.MapFrom(a => a.PedidoId))
                .ForMember(dest => dest.ClienteId, ori => ori.MapFrom(a => a.ClienteId))
                .ForMember(dest => dest.DataCompra, ori => ori.MapFrom(a => a.DataCompra))
                .ForMember(dest => dest.DataEntrega, ori => ori.MapFrom(a => a.DataEntrega))
                .ForMember(dest => dest.Frete, ori => ori.MapFrom(a => a.Frete));

            Mapper.CreateMap<ItemPedidoViewModel, ItemPedido>()
                .ForMember(dest => dest.ItemPedidoId, ori => ori.MapFrom(a => a.ItemPedidoId))
                .ForMember(dest => dest.nomeProduto, ori => ori.MapFrom(a => a.NomeProduto))
                .ForMember(dest => dest.NovoPedidoId, ori => ori.MapFrom(a => a.PedidoId))
                .ForMember(dest => dest.Qtd, ori => ori.MapFrom(a => a.QTD))
                .ForMember(dest => dest.Valor, ori => ori.MapFrom(a => a.Valor))
                .ForMember(dest => dest.ProdutoId, ori => ori.MapFrom(a => a.ProdutoId));

        }
    }
}
