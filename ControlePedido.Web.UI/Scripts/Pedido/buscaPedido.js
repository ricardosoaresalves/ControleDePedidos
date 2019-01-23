$().ready(function () {
    ListarPedidos();
});


var CarregaDetalhes = function () {
    $(".detalhe").click(function (evt) {

        evt.preventDefault();
        var pedidoId = $(this).data("id");
        if (pedidoId > 0) {
            ObterPedidoId(pedidoId);
            $("#genericModal").modal('show');
        }
    });
}

/*
$("#btnImprimir").click(function (evt) {
    evt.preventDefault();
    debugger;
    $.ajax({
        type: 'POST',
        url: "/Pedido/Imprimir/",
        dataType: 'html',
        cache: false,
        async: false,
        error: function (data) {
            alert("deu erro" + data.error);
        },
        success: function () { }
    });
})
*/

var ListarPedidos = function () {

    $.ajax({
        type: 'POST',
        url: "/Pedido/ObterTodos/",
        dataType: 'html',
        cache: false,
        async: false,
        error: function (data) {
            alert("deu erro" + data.error);
            $("#lstPedidos").html("<div id='erro-mensagem'>" + data.error + " </div>");
        },
        beforeSend: function () {
            $("#lstPedidos").html("<div id='erro-mensagem'><p style='color:gray;'><small><em><strong>Acessando Base de dados.<br />Aguarde, estou indo até o servidor... <i class='glyphicon glyphicon-refresh icon-refresh-animate'></i></strong></em></small></p></div>");

        },
        success: function (dados) {
            $("#lstPedidos").empty();
            $("#lstPedidos").hide().html(dados).fadeIn("slow");
            CarregaDetalhes();
        }
    });
}

function ObterPedidoId(pedidoId) {

    $.ajax({
        type: 'GET',
        url: "/Pedido/ObterPedidoId/",
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
            BuscarItensPedido(pedidoId);
        }
    });
}
