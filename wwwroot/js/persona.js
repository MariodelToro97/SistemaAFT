﻿$(document).ready(function () {
    $('#guardarPersonas').click(function () {
        $("span.Persona").show();
        /* ASIGNA VALOR A CAMPO SURI */
        $('#acuseSuri').val('ACUSE SURI');
    });

    $('#tipoIdenPersona').change(function () {
        if ($(this).val() !== '') {
            $("#numIdenPersona").prop("disabled", false);
        } else {
            $("#numIdenPersona").prop("disabled", true);
        }
    });
});

function limpiarPersona() {
    $("#crearPersona input").val("");
    $("#crearPersona textarea").val("");
    $("#crearPersona select").val("");
    $("span.Persona").hide();
}

function mayus(i) {
    i.value = i.value.toUpperCase();
}

$('#crearPersona').submit(function () {
    var curp, nombrePersona, aPaterno, aMAterno, suri;
    var correo = $('#correoPersona').val();

    if (correo === '') {
        correo = "NULL";
    }

    var genero = $('#generoPersona').val();
    var etnia;

    if ($('#etniaPosPersona').is(':checked')) {
        etnia = 2;
    } else if ($('#etniaNegPersona').is(':checked')) {
        etnia = 1;
    }

    var nacimiento = $('#nacimientoPersona').val();
    var civil = $('#civilPersona').val();
    var discapacidad;

    if ($('#discPosPersona').is(':checked')) {
        discapacidad = 2;
    } else if ($('#discNegPersona').is(':checked')) {
        discapacidad = 1;
    }

    var nacionalidad = $('#nacionalidadPers').val();
    var identidad = $('#tipoIdenPersona').val();
    var numIdent = $('#numIdenPersona').val();

    suri = $('#acuseSuri').val();

    var expRFC = new RegExp("^[A-Z]{4}[0-9]{6}[A-Z,0-9]{3}");
    
    if ($('#personaFisica').is(':checked')) {
        $("#spanRFC").hide();
        curp = $('#curpPersona').val();
        var expCURP = new RegExp ("^[A-Z]{4}[0-9]{6}[H,M][A-Z]{5}[A-Z,0-9][0-9]");
        nombrePersona = $('#nombreGeneral').val();

        aPaterno = $('#apellidoPaterno').val();
        aMAterno = $('#apellidoMaterno').val();

        if (aMAterno === '') {
            aMAterno = 'NULL';
        }     

        if (curp === 'NULL' || nombrePersona === 'NULL' || aPaterno === 'NULL' || genero === 'NULL' || nacimiento === '' || civil === '' || nacionalidad === '' || numIdent === '' || identidad === '') {
            console.log("FALTAN DATOS");
        } else {
            if (!expCURP.test(curp)) {
                alert('La CURP no es válida');
            } else {
                if (!expRFC.test($('#rfcPersona').val()) && $('#rfcPersona').val() !== '') {
                    alert('El RFC no es válido');
                } else {
                    var rfc = $('#rfcPersona').val();
                    if (rfc === '') {
                        rfc = 'NULL';
                    }
                    $.ajax({
                        type: 'POST',
                        url: "/Personas/addPersona",
                        data: {
                            curp: curp,
                            rfc: rfc,
                            nombrePersona: nombrePersona,
                            aPaterno: aPaterno,
                            aMAterno: aMAterno,
                            correo: correo,
                            nacimiento: nacimiento,
                            nacionalidad: nacionalidad,
                            genero: genero,
                            civil: civil,
                            identidad: identidad,
                            numIdent: numIdent,
                            tipoPersona: 1,
                            etnia: etnia,
                            discapacidad: discapacidad,
                            suri: suri,
                            nombreMoral: 'NULL',
                            actEcon: 0,
                            fecha_con: 'NULL',
                            folio: 'NULL',
                            notario: 0
                        },
                        success: function (data) {
                            if (data === '') {
                                alert('No se insertó por qué ya esta dado de alta');
                            } else {
                                alert('Insertado con el id ' + data);
                                $('#personaGeneralID').val(data);
                                habilitarModales();
                            }
                        },
                        error: function (r) {
                            console.log(r);
                        }
                    });
                    return false;
                }
            }
        }        
        
    } else if ($('#personaMoral').is(':checked')) {        
        $("#spanRFC").show();

        if ($('#rfcPersona').val() === 'NULL' || $('#nombreMoralPersonas').val() === '' || $('#actividadEconomicaPersona').val() === '' || $('#fechaConstitucionPersona').val() === '' || $('#folioActaPersona').val() === '' || $('#numeroNotarioPersona').val() === '') {
            console.log("FALTAN DATOS");
        } else {            
            if (!expRFC.test($('#rfcPersona').val())) {
                alert('El RFC no es válido');
            } else {
                $.ajax({
                    type: 'POST',
                    url: "/Personas/addPersona",
                    data: {
                        curp: 'NULL',
                        rfc: $('#rfcPersona').val(),
                        nombrePersona: 'NULL',
                        aPaterno: 'NULL',
                        aMAterno: 'NULL',
                        correo: correo,
                        nacimiento: 'NULL',
                        nacionalidad: $('#optionHidNacionalidad').val(),
                        genero: $('#optionHidGenero').val(),
                        civil: $('#optionHidEstadoCivil').val(),
                        identidad: $('#optionHidTipoIdentidad').val(),
                        numIdent: 'NULL',
                        tipoPersona: 2,
                        etnia: 1,
                        discapacidad: 1,
                        suri: suri,
                        nombreMoral: $('#nombreMoralPersonas').val(),
                        actEcon: $('#actividadEconomicaPersona').val(), 
                        fecha_con: $('#fechaConstitucionPersona').val(),
                        folio: $('#folioActaPersona').val(),
                        notario: $('#numeroNotarioPersona').val()
                    },
                    success: function (data) {
                        if (data === '') {
                            alert('No se insertó por qué ya esta dado de alta');
                        } else {
                            alert('Insertado con el id ' + data);
                            $('#personaGeneralID').val(data);
                            habilitarModales();
                        }
                    },
                    error: function (r) {
                        console.log(r);
                    }
                });
                return false;
            }
        }
    }
});

function habilitarModales() {
    $('#botonAgregarTelefono').attr("disabled", false);
    $('#integrantesTop').attr("disabled", false);
    $('#representanteTop').attr("disabled", false);
    $('#btnAgregarDom').attr("disabled", false);
}

function deshabilitarModales() {
    $('#botonAgregarTelefono').attr("disabled", true);
    $('#integrantesTop').attr("disabled", true);
    $('#representanteTop').attr("disabled", true);
    $('#btnAgregarDom').attr("disabled", true);
}