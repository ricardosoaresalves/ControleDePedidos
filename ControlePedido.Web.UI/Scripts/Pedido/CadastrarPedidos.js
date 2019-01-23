$(document).ready(function () {
    $("#dvTabProdutos").hide();
    ObterInfoCliente();
});

var Pedido = CriaPedido();
var totalAnterior = 0;
var total = 0;


$("#btnBuscaCliente").click(function (evt) {
    evt.preventDefault();
    $('#spResult').empty();
    var nomeCliente = $("#txtNome").val();
    BuscarCliente(nomeCliente);
    $("#genericModal").modal('show');

});

$("#btnBuscaProduto").click(function (evt) {
    debugger;
    evt.preventDefault();
    $('#spResult').empty();
    var nomeProduto = $("#txtResultProduto").val();
    PesqisarProduto(nomeProduto);
    $("#genericModal").modal('show');

});


$("#txtDesconto").blur(function () {

    var preco = RealToDolar($("#txtPreco").val());
    var desc = RealToDolar($("#txtDesconto").val());

    if (preco == "") {
        preco = 0;
    }
    var total = preco - desc;
    $("#txtTotal").val(DolarToReal(total)).toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
});

ObterInfoCliente = function () {
    debugger;
    $(".selecionar").click(function (evt) {
        evt.preventDefault();
        $("#txtNome").val($(this).data("nome"));
        $("#txtCidade").val($(this).data("cidade"));
        $("#txtBairro").val($(this).data("bairro"));
        $("#txtLogradouro").val($(this).data("rua"));
        $("#txtNumero").val($(this).data("comp"));
        $("#hdnClienteId").val($(this).data("id"));
        $("#genericModal").modal('hide');
    });
}

obterInfoProduto = function () {
    $(".clicar").click(function (evt) {
        evt.preventDefault();
        var produtoId = $(this).data("id");
        var nome = $(this).data("nome");
        var preco = $(this).data("preco");
        $("#hdnProdutoId").val(produtoId);
        $("#hdnPreco").val(preco);
        $("#txtResultProduto").val(nome);
        $("#txtPreco").val(preco.toLocaleString("pt-BR", { minimumFractionDigits: 2, currency: 'BRL' }));
        $("#genericModal").modal('hide');
    });
}

function PesqisarProduto(nomeProduto) {
    debugger;
    $.ajax({
        type: 'GET',
        url: "/Produto/BuscarProduto/",
        dataType: 'html',
        cache: false,
        data: { "nomeProduto": nomeProduto },
        error: function (data) {
            alert(data.error);
        },
        beforeSend: function () {
            $('#spResult').empty();
        },
        success: function (data) {
            $('#spResult').html(data);
            obterInfoProduto();
        }
    });
}

function BuscarCliente(nomeCliente) {
    debugger;
    $.ajax({
        type: 'GET',
        url: "/Cliente/BuscaPorNome/",
        dataType: 'html',
        cache: false,
        data: { nomeCliente: nomeCliente },
        error: function (data) {
            alert(data.error);
        },
        beforeSend: function () {
            $('#spResult').empty();
        },
        success: function (data) {
            $('#spResult').html(data);
            debugger;
            ObterInfoCliente();
        }
    });
}



function CriaPedido() {
    var Pedido = new Object();
    Pedido.PedidoId = 0;
    Pedido.ClienteId = 0;
    Pedido.DataCompra = "";
    Pedido.DataEntrega = "";
    Pedido.Frete = 0;
    Pedido.Desconto = 0;
    Pedido.ItensPedido = [];
    return Pedido;
}

function CriaItemPedido() {
    var ItemPedidoViewModel = new Object();
    ItemPedidoViewModel.PedidoId = 0;
    ItemPedidoViewModel.ItemPedidoId = 0;
    ItemPedidoViewModel.NomeProduto = "";
    ItemPedidoViewModel.Valor = 0;
    ItemPedidoViewModel.Qtd = "";
    ItemPedidoViewModel.ProdutoId = 0;
    return ItemPedidoViewModel;
}

function CalculaTotalProdutos(Valor, qtd, opcao) {
    var totalAtual = total;
    if (opcao == "a") {
        total = Valor * qtd;
        if (totalAnterior > 0)
            total = totalAnterior + total;
    }
    else {
        total = totalAtual - (Valor * qtd);
    }
    opcao = "";
    $("#spTotal").text(total.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }));
    totalAnterior = total;
}

RemoveTableRow = function (handler) {
    var tr = $(handler).closest('tr');

    tr.fadeOut(400, function () {
        tr.remove();
    });

    return false;
};

AddTableRow = function () {

    if ($("#txtResultProduto").val() == "" || $("#txtQTD").val() == "") {
        alert("por favor informe o produto/QTD");
        return;
    }

    $("#dvTabProdutos").show();

    var valor = $("#txtTotal").val();
    var prd = CriaItemPedido();
    prd.NomeProduto = $("#txtResultProduto").val();
    prd.Valor = valor.toLocaleString('pt-br', { minimumFractionDigits: 2 });
    prd.Qtd = parseInt($("#txtQTD").val());
    prd.ProdutoId = $("#hdnProdutoId").val();
    var newRow = $("<tr>");
    var cols = "";

    cols += '<td data-id=' + prd.ProdutoId + ' >' + prd.NomeProduto + '</td>';
    cols += '<td>' + prd.Qtd + '</td>';
    cols += '<td>' + (prd.Valor).toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }) + '</td>';
    cols += '<td class="actions">';
    cols += '<button class="btn btn-large btn-danger" onclick="RemoveTableRow(this)" data-id=' + prd.ProdutoId + ' type="button">Remover</button>';
    cols += '</td>';

    newRow.append(cols);

    $("#products-table").append(newRow);

    var opcao = "a";
    CalculaTotalProdutos(Number.parseFloat(RealToDolar(prd.Valor)), parseInt(prd.Qtd), opcao);
    $("#txtQTD").val("");
    $("#txtResultProduto").val("");
    return false;
};


function PopulaObjetoPedido() {

    var frete = RealToDolar($("#txtFrete").val());
    Pedido.ClienteId = $("#hdnClienteId").val();
    Pedido.DataCompra = "";
    Pedido.DataEntrega = $("#datepicker").val();
    Pedido.Frete = $("#txtFrete").val();
    Pedido.Desconto = $("#txtDesconto").val();

    $("#products-table tbody tr").each(function () {

        var colunas = $(this).children();
        var item = CriaItemPedido();
        item.NomeProduto = $(colunas[0]).text();
        item.ProdutoId = $(colunas[0]).data("id");
        item.Qtd = $(colunas[1]).text();
        item.Valor = $(colunas[2]).text();
        Pedido.ItensPedido.push(item);
    });
}

$("#btFechar").click(function (evt) {

    evt.preventDefault();
    $("msgModal").modal("hide");
});

$("#btnSalvarPedido").click(function (evt) {
    debugger;
    evt.preventDefault();
    var clienteId = $("#hdnClienteId").val();
    if (clienteId == "") {
        $("#msgModal").modal("show");
        return;
    }
    else {
        PopulaObjetoPedido();
    }


    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Orcamento/CadastrarOrcamento"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    if (Pedido == "") {
        alert("Erro inesperado!");
        return;
    }

    $.ajax(
        {
            type: 'POST',
            url: "/Pedido/CadastrarPedido",
            datatype: 'json',
            headers: headersadr,
            data: { PedidoViewModel: Pedido, __RequestVerificationToken: token },
            success: function () {
                location.href = '/Pedido/Index';
            },
            error: function (data) {
                alert(data.statusText);
            },
        }
    );
}
);