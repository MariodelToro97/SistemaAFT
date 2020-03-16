$(document).ready(function () {
    $('#botonAgregarTelefono').click(function () {
        document.getElementById('btnModalTelefono').innerHTML = "Guardar";
        document.getElementById('btnCancelarTelefono').innerHTML = "Cancelar";
        limpiarTelefonos();
        $('#btnModalTelefono').show();
        $('#telefonoPersonaID').val($('#personaOcultoID').val());
    });

    $('#btnModalTelefono').click(function () {
        $("span.Telefonos").show();
    });
});

$('#formTelefonos').submit(function () {
    var numero = $('#numeroTelefono').val();
    var CompaniaID = $('#companiaTelefono').val();
    var Tipo_TelefonoID = $('#tipoTelefono').val();
    var persona = $('#personaGeneralID').val();

    if (numero === '' || CompaniaID === '' || Tipo_TelefonoID === '') {
        console.log('FALTAN DATOS');
    } else {
        if (document.getElementById('btnModalTelefono').innerHTML === "Guardar") {
            $.ajax({
                type: 'POST',
                url: "/Peticiones/addTelefono",
                data: {
                    numero: numero,
                    CompaniaID: CompaniaID,
                    Tipo_TelefonoID: Tipo_TelefonoID,
                    persona: persona
                },
                success: function (data) {
                    console.log(data);
                    $('#tableTelefonos').load(" #tableTelefonos");
                    $('#modalTelefonos').modal('hide');
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;

        } else {
            if (document.getElementById('btnModalTelefono').innerHTML === "Editar") {

                var id = $('#TelefonoID').val();

                $.ajax({
                    type: 'POST',
                    url: "/Peticiones/updateTelefono",
                    data: {
                        id: id,
                        numero: numero,
                        CompaniaID: CompaniaID,
                        Tipo_TelefonoID: Tipo_TelefonoID,
                        persona: persona
                    },
                    success: function (data) {
                        console.log(data);
                        $('#tableTelefonos').load(" #tableTelefonos");
                        $('#modalTelefonos').modal('hide');
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

function limpiarTelefonos() {
    $("#modalTelefonos input").val("");
    $("#modalTelefonos textarea").val("");
    $("#modalTelefonos select").val("");
    $("span.Telefonos").hide();
}

function deleteTelefono(boton) {
    var id = boton.value;

    $.ajax({
        type: 'POST',
        url: "/Peticiones/deleteTelefono",
        data: {
            id: id
        },
        success: function (data) {
            console.log(data);
            $('#tableTelefonos').load(" #tableTelefonos");
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

function editTelefono(boton) {
    limpiarTelefonos();
    $('#btnModalTelefono').show();
    document.getElementById('btnModalTelefono').innerHTML = "Editar";
    document.getElementById('btnCancelarTelefono').innerHTML = "Cancelar";

    var id = boton.value;
    var persona = boton.name;

    $('#telefonoPersonaID').val(persona);
    obtenerTelefono(id);
}

function detalleTelefono(boton) {
    limpiarTelefonos();
    $('#btnModalTelefono').hide();
    document.getElementById('btnCancelarTelefono').innerHTML = "Cerrar";

    var id = boton.value;
    var persona = boton.name;

    $('#telefonoPersonaID').val(persona);
    obtenerTelefono(id);
}

function obtenerTelefono(id) {
    $.ajax({
        type: 'GET',
        url: "/Peticiones/getTelefono",
        data: {
            id: id
        },
        success: function (data) {
            console.log(data);
            $('#TelefonoID').val(data[0]['telefonoID']);
            $('#numeroTelefono').val(data[0]['numero']);
            var CompaniaID = $('#companiaTelefono').val(data[0]['companiaID']);
            var Tipo_TelefonoID = $('#tipoTelefono').val(data[0]['tipo_TelefonoID']);
            $('#telefonoPersonaID').val(data[0]['personaID']);

            document.getElementById('companiaTelefono').getElementsByTagName('option')[CompaniaID].selected = 'selected';
            document.getElementById('tipoTelefono').getElementsByTagName('option')[Tipo_TelefonoID].selected = 'selected';

        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}