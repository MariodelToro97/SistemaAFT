﻿$(document).ready(function () {
    console.clear();
    if (document.getElementById('domicilioEstado').length === 1) {
        estado();
    }
    $('#btnAgregarDom').click(function () {
        $('#btnModalDomicilio').show();
        document.getElementById('btnModalDomicilio').innerHTML = "Agregar Domicilio";
        document.getElementById('btnCancelarDom').innerHTML = "Cancelar";
        $("#domicilioMunicipioID").attr('disabled', false);
        $("#domicilioEstado").attr('disabled', false);
    });

    $('#btnModalDomicilio').click(function () {
        $("span.Modal").show();
    });

    $('#domicilioCodigoPostal').keypress(function (e) {
        var code = (e.keyCode ? e.keyCode : e.which);
        if (code === 13) {
            obtenerCP();
            return false;
        }
    });
});

function obtenerCP() {
    var domCP = $('#domicilioCodigoPostal').val();
    var expCP = new RegExp("^[0-9]{5}");
    if (!expCP.test(domCP)) {
        alert('El Código Postal no es válido');

    } else {
        $("#domicilioMunicipioID").attr('disabled', false);
        $("#domicilioEstado").attr('disabled', false);
        $("#domicilioEstado").val('');
        $.ajax({
            type: 'GET',
            url: "https://api-sepomex.hckdrk.mx/query/info_cp/" + domCP + "?type=simplified",
            cache: false,
            async: false,
            dataType: "json",
            success: function (data) {
                if (data.error) {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'error',
                        title: data.error_message,
                        showConfirmButton: false,
                        timer: 2000
                    });
                } else {                 
                    $("#domicilioEstado").val($("#domicilioEstado option:contains(" + data.response.estado + ")").val());
                    watchMunicipios($("#domicilioEstado").val());
                    $("#domicilioMunicipioID").val($("#domicilioMunicipioID option:contains(" + data.response.municipio + ")").val());                                       
                    watchLocalidades($("#domicilioEstado").val(), $("#domicilioMunicipioID").val());
                    $("#domicilioEstado").attr('disabled', true);
                    $("#domicilioMunicipioID").attr('disabled', true);
                }
            }, error: function (objeto) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'error',
                    title: objeto.responseJSON.error_message,
                    showConfirmButton: false,
                    timer: 2000
                });
            }, complete: function (xhr, status) {
                /*$('#spinner').hide();*/
            }
        });
    }
}

function estado() {
    $.ajax({
        type: 'GET',
        url: "https://gaia.inegi.org.mx/wscatgeo/mgee/",
        cache: false,
        async: false,
        dataType: "json",
        success: function (data) {     
            for (var i = 0; i < data.datos.length; i++) {
                $("#domicilioEstado").append("<option value=" + data.datos[i].cve_agee + ">" + data.datos[i].nom_agee + "</option>");
                $("#estadoSolicitud").append("<option value=" + data.datos[i].cve_agee + ">" + data.datos[i].nom_agee + "</option>");
            }
        }, error: function (objeto, tipo, causa) {
            console.log(objeto);
            console.log(tipo);
            console.log(causa);
        }, complete: function (xhr, status) {
            /*$('#spinner').hide();*/
        }
    });
    return false;
}

function mostrarLocalidades(option) {
    var mun = option.value;
    var est = $('#domicilioMunicipioID').find('option:selected').attr("name");
    $('#domicilioLocalidad option.localidadDomicilios').remove();

    $.ajax({
        type: 'GET',
        url: "https://gaia.inegi.org.mx/wscatgeo/localidades/" + est + "/" + mun,
        cache: false,
        async: false,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.datos.length; i++) {
                $("#domicilioLocalidad").append("<option class ='localidadDomicilios' value=" + data.datos[i].cve_loc + ">" + data.datos[i].nom_loc + "</option>");
            }
        }, error: function (objeto, tipo, causa) {
            console.log(objeto);
            console.log(tipo);
            console.log(causa);
        }, complete: function (xhr, status) {
            /*$('#spinner').hide();*/
        }
    });
    return false;
}

function mostrarMunicipios(option) {
    var mun = option.value;
    $('#domicilioMunicipioID option.municipioDomicilios').remove();

    $.ajax({
        type: 'GET',
        url: "https://gaia.inegi.org.mx/wscatgeo/mgem/" + mun,
        cache: false,
        async: false,
        dataType: "json",
        success: function (data) {
            //console.log(data);
            for (var i = 0; i < data.datos.length; i++) {
                $("#domicilioMunicipioID").append("<option class ='municipioDomicilios' value=" + data.datos[i].cve_agem + " name=" + data.datos[i].cve_agee + ">" + data.datos[i].nom_agem + "</option>");
            }
        }, error: function (objeto, tipo, causa) {
            console.log(objeto);
            console.log(tipo);
            console.log(causa);
        }, complete: function (xhr, status) {
            /*$('#spinner').hide();*/
        }
    });
    return false;
}

