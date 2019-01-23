function formatarMoeda(valor) {
    if (valor != "") {
   
        var elemento = valor;
        var valor = elemento.value;

        valor = valor + '';
        valor = parseInt(valor.replace(/[\D]+/g, ''));
        valor = valor + '';
        valor = valor.replace(/([0-9]{2})$/g, ",$1");

        if (valor.length > 6) {
            valor = valor.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");
        }

        if (valor == "NaN")
            elemento.value = "";
        else
            elemento.value = valor;
    }
}


function RealToDolar(valor) {
    
    var num = new NumberFormat();
    num.setInputDecimal(',');
    num.setNumber(valor); // valor.value é '1.000,24'
    num.setPlaces('2', false);
    num.setCurrencyValue('');
    num.setCurrency(true);
    num.setCurrencyPosition(num.LEFT_OUTSIDE);
    num.setNegativeFormat(num.LEFT_DASH);
    num.setNegativeRed(false);
    num.setSeparators(false, ',', ',');
    valor = num.toFormatted(); //valor.value é '1000.24'
    return valor;
}

function DolarToReal(valor) {
    var num = new NumberFormat();
    num.setInputDecimal('.');
    num.setNumber(valor); // obj.value é '-1000.24'
    num.setPlaces('2', false);
    num.setCurrencyValue('');
    num.setCurrency(true);
    num.setCurrencyPosition(num.LEFT_OUTSIDE);
    num.setNegativeFormat(num.LEFT_DASH);
    num.setNegativeRed(false);
    num.setSeparators(true, '.', ',');
    valor = num.toFormatted(); //obj.value é '-1.000,24'
    return valor;
}