$().ready(function () {
    listaProdutos();
});

$("#lnkCalcValorProduto").click(function (evf) {
    evf.preventDefault();
    if ($("#txtValorCusto").val() == "" || $("#txtLucro").val() == "") {
        alert("informe os valores em branco");
        return;
    }
    calculaCustoFinalProduto();
});

$("#btnSalvarPrd").click(function (evt) {
    debugger;
    evt.preventDefault();
    var ret = ValidaCadastro();
    if (ValidaCadastro()) {
        SalvaPrd();
    }

});



ValidaCadastro = function () {
    var retorno = false;
    var nomePrd = $("#txtNome").val();
    var valorCursto = $("#txtValorCusto").val();
    var lucro = $("#txtLucro").val();

    if (nomePrd == "") {
        mensagem("Informe o nome do produto", "alerta");
        return false;
    }

    if (valorCursto == "") {
        mensagem("Informe o valor de custo", "alerta");
        return false;
    }

    if (lucro == "") {
        mensagem("Informe o lucro", "alerta");
        return false;
    }
    return true;
}

mensagem = function (texto, tipo) {

    if (tipo != "alerta") {
        $("#msgModal").removeClass("modal fade modal-warning").addClass("modal modal-danger fade in");
    }

    $("#spMsg").empty();
    $("#spMsg").html(texto);
    $("#msgModal").modal("show");
}


function formatReal(int) {
    var tmp = int + '';
    tmp = tmp.replace(/([0-9]{2})$/g, ",$1");
    if (tmp.length > 6)
        tmp = tmp.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");

    return tmp;
}


function calculaCustoFinalProduto() {
    debugger;
    var valorCusto = RealToDolar($("#txtValorCusto").val());
    var lucro = parseInt($("#txtLucro").val());
    var valorFinal = parseFloat(valorCusto) + parseFloat(valorCusto * (lucro / 100));

    var valor = valorFinal.toLocaleString("pt-BR", { minimumFractionDigits: 2, style: 'currency', currency: 'BRL' });
    $("#txtPreco").val(valor);
    alert(valor);
}

CriaObjetoProduto = function () {
    var produto = new Object();
    produto.ProdutoId = 0;
    produto.NomeProduto = "";
    produto.Descricao = "";
    produto.Preco = 0;
    produto.ValorCusto = 0;
    produto.LucroSugerido = 0;
    return produto;
}

function listaProdutos() {

    $.ajax({
        type: 'POST',
        url: "/Produto/ObterTodos/",
        dataType: 'html',
        cache: false,
        async: false,
        error: function (data) {
            alert(data.error);
        },
        beforeSend: function () {
            $('#lstPrdouto').empty();
        },
        success: function (data) {
            $("#lstPrdouto").html(data);
            $("#btFechar").click(function (evt) {
                evt.preventDefault();
                $("#msgModal").modal("hide");
            });
        }
    });
}

SalvaPrd = function () {
    var prd = CriaObjetoProduto();
    var custo = RealToDolar($("#txtValorCusto").val()).replace(".", ",");
    var preco = RealToDolar($("#txtPreco").val()).replace(".", ",");
    prd.NomeProduto = $("#txtNome").val();
    prd.Descricao = $("#Descricao").val();
    prd.ValorCusto = custo;
    prd.LucroSugerido = $("#txtLucro").val();
    prd.Preco = preco;

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Pedido/Create"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    $.ajax({
        type: 'POST',
        url: "/Produto/CadastrarProduto/",
        dataType: 'json',
        data: { produtoViewModel: prd, __RequestVerificationToken: token },
        headers: headersadr,
        cache: false,
        async: false,
        error: function (data) {
            alert(data.error);
        },
        success: function (data) {
            debugger;
            if (data) {
                location.href = '/Produto/Index';
            }

        }
    });
}


