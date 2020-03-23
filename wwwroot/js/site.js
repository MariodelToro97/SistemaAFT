$(document).ready(function () {
    
    $('#botonAgregarTelefono').attr("disabled", true);
    $('#btnAgregarDom').attr("disabled", true);
    $('#representanteTop').attr("disabled", true);
    $('#integrantesTop').attr("disabled", true);

    $('#personaFisica').click(function () {
        personaFisicaRadio();
        $("span.Persona").hide();
        $("#spanRFC").hide();        
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

        $('#divNumIdenPersona').hide();
        $('#divTipoIdenPersona').hide();
        $('#divNacionalidadPerso').hide();
        $('#divCivilPersona').hide();
        $('#divFechaNacimientoPersona').hide();
        $('#divDiscapacidadIDPersona').hide();
        $('#divEtniaIDPersona').hide();
        $('#divGeneroIDPersona').hide();        

        $('#divActividadEconomica').show();
        $('#divFechaConstitucion').show();
        $('#divfolioActa').show();
        $('#divNumeroNotario').show();

        $("#spanRFC").show();
        $("span.Persona").hide();
        inicioPerson();
    
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
        $('#Tel').hide();
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
        $('#Tel').hide();
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
        $('#Tel').hide();
    });
});

function personaFisicaRadio() {
    $('#nombreMoral').hide();
    $('#curpHistoricas').show();
    $('#nav-representantes-tab').hide();
    $('#nav-integrantes-tab').hide();
    $('#columnaDos').show();
    $('#divCURP').show();
    $('#imagenSearch').show();
    $('#imagenSearchRFC').hide();
    $('#tableCurpHist').hide();


    $('#divNumIdenPersona').show();
    $('#divTipoIdenPersona').show();
    $('#divNacionalidadPerso').show();
    $('#divCivilPersona').show();
    $('#divFechaNacimientoPersona').show();
    $('#divDiscapacidadIDPersona').show();
    $('#divEtniaIDPersona').show();
    $('#divGeneroIDPersona').show();

    $('#divActividadEconomica').hide();
    $('#divFechaConstitucion').hide();
    $('#divfolioActa').hide();
    $('#divNumeroNotario').hide();

    inicioPerson();

    document.getElementById('nombreGeneral').required = true;
    document.getElementById('nombreGeneral').setPointerCapture = "Campo requerido";
    document.getElementById('apellidoPaterno').required = true;
    document.getElementById('rfcPersona').required = false;

    document.getElementById('labelRFC').innerHTML = 'RFC:';
    document.getElementById('spanRFC').innerHTML = "";
}

function reinicializarTodo() {
    $("#crearPersona input").val("");
    $("#crearPersona textarea").val("");
    $("#crearPersona select").val("");
    $("#crearPersona span.Persona").hide();

    habilitarCampos();

    deshabilitarModales();
    personaFisicaRadio();

    document.getElementById('etniaNegPersona').checked = true;
    document.getElementById('discNegPersona').checked = true;
    document.getElementById('personaFisica').checked = true;

    $('.tablaRepresentante').remove();
    $('.tablaTelefono').remove();
    $('.tablaIntegrante').remove();
    $('.tablaDomicilio').remove();

    $('#lblNoTelefonos').show();
    $('#lblNoDomicilio').show();
    $('#lblNoRepresentantes').show();
    $('#lblNoIntegrantes').show();
}

function inicioPerson() {
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
}
