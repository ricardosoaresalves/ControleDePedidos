var obter = function () {
    $(".selecionar").click(function (evt) {
        debugger;
        evt.preventDefault();
        alert($(this).data("nome"));;
        $("#txtNome").val($(this).data("nome"));
        $("#txtCidade").val($(this).data("cidade"));
        $("#txtBairro").val($(this).data("bairro"));
        $("#txtLogradouro").val($(this).data("rua"));
        $("#txtNumero").val($(this).data("comp"));
        $("#hdnClienteId").val($(this).data("id"));
        $("#genericModal").modal('hide');
    });
}

$("#btnBuscaCliente").click(function (evt) {
    evt.preventDefault();
    $('#spResult').empty();
    var nomeCliente = $("#txtNome").val();
    PesquisarCliente(nomeCliente);


});

var PesquisarCliente = function (nomeCliente) {
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
            debugger;
            $('#spResult').html(data);
            $("#genericModal").modal('show');
            obter();

        }
    });
}

