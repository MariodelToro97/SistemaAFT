$(document).ready(function () {
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
    var notificacion;

    if ($('#notPosTelefono').is(':checked')) {
        notificacion = true;
    } else if ($('#notNegTelefono').is(':checked')) {
        notificacion = false;
    }

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
                    persona: persona,
                    notificacion: notificacion
                },
                success: function (data) {
                    if (data === '') {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'error',
                            title: 'Ya está dado de alta',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    } else {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Guardado exitoso',
                            showConfirmButton: false,
                            timer: 1500
                        })
                        $('#modalTelefonos').modal('hide');
                        $('#lblNoTelefonos').hide();

                        nuevoContacto.setAttribute("id", `${data}`);
                        nuevoContacto.setAttribute("class", `tablaTelefono-${data} tablaTelefono`);

                        var comp = $('#companiaTelefono option[value=' + CompaniaID + ']').text();
                        var tipo = $('#tipoTelefono option[value=' + Tipo_TelefonoID + ']').text();

                        nuevoContacto.innerHTML = `
                            <td>${numero}</td>
                            <td>${comp}</td>
                            <td>${tipo}</td>
                            <td>
                                <button type="button" onclick="editTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" class="btn btn-success" value=${data} name=${persona} id="editTelefono">Editar</button>
                                <button type="button" class="btn btn-primary" onclick="detalleTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" value=${data} name=${persona}>Detalles</button>
                                <button type="button" class="btn btn-danger" onclick="deleteTelefono(this)" value=${data}>Borrar</button>
                            </td>
                        `;

                        listadoContactos.appendChild(nuevoContacto);
                    }
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
                        persona: persona,
                        notificacion: notificacion
                    },
                    success: function (data) {                        
                        if (data === '') {
                            Swal.fire({
                                position: 'top-end',
                                icon: 'error',
                                title: 'Ya está dado de alta',
                                showConfirmButton: false,
                                timer: 1500
                            })
                        } else {
                            Swal.fire({
                                position: 'top-end',
                                icon: 'success',
                                title: 'Actualizado exitoso',
                                showConfirmButton: false,
                                timer: 1500
                            })
                            $('#modalTelefonos').modal('hide');

                            var elemento = document.getElementsByClassName(`tablaTelefono-${id}`);
                            $(elemento).remove();

                            nuevoContacto.setAttribute("id", `${id}`);
                            nuevoContacto.setAttribute("class", `tablaTelefono-${id} tablaTelefono`);

                            var comp = $('#companiaTelefono option[value=' + CompaniaID + ']').text();
                            var tipo = $('#tipoTelefono option[value=' + Tipo_TelefonoID + ']').text();

                            nuevoContacto.innerHTML = `
                                <td>${numero}</td>
                                <td>${comp}</td>
                                <td>${tipo}</td>
                                <td>
                                    <button type="button" onclick="editTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" class="btn btn-success" value=${id} name=${persona} id="editTelefono">Editar</button>
                                    <button class="btn btn-primary" onclick="detalleTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" value=${id} name=${persona}>Detalles</button>
                                    <button class="btn btn-danger" onclick="deleteTelefono(this)" value=${id}>Borrar</button>
                                </td>
                            `;

                            listadoContactos.appendChild(nuevoContacto);
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

function limpiarTelefonos() {
    $("#modalTelefonos input").val("");
    $("#modalTelefonos textarea").val("");
    $("#modalTelefonos select").val("");
    $("span.Telefonos").hide();
    document.getElementById('notPosTelefono').checked = false;
    document.getElementById('notNegTelefono').checked = true;
}

function deleteTelefono(boton) {
    Swal.fire({
        title: '¿Desea eliminar el campo permanentemente?',
        text: "Su decisión no podrá ser revertida",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Cancelar',
        confirmButtonText: 'Sí, bórralo'
    }).then((result) => {
        if (result.value) {
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
                    Swal.fire(
                        'Borrado exitoso',
                        'El campo ha sido eliminado',
                        'success'
                    )
                    var elemento = document.getElementsByClassName(`tablaTelefono-${id}`);
                    $(elemento).remove();
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;
        }
    });  
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
            if (data[0]['notificacion'] === true) {
                document.getElementById('notPosTelefono').checked = true;
                document.getElementById('notNegTelefono').checked = false;
            } else {
                document.getElementById('notPosTelefono').checked = false;
                document.getElementById('notNegTelefono').checked = true;
            }
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}