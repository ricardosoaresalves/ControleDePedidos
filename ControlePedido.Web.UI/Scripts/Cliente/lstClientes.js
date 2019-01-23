$().ready(function () {
    carregarClientes();
});


$("#lnkEditar").click(function (evt) {
    evt.preventDefault();
    var id = $(this).data("id");
    BuscarCliente(id);
});

var carregarClientes = function () {

    $.ajax({
        type: 'POST',
        url: "/Cliente/ListarClientes/",
        dataType: 'html',
        cache: false,
        async: false,
        error: function (data) {
            alert("deu erro" + data.error);
            $("#lstClientes").html("<div id='erro-mensagem'>" + data.error + " </div>");
        },
        beforeSend: function () {
            $("#lstClientes").html("<div id='erro-mensagem'><p style='color:gray;'><small><em><strong>Acessando Base de dados.<br />Aguarde, estou indo até o servidor... <i class='glyphicon glyphicon-refresh icon-refresh-animate'></i></strong></em></small></p></div>");
        },
        success: function (dados) {

            $("#lstClientes").hide().html(dados).fadeIn("slow");
            /*$(".detalhe").click(function (evt) {
                evt.preventDefault();
                var id = $(this).data("id");
                $("#detalhesCliente").modal('show');
                ExibirDetalhes(id);
            }); */
            $(".excluirCliente").click(function (evt) {
                debugger;
                evt.preventDefault();
                var id = $(this).data("id");
                var nome = $(this).data("nome");
                ConfirmaExclusao(nome, id);
            });
        }
    });
}

var ConfirmaExclusao = function (nome, id) {
    $("#spDelete").empty();
    $("#spDelete").text(nome);
    $("#excluirCliente").modal('show');
    $("#btExcluir").click(function () {
        $("#excluirCliente").modal('hide');
        excluirCliente(id);
    });
}

var excluirCliente = function (id) {
    debugger;
    $.ajax({
        type: 'GET',
        url: "/Cliente/Excluir/",
        datatype: 'text',
        cache: false,
        data: { "id": id },
        async: false,
        error: function (data) { alert(data.error); },
        success: function (dados) {
            debugger;
            if (dados) {
                carregarClientes();
            }
        }
    });
}
var ExibirDetalhes = function (id) {
    $.ajax({
        type: 'GET',
        url: "/Cliente/Detalhes/",
        dataType: 'html',
        cache: false,
        data: { "id": id },
        async: true,
        error: function (data) {
            alert(data.error);
        },
        beforeSend: function () {
            $('#spResult').empty();
        },
        success: function (dados) {
            $('#spResult').html(dados);
        }

    });
}

var BuscarCliente = function (id) {
    $.ajax({
        type: 'GET',
        url: "/Cliente/Editar/",
        datatype: 'json',
        cache: false,
        data: { "id": id },
        async: true,
        error: function (data) {
            alert(data.error);
        },
        success: function (dados) {
            alert(dados.Nome);
            $("txtNome").val(dados.Nome);
        }
    });
}
