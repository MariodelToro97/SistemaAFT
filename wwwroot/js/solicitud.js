$(document).ready(function () {
    $('#tipoPersonaSolicitante').change(function () {       
        var valor = $('#tipoPersonaSolicitante').val();
        var texto = $('#tipoPersonaSolicitante option[value=' + valor + ']').text();
        switch (texto) {
            case 'FISICA':                
                $('#curpBusquedaSolicitante').attr("disabled", false);
                $('#rfcBusquedaSolicitante').attr("disabled", true);
                $('#rfcBusquedaSolicitante').val('');
                break;
            case 'MORAL':                
                $('#rfcBusquedaSolicitante').attr("disabled", false);
                $('#curpBusquedaSolicitante').attr("disabled", true);
                $('#curpBusquedaSolicitante').val('');
                break;
        }
    });

    $('#btnLimpiarBusquedaSolic').click(function () {
        $('#formBusquedaSolicitante input').val('');
        $('#formBusquedaSolicitante select').val('');
        $('#curpBusquedaSolicitante').attr("disabled", true);
        $('#rfcBusquedaSolicitante').attr("disabled", true);

        $('#nav-Representante').hide();
        $('#nav-complementarios').hide();
        $('#nav-socioeconomicos').hide();
        $('#parteBajaSolicitantes').hide();
    });

    $('#nav-solicitante').click(function () {
        $('#solicitante_personal').show();
        $('#nav-domicilio').hide();
    });

    $('#nav-Representante').click(function () {
        $('#solicitante_personal').hide();
        $('#nav-domicilio').show();
    });

    $('#btnSiguienteUno, #btnSiguienteUnos').click(function () {
        $('#solicitante_personal').hide();
        $('#nav-domicilio').hide();
        $('#navegadorSolicitante').hide();
        $('#pantallaDos').show();
    });

    $('#btnRegresarUno, #btnRegresarUnos').click(function () {
        $('#solicitante_personal').show();
        $('#nav-domicilio').show();
        $('#navegadorSolicitante').show();
        $('#pantallaDos').hide();
    });

    $('#btnSiguienteDos').click(function () {
        $('#pantallaDos').hide();
        $('#crearProyecto').show();
    });
    
    $('#btnRegresarDos').click(function () {
        $('#solicitante_personal').show();
        $('#nav-domicilio').show();
        $('#navegadorSolicitante').show();
        $('#pantallaDos').hide();
    });
    
    $('#btnRegresarTres').click(function () {
        $('#pantallaDos').show();
        $('#crearProyecto').hide();
    });

    $('#btnSiguienteTres').click(function () {
        $('#pantallaCuatro').show();
        $('#crearProyecto').hide();
    });

    $('#btnRegresarCuatro').click(function () {
        $('#pantallaCuatro').hide();
        $('#crearProyecto').show();
    });
});

function calculoApoyo() {
    var canSol = $('#can_Sol').val();
    var cosUni = $('#cos_Uni').val();
    var apoPro = $('#apo_Pro').val();
    var apoEst = $('#apo_Est').val();
    var otroApo = $('#otro_Apo').val();
    var apoFed = $('#apo_Fed').val();

    if (canSol === '')
        canSol = 0;
    if (cosUni === '')
        cosUni = 0;
    if (apoPro === '')
        apoPro = 0;
    if (apoEst === '')
        apoEst = 0;
    if (otroApo === '')
        otroApo = 0;
    if (apoFed === '')
        apoFed = 0;

    canSol = parseFloat(canSol);
    cosUni = parseFloat(cosUni);
    apoPro = parseFloat(apoPro);
    apoEst = parseFloat(apoEst);
    otroApo = parseFloat(otroApo);
    apoFed = parseFloat(apoFed);

    $('#apo_Est').val((canSol * cosUni)/2 - apoPro);
    $('#mon_Apo').val(apoFed + apoEst + otroApo);
    $('#inv_Total').val();
}

