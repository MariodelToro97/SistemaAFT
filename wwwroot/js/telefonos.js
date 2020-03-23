﻿$(document).ready(function () {
    $('#botonAgregarTelefono').click(function () {
        document.getElementById('btnModalTelefono').innerHTML = "Guardar";
        document.getElementById('btnCancelarTelefono').innerHTML = "Cancelar";
        
        limpiarTelefonos();
        $('#btnModalTelefono').show();
        $('#telefonoPersonaID').val($('#personaGeneralID').val());
        
    });

    $('#btnModalTelefono').click(function () {
        $("span.Telefonos").show();
    });
});

$('#formTelefonos').submit(function (e) {
    listadoContactos = document.querySelector('#tableTelefonos');
    nuevoContacto = document.createElement('tr');
    
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
                    alert('Insertado con el id ' + data);
                    $('#modalTelefonos').modal('hide');
                    $('#lblNoTelefonos').hide();

                    nuevoContacto.setAttribute("id", `${data}`);
                    nuevoContacto.setAttribute("class", 'tablaTelefono');

                    nuevoContacto.innerHTML = `
                        <td>${numero}</td>
                        <td>${CompaniaID}</td>
                        <td>${Tipo_TelefonoID}</td>
                        <td>
                            <button type="button" onclick="editTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" class="btn btn-success" value=${data} name=${persona} id="editTelefono">Editar</button>
                            <button type="button" class="btn btn-primary" onclick="detalleTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" value=${data} name=${persona}>Detalles</button>
                            <button type="button" class="btn btn-danger" onclick="deleteTelefono(this)" value=${data}>Borrar</button>
                        </td>
                    `;

                    listadoContactos.appendChild(nuevoContacto);
                    
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
                        $('#modalTelefonos').modal('hide');

                        var elemento = document.getElementById(id);
                        $(elemento).remove(".tablaTelefono");

                        nuevoContacto.setAttribute("id", `${id}`);
                        nuevoContacto.setAttribute("class", 'tablaTelefono');

                        nuevoContacto.innerHTML = `
                        <td>${numero}</td>
                        <td>${CompaniaID}</td>
                        <td>${Tipo_TelefonoID}</td>
                        <td>
                            <button type="button" onclick="editTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" class="btn btn-success" value=${id} name=${persona} id="editTelefono">Editar</button>
                            <button class="btn btn-primary" onclick="detalleTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" value=${id} name=${persona}>Detalles</button>
                            <button class="btn btn-danger" onclick="deleteTelefono(this)" value=${id}>Borrar</button>
                        </td>
                    `;

                     listadoContactos.appendChild(nuevoContacto);

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
    var persona = $('#personaGeneralID').val();

    $.ajax({
        type: 'POST',
        url: "/Peticiones/deleteTelefono",
        data: {
            id: id,
            persona: persona
        },
        success: function (data) {
            if (data === '0') {
                $('#lblNoTelefonos').show();
            } 
            console.log(data);
            var elemento = document.getElementById(id);
            $(elemento).remove(".tablaTelefono");
            //$('#tableTelefonos').load(" #tableTelefonos");
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
            $('#companiaTelefono').val(data[0]['companiaID']);
            $('#tipoTelefono').val(data[0]['tipo_TelefonoID']);
            $('#telefonoPersonaID').val(data[0]['personaID']);
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}