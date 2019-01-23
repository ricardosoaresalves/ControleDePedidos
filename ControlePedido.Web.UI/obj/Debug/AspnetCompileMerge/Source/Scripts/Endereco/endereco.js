$(document).ready(function () {

    function limpa_endereco() {
        // Limpa valores do formulário de cep.
        $("#txtLogradouro").val("");
        $("#txtBairro").val("");
        $("#txtCidade").val("");
        $("#txtUF").val("");
    }

    //Quando o campo cep perde o foco.
    $("#btnBuscarCep").click(function (evt) {
        evt.preventDefault();

        //Nova variável "cep" somente com dígitos.
        var cep = $("#txtCEP").val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#txtLogradouro").val("...");
                $("#txtBairro").val("...");
                $("#txtCidade").val("...");
                $("#txtUF").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("//viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#txtLogradouro").val(dados.logradouro);
                        $("#txtBairro").val(dados.bairro);
                        $("#txtCidade").val(dados.localidade);
                        $("#txtUF").val(dados.uf);
                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_endereco();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_endereco();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_endereco();
        }
    });
});