$('#formBusquedaSolicitante').submit(function () {
    var valor = $('#tipoPersonaSolicitante').val();
    if (valor === '') {
        console.log('CAMPOS VACIOS');
    } else {
        var texto = $('#tipoPersonaSolicitante option[value=' + valor + ']').text();
        if (texto === 'FISICA') {
        /* AQUI VA EL AJAX CUANDO SE TENGA LA VISTA DE FISICA */
        } else {
            if (texto === 'MORAL') {
                if ($('#rfcBusquedaSolicitante').val() === '') {
                    console.log("CAMPOS VACIOS");
                } else {
                    var expRFC = new RegExp("^[A-Z]{4}[0-9]{6}[A-Z,0-9]{3}");
                    if (!expRFC.test($('#rfcBusquedaSolicitante').val())) {
                        alert("EL RFC NO ES VÁLIDO");
                    } else {
                        //AJAX PARA LLENAR ESPACIOS DE INFORMACION PERSONA
                        obtencionAJAX();
                    }
                }
            }
        }        
    }
    return false;
});

function obtencionTelefonosAJAX(persona) {
    var listadoContactos = document.querySelector('#tableTelefonosSolicitudes');
    var nuevoContacto = document.createElement('tr');

    $.ajax({
        type: 'GET',
        url: "/Peticiones/GetTelefonos",
        data: {
            id: persona
        },
        success: function (data) {
            if (Object.keys(data).length > 0) {
                document.getElementById('spanTelRegSol').innerHTML = Object.keys(data).length;
                for (var i = 0; i < Object.keys(data).length; i++) {         
                    listadoContactos = document.querySelector('#tableTelefonosSolicitudes');
                    nuevoContacto = document.createElement('tr');
                    nuevoContacto.setAttribute("id", data[i]['telefonoID']);
                    nuevoContacto.setAttribute("class", 'tablaTelefono-' + data[0]['telefonoID'] + ' tablaTelefono table-light border border-secondary text-center');

                    var comp = $('#companiaTelefono option[value=' + data[i]['companiaID'] + ']').text();
                    var tipo = $('#tipoTelefono option[value=' + data[i]['tipo_TelefonoID'] + ']').text();

                    nuevoContacto.innerHTML = `
                        <td>${tipo}</td>
                        <td>${comp}</td>
                        <td>${data[0]['numero']}</td>
                        <td>
                            <button type="button" onclick="editTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" class="btn btn-success" value=${data[i]['telefonoID']} name=${persona}>Editar</button>
                            <button type="button" class="btn btn-primary" onclick="detalleTelefono(this)" data-toggle="modal" data-target="#modalTelefonos" value=${data[i]['telefonoID']} name=${persona}>Detalles</button>
                            <!--<button type="button" class="btn btn-danger" onclick="deleteTelefono(this)" value=${data[i]['telefonoID']}>Borrar</button>-->
                        </td>
                    `;

                    listadoContactos.appendChild(nuevoContacto);
                }
            } else {
                nuevoContacto.setAttribute("class", 'table-light border border-secondary text-center tablaTelefono');
                nuevoContacto.innerHTML = `
                        <td>No hay teléfonos</td>`;
                listadoContactos.appendChild(nuevoContacto);
            }
            //AJAX PARA LLENAR DOMICILIOS
            obtencionDomiciliosAJAX(persona);
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

function obtencionDomiciliosAJAX(persona) {
    var listadoContactos = document.querySelector('#tablaDomicilioSolicitudes');
    var nuevoContacto = document.createElement('tr');

    $.ajax({
        type: 'GET',
        url: "/Peticiones/getDomicilios",
        data: {
            id: persona
        },
        success: function (data) {
            if (Object.keys(data).length > 0) {
                document.getElementById('spanDomRegSol').innerHTML = Object.keys(data).length;
                for (var i = 0; i < Object.keys(data).length; i++) {
                    listadoContactos = document.querySelector('#tablaDomicilioSolicitudes');
                    nuevoContacto = document.createElement('tr');
                    nuevoContacto.setAttribute("id", data[i]['domicilioID']);
                    nuevoContacto.setAttribute("class", 'tablaDomicilio-' + data[i]['domicilioID'] +' tablaDomicilio table-light border border-secondary text-center');

                    var vialidad = $('#domicilioTipoVialidad option[value=' + data[i]['tipo_VialidadID'] + ']').text();                    
                    var asentamiento = $('#domicilioTipoAsentamiento option[value=' + data[i]['tipo_AsentamientoID'] + ']').text();

                    nuevoContacto.innerHTML = `
                        <td>${vialidad}</td>
                        <td>${data[i]['codigopostal']}</td>
                        <td>${data[i]['estado']}</td>
                        <td>${data[i]['municipio']}</td>
                        <td>${data[i]['localidad']}</td>
                        <td>${asentamiento}</td>
                        <td>
                            <button type="button" onclick="editarDom(this)" data-toggle="modal" data-target="#modalRegisterForm" class="btn btn-success" value=${data[i]['domicilioID']} name=${persona}>Editar</button>
                            <button class="btn btn-primary" onclick="detailDom(this)" data-toggle="modal" data-target="#modalRegisterForm" value=${data[i]['domicilioID']} name=${persona} id="btnDetalleDom">Detalles</button>
                            <!--button class="btn btn-danger" onclick="borrarDom(this)" value=${data[i]['domicilioID']}>Borrar</button>-->
                        </td>
                    `;
                    listadoContactos.appendChild(nuevoContacto);
                }
            } else {
                nuevoContacto.setAttribute("class", 'table-light border border-secondary text-center');
                nuevoContacto.innerHTML = `
                        <td>No hay Domicilios</td>`;
                listadoContactos.appendChild(nuevoContacto);
            }

            //AJAX PARA LLENAR REPRESENTANTES
            obtencionRepresentantesAJAX(persona);
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

function obtencionRepresentantesAJAX(persona) {
    var listadoContactos = document.querySelector('#tableRepresentantesSolicitudes');
    var nuevoContacto = document.createElement('tr');
    
    $.ajax({
        type: 'GET',
        url: "/Peticiones/getRepre",
        data: {
            id: persona
        },
        success: function (data) {
            if (Object.keys(data).length > 0) {
                document.getElementById('spanRepRegSol').innerHTML = Object.keys(data).length;
                for (var i = 0; i < Object.keys(data).length; i++) {
                    listadoContactos = document.querySelector('#tableRepresentantesSolicitudes');
                    nuevoContacto = document.createElement('tr');
                    nuevoContacto.setAttribute("id", data[i]['representanteID']);
                    nuevoContacto.setAttribute("class", 'filaRepresentante tablaRepresentante table-light border border-secondary text-center');

                    var genero = "" + data[i]['curp'];
                    genero = genero.substring(10, 11);

                    if (genero === 'H') {
                        genero = 'MASCULINO';
                    } else {
                        genero = 'FEMENINO';
                    }

                    nuevoContacto.innerHTML = '<td></td>' +
                        '<td>' + data[i]['nombre'] +'</td>' +
                        '<td>' + data[i]['apellido_paterno'] +'</td>' +
                        '<td>' + data[i]['apellido_materno'] +'</td>' +
                        '<td>' + data[i]['curp'] +'</td>' +
                        '<td>' + genero +'</td>' +
                        '<td> ' +
                        '<button type="button" onclick="editarInt(this)" data-toggle="modal" data-target="#modalRepresentantes" class="btn btn-success" value="' + data[i]['representanteID'] + '" name="´' + persona + '">Editar</button>' +
                        '<button class="btn btn-primary mx-2" onclick="detailInt(this)" data-toggle="modal" data-target="#modalRepresentantes" name="' + persona + '" value="' + data[i]['representanteID'] + '" id="btnDetalleInt">Detalles</button>' +
                        '<!--<button class="btn btn-danger" onclick="borrarInt(this)" value="' + data[i]['representanteID'] + '">Borrar</button>-->' +
                        '</td >';
                    listadoContactos.appendChild(nuevoContacto);
                }
            } else {
                nuevoContacto.setAttribute("class", 'table-light border border-secondary text-center filaRepresentante tablaRepresentante');
                nuevoContacto.innerHTML = `
                        <td>No hay Representantes</td>`;
                listadoContactos.appendChild(nuevoContacto);
            }
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

function obtencionAJAX() {
    $.ajax({
        type: 'GET',
        url: "/Solicitudes/GetUserMoral",
        data: {
            rfc: $('#rfcBusquedaSolicitante').val()
        },
        success: function (data) {
            if (Object.keys(data).length === 0) {
                alert('La persona no está dada de alta');
            } else {
                $('#nav-Representante').show();
                $('#nav-complementarios').show();
                $('#nav-socioeconomicos').show();
                $('#parteBajaSolicitantes').show();

                $('#denInfPersSolic').val(data[0]['nombreMoral']);
                $('#personaIDSOLICITANTES').val(data[0]['personaID']);
                $('#fechConstInfPersSolic').val(data[0]['fecha_Consti']);
                $('#actEcoInfPerSoli').val(data[0]['actividadEconomica']);
                $('#denInfPersSolic').attr("disabled", true);
                $('#fechConstInfPersSolic').attr("disabled", true);
                $('#actEcoInfPerSoli').attr("disabled", true);

                if (data[0]['correo'] === 'NULL') {
                    $('#corInfGeneSoli').val('');
                } else {
                    $('#corInfGeneSoli').val(data[0]['correo']);
                }

                //AJAX PARA LLENAR TELEFONOS                        
                obtencionTelefonosAJAX($('#personaIDSOLICITANTES').val());
            }
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

$('#crearSolicitud').submit(function () {
    var year = $('#year').val();
    var programa = $('#programa').val();
    var componente = $('#componente').val();
    var instancia = $('#instancia').val();
    var delegacion = $('#delegacion').val();
    var estado = $('#estadoSolicitud').val();

    if (year === '' || programa === '' || componente === '' || instancia === '' || delegacion === '' || estado === '') {
        alert("Faltan Datos");
    } else {
        $.ajax({
            type: 'POST',
            url: "/Solicitudes/addSolicitud",
            data: {
                year: year,
                programa: programa,
                componente: componente,
                instancia: instancia,
                delegacion: delegacion,
                estado: estado
            },
            success: function (data) {
                if (data === '') {
                    alert('No se insertó por qué ya esta dado de alta');
                } else {
                    alert('Insertado con el id ' + data);
                    $('#solicitudID').val(data);
                }
            },
            error: function (r) {
                console.log(r);
            }
        });
        return false;
    }
    return false;
});

$('#crearProyecto').submit(function () {
    var nombreproyecto = $('#nombreproyecto').val();
    var tipoproyecto = $('#tipoproyecto').val();
    var objetivo = $('#objetivo').val();
    var fecha = $('#fecha').val();
    $('#proyectoSolicitudID').val($('#solicitudID').val());
    var solicitudID = $('#proyectoSolicitudID').val();

    if (nombreproyecto === '' || tipoproyecto === '' || objetivo === '' || fecha === '' || solicitudID === '') {
        alert("Faltan Datos");
    } else {
        $.ajax({
            type: 'POST',
            url: "/Solicitudes/addProyecto",
            data: {
                nombreproyecto: nombreproyecto,
                tipoproyecto: tipoproyecto,
                objetivo: objetivo,
                fecha: fecha,
                solicitudID: solicitudID
            },
            success: function (data) {
                if (data === '') {
                    alert('No se insertó por qué ya esta dado de alta');
                } else {
                    alert('Insertado con el id ' + data);
                    //$('#solicitudID').val(data);
                    //$('#proyectoSolicitudID').val(data);
                }
            },
            error: function (r) {
                console.log(r);
            }
        });
        return false;
    }
    return false;
});

   
    