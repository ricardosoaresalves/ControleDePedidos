
    RemoveTableRow = function (handler) {
        var tr = $(handler).closest('tr');

        tr.fadeOut(400, function () {
            tr.remove();
        });

        return false;
    };

    AddTableRow = function () {
        debugger;
        var newRow = $("<tr>");
        var cols = "";
        var nomeProduto = $("#txtNomeProduto").val();

        cols += '<td>' + nomeProduto + '</td>';
        cols += '<td>&nbsp;</td>';
        cols += '<td>&nbsp;</td>';

        cols += '<td class="actions">';
        cols += '<button class="btn btn-large btn-danger" onclick="RemoveTableRow(this)" type="button">Remover</button>';
        cols += '</td>';

        newRow.append(cols);

        $("#tbProduto").append(newRow);

        return false;
    };
    debugger;
    ListarTabela = function () {        
        $("#tbProduto tbody tr").each(function () {
            debugger;
            var colunas = $(this).children();
            var produto = $(colunas[0]).text();
            var PedidoViewModel = new Object();
            PedidoViewModel.NomeProduto = produto;
            alert(PedidoViewModel.NomeProduto);
        });
    }