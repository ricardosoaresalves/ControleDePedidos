$(".clicar").click(function (evt) {
    evt.preventDefault();
    evt.stopPropagation();
    var produtoId = $(this).data("id");
    var nome = $(this).data("nome");
    var preco = $(this).data("preco");
    $("#hdnProdutoId").val(produtoId);
    $("#hdnPreco").val(preco);
    $("#txtResultProduto").val(nome);
    $("#listModal").modal('hide');
    
});

