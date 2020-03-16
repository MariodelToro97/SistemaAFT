$(document).ready(function () {
    $('#integrantesTop').click(function () {
        document.getElementById('btnModalIntegrante').innerHTML = "Guardar";
        document.getElementById('btnCancelarIntegrante').innerHTML = "Cancelar";
        limpiarIntegrantes();
        $('#btnModalIntegrante').show();
        $('#integrantePersonaID').val($('#personaGeneralID').val());
    });

    $('#btnModalIntegrante').click(function () {
        $("span.Integrantes").show();
    });
});

$('#formIntegrantes').submit(function () {
    var curp = $('#integranteCurp').val();
    var nombre = $('#integranteNombre').val();
    var aPaterno = $('#integranteApellidoPaterno').val();
    var aMaterno = $('#integranteApellidoMaterno').val();
    var persona = $('#integrantePersonaID').val();

    if (curp === '' || nombre === '' || aPaterno === '') {
        console.log('FALTAN DATOS');
    } else {
        if (aMaterno === '') {
            aMaterno = 'NULL';
        }
        if (document.getElementById('btnModalIntegrante').innerHTML === "Guardar") {
            $.ajax({
                type: 'POST',
                url: "/Peticiones/addIntegrante",
                data: {
                    curp: curp,
                    nombre: nombre,
                    aPaterno: aPaterno,
                    aMaterno: aMaterno,
                    persona: persona
                },
                success: function (data) {
                    console.log(data);
                    $('#tableIntegrantes').load(" #tableIntegrantes");
                    $('#modalIntegrantes').modal('hide');
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;

        } else {
            if (document.getElementById('btnModalIntegrante').innerHTML === "Editar") {

                var id = $('#integranteID').val();

                $.ajax({
                    type: 'POST',
                    url: "/Peticiones/updateRepresentante",
                    data: {
                        id: id,
                        curp: curp,
                        nombre: nombre,
                        aPaterno: aPaterno,
                        aMaterno: aMaterno,
                        persona: persona
                    },
                    success: function (data) {
                        console.log(data);
                        $('#tableIntegrantes').load(" #tableIntegrantes");
                        $('#modalIntegrantes').modal('hide');
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

function limpiarIntegrantes() {
    $("#modalIntegrantes input").val("");
    $("#modalIntegrantes textarea").val("");
    $("#modalIntegrantes select").val("");
    $("span.Integrantes").hide();
}

function deleteIntegrante(boton) {
    var id = boton.value;

    $.ajax({
        type: 'POST',
        url: "/Peticiones/deleteIntegrante",
        data: {
            id: id
        },
        success: function (data) {
            console.log(data);
            $('#tableIntegrantes').load(" #tableIntegrantes");
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
};

function editIntegrante(boton) {
    limpiarIntegrantes();
    $('#btnModalIntegrante').show();
    document.getElementById('btnModalIntegrante').innerHTML = "Editar";
    document.getElementById('btnCancelarIntegrante').innerHTML = "Cancelar";

    var id = boton.value;
    var persona = boton.name;

    $('#integrantePersonaID').val(persona);
    obtenerIntegrante(id);
};

function detalleIntegrante(boton) {
    limpiarIntegrantes();
    $('#btnModalIntegrante').hide();
    document.getElementById('btnCancelarIntegrante').innerHTML = "Cerrar";

    var id = boton.value;
    var persona = boton.name;

    $('#integrantePersonaID').val(persona);
    obtenerIntegrante(id);
}

function obtenerIntegrante(id) {
    $.ajax({
        type: 'GET',
        url: "/Peticiones/getIntegrante",
        data: {
            id: id
        },
        success: function (data) {
            $('#integranteID').val(data[0]['integranteID']);
            $('#integranteCurp').val(data[0]['curp']);
            $('#integranteNombre').val(data[0]['nombre']);
            $('#integranteApellidoPaterno').val(data[0]['apellido_paterno']);
            $('#integrantePersonaID').val(data[0]['personaID']);

            var aMaterno = data[0]['apellido_materno'];

            if (aMaterno === 'NULL') {
                $('#integranteApellidoMaterno').val('');
            } else {
                $('#integranteApellidoMaterno').val(aMaterno);
            }
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}