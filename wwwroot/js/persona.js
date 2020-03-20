$(document).ready(function () {
    $('#guardarPersonas').click(function () {
        $("span.Persona").show();
        /* ASIGNA VALOR A CAMPO SURI */
        $('#acuseSuri').val('ACUSE SURI');
    });
});

function limpiarPersona() {
    $("#crearPersona input").val("");
    $("#crearPersona textarea").val("");
    $("#crearPersona select").val("");
    $("span.Persona").hide();
}


$('#crearPersona').submit(function () {
    var tipoPersona , curp, rfc, nombrePersona, aPaterno, aMAterno, nombreMoral, suri;
    var correo = $('#correoPersona').val();

    if (correo === '') {
        correo = "NULL";
    }

    var genero = $('#generoPersona').val();
    var etnia;

    if ($('#etniaPosPersona').is(':checked')) {
        etnia = $('#etniaPosPersona').val();
    } else if ($('#etniaNegPersona').is(':checked')) {
        etnia = $('#etniaNegPersona').val();
    }

    var nacimiento = $('#nacimientoPersona').val();
    var civil = $('#civilPersona').val();
    var discapacidad;

    if ($('#discPosPersona').is(':checked')) {
        discapacidad = $('#discPosPersona').val();
    } else if ($('#discNegPersona').is(':checked')) {
        discapacidad = $('#discNegPersona').val();
    }

    var nacionalidad = $('#nacionalidadPers').val();
    var identidad = $('#tipoIdenPersona').val();
    var numIdent = $('#numIdenPersona').val();
    
    if ($('#personaFisica').is(':checked')) {
        tipoPersona = 2;
        curp = $('#curpPersona').val();
        var expCURP = new RegExp ("^[A-Z]{4}[0-9]{6}[H,M][A-Z]{5}[A-Z,0-9][0-9]");

        if (!expCURP.test(curp)) {
            alert('La CURP no es válida');
        } else {
            rfc = $('#rfcPersona').val();
            nombrePersona = $('#nombreGeneral').val();

            if (rfc === '') {
                rfc = 'NULL';
            }

            aPaterno = $('#apellidoPaterno').val();
            aMAterno = $('#apellidoMaterno').val();

            if (aMAterno === '') {
                aMAterno = 'NULL';
            }

            nombreMoral = 'NULL';
            suri = $('#acuseSuri').val();

            if (curp === 'NULL' || nombrePersona === 'NULL' || aPaterno === 'NULL' || genero === 'NULL' || nacimiento === '' || civil === '' || nacionalidad === '' || numIdent === '' || identidad === '') {
                console.log("FALTAN DATOS");
            } else {
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
                        tipoPersona: tipoPersona,
                        etnia: etnia,
                        discapacidad: discapacidad,
                        suri: suri,
                        nombreMoral: nombreMoral
                    },
                    success: function (data) {
                        if (data === '') {
                            alert('No se insertó por qué ya esta dado de alta');
                        } else {
                            alert('Insertado con el id ' + data);
                            //limpiarPersona();
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
        
    } else if ($('#personaMoral').is(':checked')) {        
        tipoPersona = 1;
        curp = 'NULL';
        rfc = $('#rfcPersona').val();
        nombrePersona = 'NULL';
        aPaterno = 'NULL';
        aMAterno = 'NULL';
        nombreMoral = $('#nombreMoralPersonas').val();
        suri = $('#acuseSuri').val();

        if (rfc === 'NULL' || nombreMoral === 'NULL' || genero === '' || nacimiento === '' || civil === '' || nacionalidad === '' || numIdent === '' || identidad === '') {
            console.log("FALTAN DATOS");
        } else {
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
                    tipoPersona: tipoPersona,
                    etnia: etnia,
                    discapacidad: discapacidad,
                    suri: suri,
                    nombreMoral: nombreMoral
                },
                success: function (data) {
                    if (data === '') {
                        alert('No se insertó por qué ya esta dado de alta');
                    } else {
                        alert('Insertado con el id ' + data);
                        //limpiarPersona();
                        $('#personaGeneralID').val(data);
                    }
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;
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