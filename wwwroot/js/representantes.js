$(document).ready(function () {
    console.clear();
    $('#representanteTop').click(function () {
        $('#btnModalRepresentante').show();
        document.getElementById('btnModalRepresentante').innerHTML = "Guardar";
        document.getElementById('btnCancelarRepresentante').innerHTML = "Cancelar";
        limpiarRepresentante();
        $('#btnModalRepresentante').attr("disabled", true);
        $('#representanteModal').attr("disabled", true);
        $('#representantePersonaID').val($('#personaGeneralID').val());
        $('.filaDocumentoRepresentante').remove();
        $('#lblGuardadoRepresentante').show();
    });

    $('#btnModalRepresentante').click(function () {
        $("span.Representantes").show();
    });

    $('#representanteModal').click(function () {
        document.getElementById('btnModalDocumentoRepresentante').innerHTML = "Guardar";
        limpiarDocumentosRepresentante();
        $('#btnModalDocumentoRepresentante').show();
        document.getElementById('btnCancelarDocumentosRepresentante').innerHTML = "Cancelar";
    });

    $('#representanteCurp, #representanteNombre, #representanteApellidoPaterno').keyup(function () {
        if ($('#representanteNombre').val() !== '' && $('#representanteCurp').val() !== '' && $('#representanteApellidoPaterno').val() !== '') {
            $('#btnModalRepresentante').attr("disabled", false);
        } else {            
            $('#btnModalRepresentante').attr("disabled", true);
        }        
    });
});

function limpiarRepresentante() {
    $("#modalRepresentantes input").val("");
    $("#modalRepresentantes textarea").val("");
    $("#modalRepresentantes select").val("");
    $("span.Representantes").hide();
    $('.filaDocumentoRepresentante').remove();
}

function limpiarDocumentosRepresentante() {
    $("#modalDocumentoRepresentantes input").val("");
    $("#modalDocumentoRepresentantes textarea").val("");
    $("#modalDocumentoRepresentantes select").val("");
    $("span.documentosRepresentantes").hide();
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
                url: "/Peticiones/deleteRepresentante",
                data: {
                    id: id,
                    persona: persona
                },
                success: function (data) {
                    if (data === '0') {
                        $('#lblNoRepresentantes').show();
                    }
                    Swal.fire(
                        'Borrado exitoso',
                        'El campo ha sido eliminado',
                        'success'
                    )
                    var elemento = document.getElementById(id);
                    $(elemento).remove(".tablaRepresentante");
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;
        }
    });
}

$('#formRepresentantes').submit(function () {
    var curp = $('#representanteCurp').val();
    var nombre = $('#representanteNombre').val();
    var aPaterno = $('#representanteApellidoPaterno').val();
    var aMaterno = $('#representanteApellidoMaterno').val();
    var persona = $('#representantePersonaID').val();

    var listadoDocumentos = document.querySelector('#tableRepresentante');
    var nuevoDoc = document.createElement('tr');

    if (curp === '' || nombre === '' || aPaterno === '') {
        Swal.fire({
            position: 'top-end',
            icon: 'warning',
            title: 'Oops...',
            text: 'Faltan datos',
            showConfirmButton: false,
            timer: 1500
        });
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
                        $('#representanteID').val(data);
                        $('#representanteModal').attr("disabled", false);
                        $('#btnModalRepresentante').attr("disabled", true);
                        $('#btnCancelarRepresentante').attr("disabled", true);
                        $('#cerrarModalRepresentantes').attr("disabled", true);
                        $('#lblGuardadoRepresentante').hide();
                        $('#lblDocumentosRepresentante').show();

                        $('#lblNoRepresentantes').hide();

                        nuevoDoc.setAttribute("id", data);
                        nuevoDoc.setAttribute("class", "filaRepresentante tablaRepresentante text-center");
                        nuevoDoc.innerHTML = '<td></td>' +
                            '<td>' + curp + '</td>' +
                            '<td></td>' +
                            '<td>' + nombre + '</td>' +
                            '<td></td>' +
                            '<td> ' +
                            '<button type="button" onclick="editarInt(this)" data-toggle="modal" data-target="#modalRepresentantes" class="btn btn-success" value="'+data+'" name="´'+persona+'" id="editDom">Editar</button>' +
                            '<button class="btn btn-primary mx-2" onclick="detailInt(this)" data-toggle="modal" data-target="#modalRepresentantes" name="'+persona+'" value="'+data+'" id="btnDetalleInt">Detalles</button>' +
                            '<button class="btn btn-danger" onclick="borrarInt(this)" value="'+data+'">Borrar</button>' +
                            '</td >';
                        listadoDocumentos.appendChild(nuevoDoc);
                    }
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
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Actualizado exitoso',
                            showConfirmButton: false,
                            timer: 1500
                        })
                        $('#modalRepresentantes').modal('hide');

                        var fila = document.getElementById(id);
                        $(fila).remove(".tablaRepresentante");

                        nuevoDoc.setAttribute("id", id);
                        nuevoDoc.setAttribute("class", "filaRepresentante tablaRepresentante text-center");
                        nuevoDoc.innerHTML = '<td></td>' +
                            '<td>' + curp + '</td>' +
                            '<td></td>' +
                            '<td>' + nombre + '</td>' +
                            '<td></td>' +
                            '<td> ' +
                            '<button type="button" onclick="editarInt(this)" data-toggle="modal" data-target="#modalRepresentantes" class="btn btn-success" value="' + id + '" name="´' + persona + '" id="editDom">Editar</button>' +
                            '<button class="btn btn-primary mx-2" onclick="detailInt(this)" data-toggle="modal" data-target="#modalRepresentantes" name="' + persona + '" value="' + id + '" id="btnDetalleInt">Detalles</button>' +
                            '<button class="btn btn-danger" onclick="borrarInt(this)" value="' + id + '">Borrar</button>' +
                            '</td >';
                        listadoDocumentos.appendChild(nuevoDoc);
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

