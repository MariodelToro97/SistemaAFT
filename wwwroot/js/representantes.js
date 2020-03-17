$(document).ready(function () {
    $('#representanteTop').click(function () {
        $('#btnModalRepresentante').show();
        document.getElementById('btnModalRepresentante').innerHTML = "Guardar";
        document.getElementById('btnCancelarRepresentante').innerHTML = "Cancelar";
        limpiarRepresentante();
        $('#representantePersonaID').val($('#personaGeneralID').val());
    });

    $('#btnModalRepresentante').click(function () {
        $("span.Representantes").show();
    });

    $('#representanteCurp, #representanteNombre, #representanteApellidoPaterno, #representanteApellidoMaterno').keyup(function () {
        var tamano = $('#representanteCurp').val() + $('#representanteNombre').val() + $('#representanteApellidoPaterno').val() + $('#representanteApellidoMaterno').val();        
        console.log(Object.keys(tamano).length);
        $('#representanteModal').attr("disabled", Object.keys(tamano).length < 25);      
    });
});

function limpiarRepresentante() {
    $("#modalRepresentantes input").val("");
    $("#modalRepresentantes textarea").val("");
    $("#modalRepresentantes select").val("");
    $("span.Representantes").hide();
}

function detailInt(boton) {
    limpiarRepresentante();
    $('#btnModalRepresentante').hide();
    document.getElementById('btnCancelarRepresentante').innerHTML = "Cerrar";

    var id = boton.value;
    var persona = boton.name;

    $('#representantePersonaID').val(persona);
    getRepresentante(id);
}

function borrarInt(boton) {
    var id = boton.value;

    $.ajax({
        type: 'POST',
        url: "/Peticiones/deleteRepresentante",
        data: {
            id: id
        },
        success: function (data) {
            console.log(data);
            $('#tableRepresentante').load(" #tableRepresentante");
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

$('#formRepresentantes').submit(function () {
    var curp = $('#representanteCurp').val();
    var nombre = $('#representanteNombre').val();
    var aPaterno = $('#representanteApellidoPaterno').val();
    var aMaterno = $('#representanteApellidoMaterno').val();
    var persona = $('#representantePersonaID').val();

    if (curp === '' || nombre === '' || aPaterno === '') {
        console.log('FALTAN DATOS');
    } else {
        if (aMaterno === '') {
            aMaterno = 'NULL';
        }
        if (document.getElementById('btnModalRepresentante').innerHTML === "Guardar") {
            $.ajax({
                type: 'POST',
                url: "/Peticiones/addRepresentante",
                data: {
                    curp: curp,
                    nombre: nombre,
                    aPaterno: aPaterno,
                    aMaterno: aMaterno,
                    persona: persona
                },
                success: function (data) {
                    console.log(data);
                    $('#tableRepresentante').load(" #tableRepresentante");
                    $('#modalRepresentantes').modal('hide');
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;

        } else {
            if (document.getElementById('btnModalRepresentante').innerHTML === "Editar") {

                var id = $('#representanteID').val();

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
                        $('#tableRepresentante').load(" #tableRepresentante");
                        $('#modalRepresentantes').modal('hide');
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

function editarInt(boton) {
    limpiarRepresentante();
    $('#btnModalRepresentante').show();
    document.getElementById('btnCancelarRepresentante').innerHTML = "Cerrar";
    document.getElementById('btnModalRepresentante').innerHTML = "Editar";

    var id = boton.value;

    getRepresentante(id);
}

function getRepresentante(id) {
    $.ajax({
        type: 'GET',
        url: "/Peticiones/getRepresentantes",
        data: {
            id: id
        },
        success: function (data) {
            $('#representanteID').val(data[0]['representanteID']);
            $('#representanteCurp').val(data[0]['curp']);
            $('#representanteNombre').val(data[0]['nombre']);
            $('#representanteApellidoPaterno').val(data[0]['apellido_paterno']);
            $('#representantePersonaID').val(data[0]['personaID']);

            var aMaterno = data[0]['apellido_materno'];

            if (aMaterno === 'NULL') {
                $('#representanteApellidoMaterno').val('');
            } else {
                $('#representanteApellidoMaterno').val(aMaterno);
            }
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}