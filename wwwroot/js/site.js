$(document).ready(function () {

});

function errorCurp(campo) {
    
    campo.setCustomValidity("Campo Requerido");
}

$('#personaFisica').click(function () {
    $('#nombreMoral').hide();
    $('#curpHistoricas').show();
    $('#nav-representantes-tab').hide();
    $('#nav-integrantes-tab').hide();
    $('#columnaDos').show();
    $('#divCURP').show();
    $('#imagenSearch').show();
    $('#imagenSearchRFC').hide();
    
    document.getElementById('nombreGeneral').required = true;
    document.getElementById('apellidoPaterno').required = true;
    document.getElementById('rfcPersona').required = false;
});


$('#personaMoral').click(function () {
    $('#nombreMoral').show();
    $('#curpHistoricas').hide();
    $('#nav-representantes-tab').show();
    $('#nav-integrantes-tab').show();
    $('#columnaDos').hide();
    $('#divCURP').hide();
    $('#imagenSearch').hide();
    $('#imagenSearchRFC').show();

    document.getElementById('nombreGeneral').required = false;
    document.getElementById('apellidoPaterno').required = false;
    document.getElementById('rfcPersona').required = true;
});

$('#form input[type=text]').on('change invalid', function () {
    var campotexto = $(this).get(0);

    campotexto.setCustomValidity('');

    if (!campotexto.validity.valid) {
        campotexto.setCustomValidity('Campo requerido');
    }
});