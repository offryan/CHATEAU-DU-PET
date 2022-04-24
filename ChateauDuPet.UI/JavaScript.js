
function validarSenha() {

    let senha = document.getElementById('senha');
    let senhaC = document.getElementById('senhaC');

    if (senha.value != senhaC.value) {
        senhaC.setCustomValidity("Senhas diferentes!");
        senhaC.reportValidity();
        return false;
    } else {
        senhaC.setCustomValidity("");
        return true;
    }
    // verificar também quando o campo for modificado, para que a mensagem suma quando as senhas forem iguais
    senhaC.addEventListener('input', validarSenha);

}

$(document).ready(function () {
    $('.date').mask('00/00/0000');
    $('.time').mask('00:00:00');
    $('.cep').mask('00000-000');
    $('.phone').mask('(00) 00000-0000');
    $('.cpf').mask('000.000.000-00');
    $('.money').mask('000.000.000.000,00');
});

function verificaForcaSenha() {
    var numeros = /([0-9])/;
    var alfabeto = /([a-zA-Z])/;
    var chEspeciais = /([~,!,@,#,$,%,^,&,*,-,_,+,=,?,>,<])/;

    if ($('#senha').val().length < 6) {
        $('#SenhaRetorno').html("<span style='color:red'>Fraco, insira no mínimo 6 caracteres</span>");
    } else {
        if ($('#senha').val().match(numeros) && $('#senha').val().match(alfabeto) && $('#senha').val().match(chEspeciais)) {
            $('#SenhaRetorno').html("<span style='color:green'><b>Forte</b></span>");
        } else {
            $('#SenhaRetorno').html("<span style='color:orange'>Médio, insira um caracter especial</span>");
        }
    }
}