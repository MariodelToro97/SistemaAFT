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
    console.log("listado", listadoContactos)
    nuevoContacto = document.createElement('tr');
    
    var numero = $('#numeroTelefono').val();
    var CompaniaID = $('#companiaTelefono').val();
    var Tipo_TelefonoID = $('#tipoTelefono').val();
    var persona = $('#personaGeneralID').val();
    //var telefonoID = $("#telefonoID").val();
    /*
    console.log("numero", numero);
    console.log("telefono",CompaniaID);
    console.log("tipo telefono",Tipo_TelefonoID);
    console.log("id persona",persona);
    */

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
                //contentType: false,
                //processData: false,
                success: function (data) {
                    alert('Insertado con el id ' + data);
                    $('#modalTelefonos').modal('hide');
                    //obtenerDom(data);
                    console.log("id de la persona", persona);
                    console.log("id del telefono", data);

                    nuevoContacto.setAttribute("id", `${data}`);

                    nuevoContacto.innerHTML = `
                        <td>${numero}</td>
                        <td>${CompaniaID}</td>
                        <td>${Tipo_TelefonoID}</td>
                        <td>
                            <button type="button" onclick="editTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" class="btn btn-success" value=${data} name=${persona} id="editTelefono">Editar</button>
                            <button class="btn btn-primary" onclick="detalleTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" value=${data} name=${persona}>Detalles</button>
                            <button class="btn btn-danger" onclick="deleteTelefono(this)" value=${data}>Borrar</button>
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

                        //listadoContactos.appendChild(nuevoContacto);
                        var elemento = document.getElementById(id);
                        $(elemento).remove();

                        nuevoContacto.setAttribute("id", `${id}`);

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

    $.ajax({
        type: 'POST',
        url: "/Peticiones/deleteTelefono",
        data: {
            id: id
        },
        success: function (data) {
            console.log(data);
            var elemento = document.getElementById(id);
            $(elemento).remove();
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