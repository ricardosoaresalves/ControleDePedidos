$("#btnSalvarCliente").click(function (evt) {
    debugger;
    evt.preventDefault();
    SalvarCliente();
});



criaObjetoCliente = function () {
    var Cliente = new Object();
    Cliente.ClienteId = 0;
    Cliente.Nome = "";
    Cliente.DDDCelular = 0;
    Cliente.DDDTelefoneFixo = 0;
    Cliente.Celular = 0;
    Cliente.Telefone = 0;
    Cliente.EnderecoId = 0;
    Cliente.EstadoId = 0;
    Cliente.CidadeId = 0;
    Cliente.Logradouro = "";
    Cliente.Cep = "";
    Cliente.CidadeNome = "";
    Cliente.Bairro = "";
    Cliente.UF = "";
    Cliente.Numero = "";
    Cliente.Complemento = "";
    Cliente.Referencia = "";
    return Cliente;
}

PopularObjCliente = function () {

    var cli = criaObjetoCliente();
    cli.Nome = $("#txtNome").val();
    cli.Celular = $("#txtCelular").val();
    cli.Telefone = $("#txtTelefone").val();
    cli.Cep = $("#txtCEP").val();
    cli.UF = $("#txtUF").val();
    cli.CidadeNome = $("#txtCidade").val();
    cli.Bairro = $("#txtBairro").val();
    cli.Logradouro = $("#txtLogradouro").val();
    cli.Numero = $("#txtNumero").val();
    cli.Referencia = $("#txtReferencia").val();
    cli.EnderecoId = 0;
    cli.EstadoId = 0;
    cli.CidadeId = 0;

    return cli;
}


Valida = function () {
    debugger;

    var cli = PopularObjCliente();
    var texto = "";

    if (cli.Nome == "" &&
        cli.Celular == "" &&
        cli.Bairro == "" &&
        cli.Logradouro == "" &&
        cli.UF == "" &&
        cli.Numero == "") {

        texto = "Infome: O Nome, Celular, Bairro, Logradouro, UF e numero/complemento ";
        mensagem(texto, "alerta");
        texto = "";
        return false;
    }

    if (cli.Nome == "") {
        texto = "Infome: O Nome";
        mensagem(texto, "alerta");
        texto = "";
        return false;
    }

    if (cli.Celular == "") {
        texto = "Informe o Celular";
        mensagem(texto, "alerta");
        texto = "";
        return false;
    }

    if (cli.Logradouro == "") {
        texto = "Informe Rua, travesa, avenida...";
        mensagem(texto, "alerta");
        texto = "";
        return false;
    }

    if (cli.UF == "") {
        texto = "Informe o UF";
        mensagem(texto, "alerta");
        texto = "";
        return false;
    }

    if (cli.Numero == "") {
        texto = "Informe o complemento";
        mensagem(texto, "alerta");
        texto = "";
        return false;
    }
    return true;
}

mensagem = function (texto, tipo) {
    debugger;
    if (tipo != "alerta") {
        $("#msgModal").removeClass("modal fade modal-warning").addClass("modal modal-danger fade in");
    }

    $("#spMsg").empty();
    $("#spMsg").html(texto);
    $("#msgModal").modal("show");
}


SalvarCliente = function () {
    debugger;

    var x = Valida();

    if (Valida()) {
        var cliente = PopularObjCliente();
        EnviaCliente(cliente);
    }
}

function EnviaCliente(cliente) {

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Pedido/Create"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    $.ajax({
        type: 'POST',
        url: "/Cliente/CadastrarCliente/",
        dataType: 'json',
        data: { ClienteViewModel: cliente, __RequestVerificationToken: token },
        headers: headersadr,
        cache: false,
        async: false,
        error: function (data) {
            alert(data.error);
        },
        success: function (data) {
            debugger;
            if (data) {
                location.href = '/Cliente/Index';
            }

        }
    });
}