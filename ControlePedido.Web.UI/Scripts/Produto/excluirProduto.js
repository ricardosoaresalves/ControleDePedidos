$(".excluir").click(function (evt) {
    debugger;
    evt.preventDefault();

    var produtoId = $(this).data("id");
    var nomeProduto = $(this).data("nome");

    if (produtoId != "") {
        $("#excluirModal").modal("show");
        msgExcluir(nomeProduto, produtoId);
    }

});

function msgExcluir(nome, produtoId) {
    $("#spDelete").html(nome);
    $("#btExcluir").click(function () {
        ExcluirProduto(produtoId);
    });
}

function ExcluirProduto(produtoId) {
    $("#excluirModal").modal('hide');

    $.ajax({
        type: 'GET',
        url: "/Produto/ExcluirProduto/",
        cache: false,
        async: false,
        data: { id: produtoId },
        error: function (data) {
            alert(data.error);
        },
        beforeSend: function () {
            $('#spMsg').empty();
            $("#msgModal").removeClass("modal fade modal-warning fade in");
        },
        success: function () {
            $("#msgModal").addClass("modal modal-success fade in");
            $("#spMsg").html("Excluido com sucesso");
            $("#msgModal").modal('show');
        },
        complete: function () {
            listaProdutos();
        },

    });
}