$('#formDocumentoRepresentantes').submit(function () {
    var tipo = $('#tipoDocumentoRep').val();
    var folio = $('#folioDocumentoRep').val();
    var fecha = $('#fechaDocumentoRep').val();
    var repre = $('#representanteID').val();

    var nombreDoc = $('#tipoDocumentoRep option:selected').text();
    var listadoDocumentos = document.querySelector('#tableDocumentosRepresentante');
    var nuevoDoc = document.createElement('tr');

    $("span.documentosRepresentantes").show();

    if (tipo === '' || folio === '' || fecha === '') {        
        Swal.fire({
            position: 'top-end',
            icon: 'warning',
            title: 'Oops...',
            text: 'Faltan datos',
            showConfirmButton: false,
            timer: 1500
        });
    } else {
        if (document.getElementById('btnModalDocumentoRepresentante').innerHTML === "Guardar") {
            $.ajax({
                type: 'POST',
                url: "/Peticiones/addDocumentoRepresentante",
                data: {
                    tipo: tipo,
                    folio: folio,
                    fecha: fecha,
                    repre: repre
                },
                success: function (data) {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Guardado exitoso',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    nuevoDoc.setAttribute("id", data);
                    nuevoDoc.setAttribute("class", "filaDocumentoRepresentante tablaDocumentosRepresentantes");
                    nuevoDoc.innerHTML = '<td>' + nombreDoc + '</td><td>' + folio + '</td><td>' + fecha + '</td>' +
                        '<td> ' +
                        '<button type="button" onclick="editDocumentoRepresentante(this)" data-toggle="modal" data-target="#modalDocumentoRepresentantes" class="btn btn-success" value=' + data + ' name=' + repre + '>Editar</button>' +
                        '<button type="button" class="btn btn-primary mx-2" onclick="detalleDocumentoRepresentante(this)" data-toggle="modal" data-target="#modalDocumentoRepresentantes" value=' + data + ' name=' + repre + '>Detalles</button>' +
                        '<button type="button" class="btn btn-danger" onclick="deleteDocumentoRepresentante(this)" value=' + data + ' name=' + repre + '>Borrar</button>' +
                        '</td >';
                    listadoDocumentos.appendChild(nuevoDoc);

                    $('#btnCancelarRepresentante').attr("disabled", false);
                    $('#cerrarModalRepresentantes').attr("disabled", false);
                    $('#modalDocumentoRepresentantes').modal('hide');
                    $('#lblDocumentosRepresentante').hide();
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;
        } else {
            var id = $('#documentoRepID').val();

            $.ajax({
                type: 'POST',
                url: "/Peticiones/updateDocumentoRepresentante",
                data: {
                    id: id,
                    tipo: tipo,
                    folio: folio,
                    fecha: fecha
                },
                success: function (data) {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Actualizado exitoso',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    var fila = document.getElementById(id);
                    $(fila).remove(".tablaDocumentosRepresentantes");
                    
                    nuevoDoc.setAttribute("id", data);
                    nuevoDoc.setAttribute("class", "filaDocumentoRepresentante tablaDocumentosRepresentantes");
                    nuevoDoc.innerHTML = '<td>' + nombreDoc + '</td><td>' + folio + '</td><td>' + fecha + '</td>' +
                        '<td> ' +
                        '<button type="button" onclick="editDocumentoRepresentante(this)" data-toggle="modal" data-target="#modalDocumentoRepresentantes" class="btn btn-success" value=' + data + ' name=' + repre + '>Editar</button>' +
                        '<button type="button" class="btn btn-primary mx-2" onclick="detalleDocumentoRepresentante(this)" data-toggle="modal" data-target="#modalDocumentoRepresentantes" value=' + data + ' name=' + repre + '>Detalles</button>' +
                        '<button type="button" class="btn btn-danger" onclick="deleteDocumentoRepresentante(this)" value=' + data + ' name=' + repre + '>Borrar</button>' +
                        '</td >';
                    listadoDocumentos.appendChild(nuevoDoc);
                    

                    $('#btnCancelarRepresentante').attr("disabled", false);
                    $('#cerrarModalRepresentantes').attr("disabled", false);
                    $('#modalDocumentoRepresentantes').modal('hide');
                    $('#lblDocumentosRepresentante').hide();
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;

        }
    }
});

function detalleDocumentoRepresentante(boton) {
    limpiarDocumentosRepresentante();
    $('#btnModalDocumentoRepresentante').hide();
    document.getElementById('btnCancelarDocumentosRepresentante').innerHTML = "Cerrar";

    var id = boton.value;
    getDocumentoRepresentantes(id);
}

function editDocumentoRepresentante(boton) {
    limpiarDocumentosRepresentante();
    $('#btnModalDocumentoRepresentante').show();
    document.getElementById('btnModalDocumentoRepresentante').innerHTML = "Editar";
    document.getElementById('btnCancelarDocumentosRepresentante').innerHTML = "Cancelar";

    var id = boton.value;
    getDocumentoRepresentantes(id);
}

function getDocumentoRepresentantes(id) {
    $.ajax({
        type: 'GET',
        url: "/Peticiones/getDocumentosRepresentantes",
        data: {
            id: id
        },
        success: function (data) {
            $('#tipoDocumentoRep').val(data[0]['tipo_DocumentoID']);
            $('#folioDocumentoRep').val(data[0]['folioDocumento']);
            $('#fechaDocumentoRep').val(data[0]['fechaDocumento']);
            $('#documentoRepID').val(data[0]['documentoRepresentanteID']);

        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

function deleteDocumentoRepresentante(boton) {
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
            var repre = boton.name;

            $.ajax({
                type: 'POST',
                url: "/Peticiones/deleteDocumentoRepresentante",
                data: {
                    id: id,
                    repre: repre
                },
                success: function (data) {
                    if (data === '0') {
                        $('#lblDocumentosRepresentante').show();
                        $('#btnCancelarRepresentante').attr("disabled", true);
                        $('#cerrarModalRepresentantes').attr("disabled", true);
                    }
                    var fila = document.getElementById(id);
                    $(fila).remove(".tablaDocumentosRepresentantes");
                    Swal.fire(
                        'Borrado exitoso',
                        'El campo ha sido eliminado',
                        'success'
                    )
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;
        }
    });
}

function editarInt(boton) {
    limpiarRepresentante();
    $('#btnModalRepresentante').attr("disabled", false);
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

            $('#representanteModal').attr("disabled", false);

            $.ajax({
                type: 'GET',
                url: "/Peticiones/getDocumentosRepresentante",
                data: {
                    id: id
                },
                success: function (data) {
                    if (Object.keys(data).length > 0) {
                        $('#lblGuardadoRepresentante').hide();

                        for (var i = 0; i < Object.keys(data).length; i++) {
                            var listadoDocumentos = document.querySelector('#tableDocumentosRepresentante');
                            var nuevoDoc = document.createElement('tr');
                            var nombreDoc = $('#tipoDocumentoRep option[value=' + data[i]['tipo_DocumentoID'] + ']').text();

                            nuevoDoc.setAttribute("id", data[i]['documentoRepresentanteID']);
                            nuevoDoc.setAttribute("class", "filaDocumentoRepresentante tablaDocumentosRepresentantes");
                            nuevoDoc.innerHTML = '<td>' + nombreDoc + '</td><td>' + data[i]['folioDocumento'] + '</td><td>' + data[i]['fechaDocumento'] + '</td>' +
                                '<td> ' +
                                '<button type="button" onclick="editDocumentoRepresentante(this)" data-toggle="modal" data-target="#modalDocumentoRepresentantes" class="btn btn-success" value=' + data[i]['documentoRepresentanteID'] + ' name=' + data[i]['representanteID'] + '>Editar</button>' +
                                '<button type="button" class="btn btn-primary mx-2" onclick="detalleDocumentoRepresentante(this)" data-toggle="modal" data-target="#modalDocumentoRepresentantes" value=' + data[i]['documentoRepresentanteID'] + ' name=' + data[i]['representanteID'] + '>Detalles</button>' +
                                '<button type="button" class="btn btn-danger" onclick="deleteDocumentoRepresentante(this)" value=' + data[i]['documentoRepresentanteID'] + ' name=' + data[i]['representanteID'] + '>Borrar</button>' +
                                '</td >';
                            listadoDocumentos.appendChild(nuevoDoc, );
                        }
                    }
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;

        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}