function limpiarForm() {
    $("#modalRegisterForm input").val("");
    $("#modalRegisterForm textarea").val("");
    $("#modalRegisterForm select").val("");
    $("span.Modal").hide();
}

function editarDom(boton) {
    limpiarForm();
    $('#btnModalDomicilio').show();
    document.getElementById('btnModalDomicilio').innerHTML = "Editar Domicilio";
    document.getElementById('btnCancelarDom').innerHTML = "Cancelar";
    var persona = boton.name;
    $('#domicilioPersonaID').val(persona);
    var id = boton.value;
    obtenerDom(id);
}

function detailDom(boton) {
    limpiarForm();
    $('#btnModalDomicilio').hide();
    document.getElementById('btnCancelarDom').innerHTML = "Cerrar";
    var id = boton.value;
    obtenerDom(id);
}

function obtenerDom(id) {
    if (document.getElementById('domicilioEstado').length === 1) {
        estado();
    }
    $.ajax({
        type: 'GET',
        url: "/Domicilios/GetDomicilio",
        data:
        {
            id: id
        },
        success: function (data) {            
            var noExterior = data[0]["noexterior"];
            var estado = data[0]["estado"];
            var asentamiento = data[0]["nombreasentamiento"];
            var nombreInterior = data[0]['nointerior'];
            var referenciaVialidad = data[0]['referenciavialidad'];
            var nombreVialidad = data[0]['nombrevialidad'];
            var localidad = data[0]['localidad'];
            var referenciaPosterior = data[0]['referenciaposterior'];
            var cp = data[0]['codigopostal'];
            var refUbi = data[0]['referenciaubicacion'];
            var ambito = data[0]['tipo_AmbitoID'];
            var vialidad = data[0]['tipo_VialidadID'];
            var municipio = data[0]['municipio'];
            var persona = data[0]['personaID'];
            var tipoAsentamiento = data[0]['tipo_AsentamientoID'];
            var domicilioID = data[0]["domicilioID"];

            watchMunicipios(estado);
            watchLocalidades(estado, municipio);

            $("#domicilioID").val(domicilioID);
            $('#domicilioNoExterior').val(noExterior);
            $('#domicilioEstado').val(estado);
            $('#domicilioNombreAsentamiento').val(asentamiento);
            $('#domicilioMunicipioID').val(municipio);


            if (nombreInterior === 'NULL') {
                $('#domicilioNombreInterior').val('');
            } else {
                $('#domicilioNombreInterior').val(nombreInterior);
            }

            if (referenciaVialidad === 'NULL') {
                $('#domicilioReferenciaVialidad').val('');
            } else {
                $('#domicilioReferenciaVialidad').val(referenciaVialidad);
            }

            $('#domicilioNombreVialidad').val(nombreVialidad);
            $('#domicilioLocalidad').val(localidad);


            if (referenciaPosterior === 'NULL') {
                $('#domicilioReferenciaPosterior').val('');
            } else {
                $('#domicilioReferenciaPosterior').val(referenciaPosterior);
            }

            $('#domicilioCodigoPostal').val(cp);
            $('#domicilioReferenciaUbicacion').val(refUbi);
            $('#domicilioPersonaID').val(persona);

            document.getElementById('domicilioTipoAmbito').getElementsByTagName('option')[ambito].selected = 'selected';
            document.getElementById('domicilioTipoVialidad').getElementsByTagName('option')[vialidad].selected = 'selected';
            document.getElementById('domicilioTipoAsentamiento').getElementsByTagName('option')[tipoAsentamiento].selected = 'selected';

            $("#domicilioMunicipioID").attr('disabled', false);
            $("#domicilioEstado").attr('disabled', false);
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

function watchLocalidades(est, mun) {
    $('#domicilioLocalidad option.localidadDomicilios').remove();

    $.ajax({
        type: 'GET',
        url: "https://gaia.inegi.org.mx/wscatgeo/localidades/" + est + "/" + mun,
        cache: false,
        async: false,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.datos.length; i++) {
                $("#domicilioLocalidad").append("<option class ='localidadDomicilios' value=" + data.datos[i].cve_loc + ">" + data.datos[i].nom_loc + "</option>");
            }
        }, error: function (objeto, tipo, causa) {
            console.log(objeto);
            console.log(tipo);
            console.log(causa);
        }, complete: function (xhr, status) {
            /*$('#spinner').hide();*/
        }
    });
    return false;
}

function watchMunicipios(est) {
    $('#domicilioMunicipioID option.municipioDomicilios').remove();

    $.ajax({
        type: 'GET',
        url: "https://gaia.inegi.org.mx/wscatgeo/mgem/" + est,
        cache: false,
        async: false,
        dataType: "json",
        success: function (data) {
            //console.log(data);
            for (var i = 0; i < data.datos.length; i++) {
                $("#domicilioMunicipioID").append("<option class ='municipioDomicilios' value=" + data.datos[i].cve_agem + " name=" + data.datos[i].cve_agee + ">" + data.datos[i].nom_agem + "</option>");
            }
        }, error: function (objeto, tipo, causa) {
            console.log(objeto);
            console.log(tipo);
            console.log(causa);
        }, complete: function (xhr, status) {
            /*$('#spinner').hide();*/
        }
    });
    return false;
}

function borrarDom(boton) {
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
                url: "/Domicilios/deleteDomicilio",
                data: {
                    domID: id,
                    persona: persona
                },
                success: function (data) {
                    Swal.fire(
                        'Borrado exitoso',
                        'El campo ha sido eliminado',
                        'success'
                    )
                    var elemento = document.getElementsByClassName(`tablaDomicilio-${id}`);
                    $(elemento).remove();

                    if (data === '0') {
                        $('#lblNoDomicilio').show();
                    }
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;
        }
    });
}

