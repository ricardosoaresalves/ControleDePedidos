$().ready(function () {

    var url = window.location.pathname;

    if (url.indexOf("Edit")) {
        var id = url.split("/")[3];
        BuscarItemOrcamento(id);
    }
});

function BuscarItemOrcamento(id) {
    
    $.ajax({
        type: 'GET',
        url: "/ItensOrcamento/ObterItensOrcamento/",
        datatype: 'html',
        cache: false,
        async: false,
        data: { orcamentoId: id },
        error: function (data) {
            alert("deu erro" + data.error);
            $("#dvItens").html("<div id='erro-mensagem'>" + data.error + " </div>");
        },
        beforeSend: function () {
            
            $("#dvItens").html("<div id='erro-mensagem'><p style='color:gray;'><small><em><strong>Acessando Base de dados.<br />Aguarde, estou indo até o servidor... <i class='glyphicon glyphicon-refresh icon-refresh-animate'></i></strong></em></small></p></div>");
            $("#dvItens").empty();
        },
        success: function (data) {
            
            $("#dvItens").hide().html(data).fadeIn("slow");
        }

    });
}