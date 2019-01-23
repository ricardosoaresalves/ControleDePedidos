
$(document).ready(function () {
    $("#dvTabProdutos").hide();

});

function CriaOrcamento() {
    var orcamento = new Object();
    orcamento.NomeCliente = "";
    orcamento.Email = "";
    orcamento.Celular = "";
    orcamento.TelefoneFixo = "";
    orcamento.Cpf = "";
    orcamento.Produtos = [];
    return orcamento;
}

function CriaProduto() {
    var produto = new Object();
    produto.NomeProduto = "";
    produto.Preco = "";
    produto.Qtd = "";
    produto.ProdutoId = "";
    return produto;
}



$("#btnBuscaProduto").click(function (evt) {
    evt.preventDefault();
    var nomeProduto = $("#txtResultProduto").val();
    $("#listModal").modal('show');
    PesqisarProduto(nomeProduto);
});

function PesqisarProduto(nomeProduto) {

    $.ajax({
        type: 'GET',
        url: "/Orcamento/BuscarProduto/",
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
        }
    });
}

function HabilitaDiv() {
    $("#dvTabProdutos").show();
}

function ValorTotalProdutos(preco, qtd) {
    debugger;
    var total = parseFloat(preco * qtd);
    $("#spTotal").html(total);
}

(function ($) {

    RemoveTableRow = function (handler) {
        var tr = $(handler).closest('tr');

        tr.fadeOut(400, function () {
            tr.remove();
        });

        return false;
    };

    AddTableRow = function () {
        debugger;
        var orc = CriaOrcamento();
        var prd = CriaProduto();
        prd.NomeProduto = $("#txtResultProduto").val();
        prd.Preco = parseFloat($("#hdnPreco").val());
        prd.Qtd = parseInt($("#txtQTD").val());
        prd.ProdutoId = $("#hdnProdutoId").val();
        ValorTotalProdutos(prd.Preco, prd.Qtd);
        var newRow = $("<tr>");
        var cols = "";

        cols += '<td>' + prd.NomeProduto + '</td>';
        cols += '<td>' + prd.Qtd + '</td>';
        cols += '<td>' + prd.Preco + '</td>';

        cols += '<td class="actions">';
        cols += '<button class="btn btn-large btn-danger" onclick="RemoveTableRow(this)" type="button">Remover</button>';
        cols += '</td>';

        newRow.append(cols);

        $("#products-table").append(newRow);
        debugger;
        orc.Produtos.push(prd);

        return false;
    };

})(jQuery);