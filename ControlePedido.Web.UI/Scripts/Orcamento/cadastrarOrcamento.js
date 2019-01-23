var totalAnterior = 0;
var total = 0;
var Orcamento = CriaOrcamento();

$(document).ready(function () {
    $("#dvTabProdutos").hide();

});

function CriaOrcamento() {
    var OrcamentoViewModel = new Object();
    OrcamentoViewModel.OrcamentoId = 0;
    OrcamentoViewModel.NomeCliente = "";
    OrcamentoViewModel.Email = "";
    OrcamentoViewModel.Celular = "";
    OrcamentoViewModel.TelFixo = "";
    OrcamentoViewModel.ItensOrcamento = [];
    return OrcamentoViewModel;
}

function CriaItemOrcamento() {
    var ItemOrcamentoViewModel = new Object();
    ItemOrcamentoViewModel.ItemDoOrcamentoId = 0;
    ItemOrcamentoViewModel.NomeItem = "";
    ItemOrcamentoViewModel.Valor = "";
    ItemOrcamentoViewModel.Qtd = "";
    ItemOrcamentoViewModel.ProdutoId = "";
    ItemOrcamentoViewModel.OrcamentoId = 0;
    return ItemOrcamentoViewModel;
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


RemoveTableRow = function (handler) {

    var tr = $(handler).closest('tr');
    var colunas = tr.children();
    var Valor = $(colunas[2]).text();
    var qtd = $(colunas[1]).text();
    tr.fadeOut(400, function () {
        tr.remove();
    });
    var opcao = "r";
    CalculaTotalProdutos(Number.parseFloat(Valor), parseInt(qtd), opcao);
    return false;
};

AddTableRow = function () {
    if ($("#txtResultProduto").val() == "" || $("#txtQTD").val()=="") {
        alert("por favor informe o produto/QTD");
        return;
    }

    $("#dvTabProdutos").show();

    var prd = CriaItemOrcamento();
    prd.NomeItem = $("#txtResultProduto").val();
    prd.Valor = parseFloat($("#hdnPreco").val());
    prd.Qtd = parseInt($("#txtQTD").val());
    prd.ProdutoId = $("#hdnProdutoId").val();
    var newRow = $("<tr>");
    var cols = "";

    cols += '<td data-id=' + prd.ProdutoId + ' >' + prd.NomeItem + '</td>';
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


function PopulaObjeto() {

    Orcamento.NomeCliente = $("#txtNomeCliente").val();
    Orcamento.Email = $("#txtemail").val();
    Orcamento.Celular = $("#txtCelular").val();
    Orcamento.TelFixo = $("#txtFixo").val();

    $("#products-table tbody tr").each(function () {

        var colunas = $(this).children();
        var item = CriaItemOrcamento();
        item.NomeItem = $(colunas[0]).text();
        item.ProdutoId = $(colunas[0]).data("id");
        item.Qtd = $(colunas[1]).text();
        item.Valor = parseFloat($(colunas[2]).text());
        Orcamento.ItensOrcamento.push(item);
    });
}


$("#btnSalvar").click(function (evt) {
    evt.preventDefault();
    PopulaObjeto();
    
    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Orcamento/CadastrarOrcamento"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    $.ajax(
        {
            type: 'POST',
            url: "/Orcamento/CadastrarOrcamento",
            datatype: 'text',
            headers: headersadr,
            data: { OrcamentoViewModel: Orcamento, __RequestVerificationToken: token },
            success: function (data) {
                if (data.length == 0)
                    alert("deu boa!");
            },
            error: function (data) {
                alert(data.statusText);
            },
        }
     );
}
);
