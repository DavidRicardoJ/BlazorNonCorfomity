function MascaraCnpj() {
    var cnpj = document.getElementById("cnpj");

    if (cnpj.value.length != 3 || cnpj.value.length != 7 || cnpj.value.length != 11 || cnpj.value.length != 16) {

        if (isNaN(cnpj.value[cnpj.value.length - 1])) {
            cnpj.value = cnpj.value.substring(0, cnpj.value.length - 1)
        }
    }

    if (cnpj.value.length == 2 || cnpj.value.length == 6) {
        cnpj.value += ".";
    } else if (cnpj.value.length == 10) {
        cnpj.value += "/";
    } else if (cnpj.value.length == 15) {
        cnpj.value += "-";
    }
}

function Focus(id) {
    var element = document.getElementById(id);
    console.log(element);
    element.focus();
}