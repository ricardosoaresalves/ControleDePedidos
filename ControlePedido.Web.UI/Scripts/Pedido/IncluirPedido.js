$(document).ready(function () {
    $("#dvTabProdutos").hide();
});

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


ObterDadosCliente = function () {
    debugger;
    $(".selecionarCliente").click(function (evt) {
        evt.preventDefault();
        $("#txtNome").val($(this).data("nome"));
        $("#txtCidade").val($(this).data("cidade"));
        $("#txtBairro").val($(this).data("bairro"));
        $("#txtLogradouro").val($(this).data("Rua"));
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
            ObterDadosCliente();
        }
    });
}
