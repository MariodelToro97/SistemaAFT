$(document).ready( function() {
    $('#personaFisica').click(function () {
        $('#nombreMoral').hide();
        $('#curpHistoricas').show();
        $('#nav-representantes-tab').hide();
        $('#nav-integrantes-tab').hide();
        $('#columnaDos').show();
        $('#divCURP').show();
        $('#imagenSearch').show();
        $('#imagenSearchRFC').hide();
        $('#tableCurpHist').hide();
        
        document.getElementById('nombreGeneral').required = true;
        document.getElementById('nombreGeneral').setPointerCapture = "Campo requerido";
        document.getElementById('apellidoPaterno').required = true;
        document.getElementById('rfcPersona').required = false;
    
        document.getElementById('labelRFC').innerHTML = 'RFC:';
        document.getElementById('spanRFC').innerHTML = "";
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
        $('#tableCurpHist').show();
    
        document.getElementById('nombreGeneral').required = false;
        document.getElementById('apellidoPaterno').required = false;
        document.getElementById('rfcPersona').required = true;
    
        document.getElementById('labelRFC').innerHTML = 'RFC<span class="text-danger font-weight-bold">*</span>:';
    });

    $('#CURP_Historicas').click(function () {
        if ($('#tableCurpHist').is(":visible")) {
            $('#tableCurpHist').hide();
        } else {
            $('#tableCurpHist').show();
        }
    });

    $('#nav-profile-tab').click(function () {
        $('#nav-general').hide();
        $('#Tel').hide();
        $('#formDomicilio').show();
        $('#botonFormUno').hide();
        $('#nav-bajas').hide();
        $('#nav-integrantes').hide();
        $('#nav-representantes').hide();
        $('#nav-obligacion').hide();
        $('#nav-cuenta').hide();
        $('#nav-domicilio').show();
        $('#botonesGeneral').hide();
        $('#solicitante_personal').hide();
    });

    $('#nav-home-tab').click(function () {
        $('#nav-general').show();
        $('#Tel').show();
        $('#formDomicilio').hide();
        $('#botonFormUno').show();
        $('#nav-bajas').hide();
        $('#nav-integrantes').hide();
        $('#nav-representantes').hide();
        $('#nav-obligacion').hide();
        $('#nav-cuenta').hide();
        $('#nav-domicilio').hide();
        $('#botonesGeneral').show();
        $('#solicitante_personal').show();

    });

    $('#nav-representantes-tab').click(function () {
        $('#nav-general').hide();
        $('#formDomicilio').hide();
        $('#botonFormUno').hide();
        $('#nav-bajas').hide();
        $('#nav-integrantes').hide();
        $('#nav-representantes').show();
        $('#nav-obligacion').hide();
        $('#nav-cuenta').hide();
        $('#nav-domicilio').hide();
        $('#botonesGeneral').hide();
    });
    
    $('#nav-integrantes-tab').click(function () {
        $('#nav-general').hide();
        $('#formDomicilio').hide();
        $('#botonFormUno').hide();
        $('#nav-bajas').hide();
        $('#nav-integrantes').show();
        $('#nav-representantes').hide();
        $('#nav-obligacion').hide();
        $('#nav-cuenta').hide();
        $('#nav-domicilio').hide();
        $('#botonesGeneral').hide();
    });

    $('#nav-bajas-tab').click(function () {
        $('#nav-general').hide();
        $('#formDomicilio').hide();
        $('#botonFormUno').hide();
        $('#nav-bajas').show();
        $('#nav-integrantes').hide();
        $('#nav-representantes').hide();
        $('#nav-obligacion').hide();
        $('#nav-cuenta').hide();
        $('#nav-domicilio').hide();   
        $('#botonesGeneral').hide();
    });
});