$('#formEditDomicilio').submit(function (e) {
    listadoContactos = document.querySelector('#tableDomicilio');
    nuevoContacto = document.createElement('tr');
    
    var dom = $('#domicilioTipoAmbito').val();
    var via = $('#domicilioTipoVialidad').val();
    var nomVia = $('#domicilioNombreVialidad').val();
    var domCP = $('#domicilioCodigoPostal').val();
    var domNE = $('#domicilioNoExterior').val();
    var domEs = $('#domicilioEstado').val();                    
    var domNA = $('#domicilioNombreAsentamiento').val();
    var domMun = $('#domicilioMunicipioID').val();              
    var loc = $('#domicilioLocalidad').val();                   
    var tAse = $('#domicilioTipoAsentamiento').val();
    var refUb = $('#domicilioReferenciaUbicacion').val();

    if (dom === '' || via === '' || nomVia === '' || domCP === '' || domNE === '' || domEs === '' || domNA === '' || domMun === '' || loc === '' || tAse === '' || refUb === '') {
        console.log("FALTAN DATOS");
    } else {
        var expCP = new RegExp("^[0-9]{5}");
        if (!expCP.test(domCP)) {
            alert('El Código Postal no es válido');

        } else {
            var noExterior = $('#domicilioNoExterior').val();
            var estado = $('#domicilioEstado').val();
            var asentamiento = $('#domicilioNombreAsentamiento').val();
            var nombreInterior = $('#domicilioNombreInterior').val();
            var referenciaVialidad = $('#domicilioReferenciaVialidad').val();
            var nombreVialidad = $('#domicilioNombreVialidad').val();
            var localidad = $('#domicilioLocalidad').val();
            var referenciaPosterior = $('#domicilioReferenciaPosterior').val();
            var cp = $('#domicilioCodigoPostal').val();
            var refUbi = $('#domicilioReferenciaUbicacion').val();
            var ambito = $("#domicilioTipoAmbito").val();
            var vialidad = $("#domicilioTipoVialidad").val();
            var municipio = $("#domicilioMunicipioID").val();
            var persona = $("#personaGeneralID").val();
            var tipoAsentamiento = $("#domicilioTipoAsentamiento").val();
            var domicilioID = $("#domicilioID").val();
            if (referenciaVialidad === '') {
                referenciaVialidad = 'NULL';
            }
            if (nombreInterior === '') {
                nombreInterior = 'NULL';
            }
            if (referenciaPosterior === '') {
                referenciaPosterior = 'NULL';
            }

            if (document.getElementById('btnModalDomicilio').innerHTML === "Editar Domicilio") {
                var id = $('#domicilioID').val();

                $.ajax({
                    type: 'POST',
                    url: "/Domicilios/updateDomicilio",
                    data: {
                        noexterior: noExterior,
                        estado: estado,
                        nombreasentamiento: asentamiento,
                        nointerior: nombreInterior,
                        referenciavialidad: referenciaVialidad,
                        nombrevialidad: nombreVialidad,
                        localidad: localidad,
                        referenciaposterior: referenciaPosterior,
                        codigopostal: cp,
                        referenciaubicacion: refUbi,
                        Tipo_AmbitoID: ambito,
                        Tipo_Vialidad: vialidad,
                        Municipio: municipio,
                        Persona: persona,
                        Tipo_Asentamiento: tipoAsentamiento,
                        DomicilioID: domicilioID,
                        PersonaID: persona
                    },
                    success: function (data) {
                        $('#modalRegisterForm').modal('hide');

                        var elemento = document.getElementsByClassName(`tablaDomicilio-${id}`);
                        $(elemento).remove();

                        nuevoContacto.setAttribute("id", id);
                        nuevoContacto.setAttribute("class", `tablaDomicilio-${id} tablaDomicilio`);

                        var estadoDom = $('#domicilioEstado option[value=' + estado + ']').text();
                        municipio = $('#domicilioMunicipioID option[value=' + municipio + ']').text();
                        localidad = $('#domicilioLocalidad option[value=' + localidad + ']').text();
                        tipoAsentamiento = $('#domicilioTipoAsentamiento option[value=' + tipoAsentamiento + ']').text();

                        nuevoContacto.innerHTML = `
                        <td>${estadoDom}</td>
                        <td>${municipio}</td>
                        <td>${localidad}</td>
                        <td>${tipoAsentamiento}</td>
                        <td>${refUbi}</td>
                        <td>
                            <button type="button" onclick="editarDom(this)" data-toggle="modal" data-target="#modalRegisterForm" class="btn btn-success" value=${id} name=${persona} id="editDom">Editar</button>
                            <button class="btn btn-primary" onclick="detailDom(this)" data-toggle="modal" data-target="#modalRegisterForm" value=${id} name=${persona} id="btnDetalleDom">Detalles</button>
                            <button class="btn btn-danger" onclick="borrarDom(this)" value=${id}>Borrar</button>
                        </td>
                    `;

                        listadoContactos.appendChild(nuevoContacto);
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Actualizado exitoso',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    },
                    error: function (r) {
                        console.log(r);
                    }
                });
                return false;

            } else {
                $.ajax({
                    type: 'POST',
                    url: "/Domicilios/addDomicilio",
                    data: {
                        noexterior: noExterior,
                        estado: estado,
                        nombreasentamiento: asentamiento,
                        nointerior: nombreInterior,
                        referenciavialidad: referenciaVialidad,
                        nombrevialidad: nombreVialidad,
                        localidad: localidad,
                        referenciaposterior: referenciaPosterior,
                        codigopostal: cp,
                        referenciaubicacion: refUbi,
                        Tipo_AmbitoID: ambito,
                        Tipo_Vialidad: vialidad,
                        Municipio: municipio,
                        Persona: persona,
                        Tipo_Asentamiento: tipoAsentamiento,
                        PersonaID: persona
                    },
                    success: function (data) {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Guardado exitoso',
                            showConfirmButton: false,
                            timer: 1500
                        })
                        $('#modalRegisterForm').modal('hide');
                        $('#lblNoDomicilio').hide();

                        nuevoContacto.setAttribute("id", `${data}`);
                        nuevoContacto.setAttribute("class", `tablaDomicilio-${data} tablaDomicilio`);

                        estado = $('#domicilioEstado option[value=' + estado + ']').text();
                        municipio = $('#domicilioMunicipioID option[value=' + municipio + ']').text();
                        localidad = $('#domicilioLocalidad option[value=' + localidad + ']').text();
                        tipoAsentamiento = $('#domicilioTipoAsentamiento option[value=' + tipoAsentamiento + ']').text();

                        nuevoContacto.innerHTML = `
                        <td>${estado}</td>
                        <td>${municipio}</td>
                        <td>${localidad}</td>
                        <td>${tipoAsentamiento}</td>
                        <td>${refUbi}</td>
                        <td>
                            <button type="button" onclick="editarDom(this)" data-toggle="modal" data-target="#modalRegisterForm" class="btn btn-success" value=${data} name=${persona} id="editDom">Editar</button>
                            <button type="button" class="btn btn-primary" onclick="detailDom(this)" data-toggle="modal" data-target="#modalRegisterForm" value=${data} name=${persona} id="btnDetalleDom">Detalles</button>
                            <button type="button" class="btn btn-danger" onclick="borrarDom(this)" value=${data}>Borrar</button>
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