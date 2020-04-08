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

$('#formIntegrantes').submit(function (e) {
    listadoContactos = document.querySelector('#tableIntegrantes');
    //console.log("listado", listadoContactos)
    nuevoContacto = document.createElement('tr');

    var curp = $('#integranteCurp').val();
    var nombre = $('#integranteNombre').val();
    var aPaterno = $('#integranteApellidoPaterno').val();
    var aMaterno = $('#integranteApellidoMaterno').val();
    var persona = $('#personaGeneralID').val();

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
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Guardado exitoso',
                        showConfirmButton: false,
                        timer: 1500
                    })

                   $('#modalIntegrantes').modal('hide');
                    $('#lblNoIntegrantes').hide();

                    nuevoContacto.setAttribute("id", `${data}`);
                    nuevoContacto.setAttribute("class", `tablaIntegrante-${data} tablaIntegrante`);

                    nuevoContacto.innerHTML = `
                            <td>-</td>
                            <td>${curp}</td>
                            <td>-</td>
                            <td>${nombre}</td>
                            <td>-</td>
                            
                            <button type="button" onclick="editIntegrante(this)" data-toggle="modal" data-target="#modalIntegrantes" class="btn btn-success" value=${data} name=${persona} id="editIntegrante">Editar</button>
                            <button class="btn btn-primary" onclick="detalleIntegrante(this)" data-toggle="modal" data-target="#modalIntegrantes" value=${data} name=${persona}>Detalles</button>
                            <button class="btn btn-danger" onclick="deleteIntegrante(this)" value=${data}>Borrar</button>
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
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Actualizado exitoso',
                            showConfirmButton: false,
                            timer: 1500
                        })
                        $('#modalIntegrantes').modal('hide');

                        var elemento = document.getElementsByClassName(`tablaIntegrante-${id}`);
                        $(elemento).remove();

                        nuevoContacto.setAttribute("id", `${id}`);
                        nuevoContacto.setAttribute("class", `tablaIntegrante-${id} tablaIntegrante`);

                        nuevoContacto.innerHTML = `
                            <td>-</td>
                            <td>${curp}</td>
                            <td>-</td>
                            <td>${nombre}</td>
                            <td>-</td>
                            <td>
                                <button type="button" onclick="editIntegrante(this)" data-toggle="modal" data-target="#modalIntegrantes" class="btn btn-success" value=${id} name=${persona} id="editIntegrante">Editar</button>
                                <button class="btn btn-primary" onclick="detalleIntegrante(this)" data-toggle="modal" data-target="#modalIntegrantes" value=${id} name=${persona}>Detalles</button>
                                <button class="btn btn-danger" onclick="deleteIntegrante(this)" value=${id}>Borrar</button>
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

function limpiarIntegrantes() {
    $("#modalIntegrantes input").val("");
    $("#modalIntegrantes textarea").val("");
    $("#modalIntegrantes select").val("");
    $("span.Integrantes").hide();
}

function deleteIntegrante(boton) {
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
                url: "/Peticiones/deleteIntegrante",
                data: {
                    id: id,
                    persona: persona
                },
                success: function (data) {
                    if (data === '0') {
                        $('#lblNoIntegrantes').show();
                    }
                    Swal.fire(
                        'Borrado exitoso',
                        'El campo ha sido eliminado',
                        'success'
                    )
                    var elemento = document.getElementsByClassName(`tablaIntegrante-${id}`);
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

function editIntegrante(boton) {
    limpiarIntegrantes();
    $('#btnModalIntegrante').show();
    document.getElementById('btnModalIntegrante').innerHTML = "Editar";
    document.getElementById('btnCancelarIntegrante').innerHTML = "Cancelar";

    var id = boton.value;
    var persona = boton.name;

    $('#integrantePersonaID').val(persona);
    obtenerIntegrante(id);
}

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