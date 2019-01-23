/*$().ready(function () {
    
    var pedidoId = $("#hdnPedidoId").val();
    $("#dvTabProdutos").show();
    ObterItensPedido(pedidoId);
});*/

$(".clicar").click(function (evt) {
    
    evt.preventDefault();    
    var pedidoId = $(this).data("id");

    if (pedidoId > 0) {
        ObterItensPedido(pedidoId);
        $("#genericModal").modal('show');
    }

});

function ObterItensPedido(pedidoId) {
    
    if (pedidoId > 0) {
        $.ajax({
            type: 'GET',
            url: "/ItensPedido/ObterItensPedido/",
            dataType: 'html',
            cache: false,
            async: false,
            data: { pedidoId: pedidoId },
            error: function (data) {
                alert("deu erro" + data.error);
                $("#spResult").html("<div id='erro-mensagem'>" + data.error + " </div>");
            },
            beforeSend: function () {
                $("#spResult").html("<div id='erro-mensagem'><p style='color:gray;'><small><em><strong>Acessando Base de dados.<br />Aguarde, estou indo até o servidor... <i class='glyphicon glyphicon-refresh icon-refresh-animate'></i></strong></em></small></p></div>");
            },
            success: function (dados) {
                
                $("#spResult").empty();
                $("#spResult").hide().html(dados).fadeIn("slow");
                /*$(".detalhe").click(function (evt) {
                    evt.preventDefault();
                    var id = $(this).data("id");
                    $("#detalhesCliente").modal('show');
                    ExibirDetalhes(id);
                }); */
                /*   $(".excluir").click(function (evt) {
                       
                       evt.preventDefault();
                       var id = $(this).data("id");
                       var nome = $(this).data("nome");
                       $("#excluirCliente").modal('show');
                       ConfirmaExclusao(nome, id);
                   });*/
            }
        });
    }
}


function CriaItemPedido() {
    var ItemPedidoViewModel = new Object();
    ItemPedidoViewModel.PedidoId = 0;
    ItemPedidoViewModel.ItemPedidoId = 0;
    ItemPedidoViewModel.NomeProduto = "";
    ItemPedidoViewModel.Valor = "";
    ItemPedidoViewModel.Qtd = "";
    ItemPedidoViewModel.ProdutoId = "";
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

    var prd = CriaItemPedido();
    prd.NomeProduto = $("#txtResultProduto").val();
    prd.Valor = parseFloat($("#hdnPreco").val());
    prd.Qtd = parseInt($("#txtQTD").val());
    prd.ProdutoId = $("#hdnProdutoId").val();
    var newRow = $("<tr>");
    var cols = "";

    cols += '<td data-id=' + prd.ProdutoId + ' >' + prd.NomeProduto + '</td>';
    cols += '<td>' + prd.Qtd + '</td>';
    cols += '<td>' + prd.Valor.toLocaleString('pt-br', { minimumFractionDigits: 2 }) + '</td>';
    cols += '<td class="actions">';
    cols += '<button class="btn btn-large btn-danger" onclick="RemoveTableRow(this)" data-id=' + prd.ProdutoId + ' type="button">Remover</button>';
    cols += '</td>';

    newRow.append(cols);

    $("#products-table").append(newRow);

    var opcao = "a";
    CalculaTotalProdutos(Number.parseFloat(prd.Valor), parseInt(prd.Qtd), opcao);
    $("#txtQTD").val("");
    $("#txtResultProduto").val("");
    return false;
};