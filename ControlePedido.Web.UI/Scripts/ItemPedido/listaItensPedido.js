BuscarItensPedido = function (id) {
    
    $.ajax({
        type: 'GET',
        url: "/ItensPedido/ObterItensPedido/",
        datatype: 'html',
        cache: false,
        async: false,
        data: { pedidoId: id },
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
        },
        complete: function () {
            
            TotalItensPedidos();
        },
    });
}

TotalItensPedidos = function () {
    
    $("#products-table tbody tr").each(function () {
        
        var total = 0;
        var valorAtual = 0;
        var colunas = $(this).children();
        valorAtual = $(colunas[2]).text();
        total = +valorAtual;
        $("#spTotal").text(total.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }));
    });
}