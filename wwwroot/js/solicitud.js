$(document).ready(function () {
    console.clear();
    $('#btnLimpiarBusquedaSolic').click(function () {
        limpPrimeraIndex();
    });
    $('#limpPantUno').click(function () {
        limpPrimeraIndex();
        limpiezaDosIndexSol();
    });

    $('#limpPantUnos').click(function () {
        limpPrimeraIndex();
        limpiezaDosIndexSol();
        $('#nav-domicilio').hide();
        $('#solicitante_personal').show();
    });

    $('#btnSiguienteUno, #btnSiguienteUnos').click(function () {
        $('#solicitante_personal').hide();
        $('#nav-domicilio').hide();
        $('#navegadorSolicitante').hide();
        $('#pantallaDos').show();
        
        if ($('#solicitudID').val() === '')
            $('#btnSiguienteDos').attr('disabled', true);
        else
            $('#btnSiguienteDos').attr('disabled', false);
    });

    $('#limpPantallaSolicitudesVentanilla').click(function () {
        $('#pantallaDos select').val('');
        $('#pantallaDos span.ventanilla').hide();
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

        if ($('#proyectoSolicitudID').val() === '')
            $('#btnSiguienteTres').attr('disabled', true);
        else
            $('#btnSiguienteTres').attr('disabled', false);
    });

    $('#limpiarPantallaProyectoSolicitudes').click(function () {
        $('#solicitante_personal select.proyecto').val('');
        $('#solicitante_personal input.proyecto').val('');
        $('#solicitante_personal textarea.proyecto').val('');
        $('#solicitante_personal span.proyecto').hide();
    });

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
        $('#solicitante_personal').show();
        $('#nav-domicilio').hide();
    });
    
    $('#btnRegresarTres').click(function () {
        $('#pantallaDos').show();
        $('#crearProyecto').hide();
    });

    $('#limpiarPantApoyosSolicitudes').click(function () {
        alert('HOLA ZAMANO, ME ABRISTE? JEJEJEJEJEJEJEJEJE CREO QUE YA ACABÉ AQUÍ, NO SÉ QUE DEBE PASAR CUANDO LE PIQUES AQUÍ, SI BORRAR TODO DE LA BASE DE DATOS O NO DEBERÍA EXISTIR ESTE BOTÓN, EN FIN LO DEJÉ PARA CUANDO SEPAMOS QUE VA AQUI SOLAMENTE LO COLOCAMOS')
    });

    $('#btnSiguienteTres').click(function () {
        $('#pantallaCuatro').show();
        $('#crearProyecto').hide();
    });

    $('#btnRegresarCuatro').click(function () {
        $('#pantallaCuatro').hide();
        $('#crearProyecto').show();
    });

    $('#agregarApoyoCotizacionSolicitudes').click(function () {
        limpiarModalApoyosSolicitudes();
        document.getElementById('btnGuardarApoyoSolicitantes').innerHTML = "Guardar";
        $('#btnGuardarApoyoSolicitantes').show();
        $('#apoyoSolicitantes span').show();
    });
});

function limpPrimeraIndex() {
    $('#formBusquedaSolicitante input').val('');
    $('#formBusquedaSolicitante select').val('');
    $('#curpBusquedaSolicitante').attr("disabled", true);
    $('#rfcBusquedaSolicitante').attr("disabled", true);

    $('#nav-Representante').hide();
    $('#nav-complementarios').hide();
    $('#nav-socioeconomicos').hide();
    $('#parteBajaSolicitantes').hide();
}

function limpiezaDosIndexSol() {
    var elemento = document.getElementsByClassName(`table-light border border-secondary text-center filaRepresentante tablaRepresentante`);
    $(elemento).remove();

    var otro = document.getElementsByClassName(`table-light border border-secondary text-center tablaTelefono`);
    $(otro).remove();

    var dos = document.getElementsByClassName(`table-light border border-secondary text-center tablaObtencionDomicilios`);
    $(dos).remove();
}

function apoProd(){
    calculoApoyo();
    var canSol = $('#can_Sol').val();
    var cosUni = $('#cos_Uni').val();

    if (canSol === '')
        canSol = 0;
    if (cosUni === '')
        cosUni = 0;

    canSol = parseFloat(canSol);
    cosUni = parseFloat(cosUni);

    document.getElementById('apo_Pro').setAttribute("max", canSol * cosUni);
}

$('#apoyoSolicitantes').submit(function () {
    var uniMed = $('#uniMed').val();
    var uniImp = $('#uniImp').val();

    if (uniMed === '')
        uniMed = "NULL";
    if (uniImp === '')
        uniImp = "NULL";

    var canSol = parseFloat($('#can_Sol').val());
    var cosUni = parseFloat($('#cos_Uni').val());
    var apoPro = parseFloat($('#apo_Pro').val());
    var apoEst = parseFloat($('#apo_Est').val());
    var otroApo = $('#otro_Apo').val();
    var apoFed = $('#apo_Fed').val();
    var monApo = parseFloat($('#mon_Apo').val());
    var invTot = parseFloat($('#inv_Total').val());
    var desc = $('#descSolicitanteApoyo').val();
    var proyecto = $('#proyectoSolicitudID').val();

    if (apoFed === '') {
        apoFed = 0;
    } else {
        apoFed = parseFloat(apoFed);
    }

    if (otroApo === '') {
        otroApo = 0;
    } else {
        otroApo = parseFloat(otroApo);
    }

    if ($('#concApoSolic').val() === '' || $('#subconcApoSoli').val() === '' || $('#can_Sol').val() === '' || $('#cos_Uni').val() === '' || $('#apo_Pro').val() === '' || $('#mon_Apo').val() === '' || $('#inv_Total').val() === '' || $('#descSolicitanteApoyo').val() === '') {        
        Swal.fire({
            position: 'top-end',
            icon: 'warning',
            title: 'Oops...',
            text: 'Faltan Datos',
            showConfirmButton: false,
            timer: 1500
        });
    } else {
        if (apoPro > (canSol * cosUni)) {
            Swal.fire({
                position: 'top-end',
                icon: 'warning',
                title: 'Oops...',
                text: 'La aportación del productor no puede ser mayor al costo solicitado',
                showConfirmButton: false,
                timer: 3000
            });            
        } else {
            listadoContactos = document.querySelector('#tablaApoyoSolicitantes');
            nuevoContacto = document.createElement('tr');

            if (document.getElementById('btnGuardarApoyoSolicitantes').innerHTML === "Guardar") {
                $.ajax({
                    type: 'POST',
                    url: "/Solicitudes/addCotizacion",
                    data: {
                        conc: $('#concApoSolic').val(),
                        subc: $('#subconcApoSoli').val(),
                        uniMed: uniMed,
                        uniImp: uniImp,
                        canSol: canSol,
                        costUni: cosUni,
                        apoPro: apoPro,
                        apoFed: apoFed,
                        apoEst: apoEst,
                        montApo: monApo,
                        otroApo: otroApo,
                        invTot: invTot,
                        desc: desc,
                        proyecto: proyecto
                    },
                    success: function (data) {
                        if (data === '') {
                            Swal.fire({
                                position: 'top-end',
                                icon: 'error',
                                title: 'Ha ocurrido un error en el guardado',
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
                            $('#modalApoyo').modal('hide');
                            $('#trInicialApoyosSolicitantes').remove();
                            var totalApoyos = document.getElementById('totalApoyosSolicitudes').innerHTML;
                            $('#trTotalApoyoSolicitante').remove();

                            nuevoContacto.setAttribute("id", `${data}`);
                            nuevoContacto.setAttribute("class", `tablaApoyos- ${data} tablaApoyos`);

                            var subConcepto = $('#subconcApoSoli option[value=' + $('#subconcApoSoli').val() + ']').text();

                            nuevoContacto.innerHTML = `
                                <td class="text-center">${subConcepto}</td>
                                <td class="text-center">${desc}</td>
                                <td class="text-right">$ ${monApo}</td>
                                <td class="text-right">$ ${apoPro}</td>
                                <td class="text-right">$ ${invTot}</td>
                                <td>
                                    <button type="button" onclick="editarApoyoSolicitante(${data})" data-toggle="modal" data-target="#modalApoyo" class="btn btn-success" value=${data}">Editar</button>
                                    <button type="button" class="btn btn-primary" onclick="getApoyosSolicitantes(${data})" data-toggle="modal" data-target="#modalApoyo" value=${data}>Detalles</button>
                                    <button type="button" class="btn btn-danger" onclick="borrarApoyosSolicitantes(this)" value=${data} name=${invTot}>Borrar</button>
                                </td>
                            `;

                            listadoContactos.appendChild(nuevoContacto);
                            nuevoContacto = document.createElement('tr');

                            nuevoContacto.setAttribute("id", `trTotalApoyoSolicitante`)
                            nuevoContacto.innerHTML = `
                                <td></td>
                                <td></td>
                                <td></td>
                                <td class="text-right font-weight-bold">Total:</td>
                                <td class="text-right font-weight-bold">$ <span id="totalApoyosSolicitudes" class ="font-weight-bold">0.00</span></th>
                                <td></td>
                            `;

                            listadoContactos.appendChild(nuevoContacto);

                            var registros = document.getElementById('spanApoyosSolicitantes').innerHTML;
                            registros = parseInt(registros);
                            totalApoyos = parseFloat(totalApoyos);
                            document.getElementById('spanApoyosSolicitantes').innerHTML = registros + 1;
                            document.getElementById('totalApoyosSolicitudes').innerHTML = totalApoyos + invTot;

                        }
                    },
                    error: function (r) {
                        console.log(r);
                    }
                });
                return false;
            } else {
                if (document.getElementById('btnGuardarApoyoSolicitantes').innerHTML === "Editar") {                    
                    $.ajax({
                        type: 'POST',
                        url: "/Solicitudes/updateCotizacion",
                        data: {
                            conc: $('#concApoSolic').val(),
                            subc: $('#subconcApoSoli').val(),
                            uniMed: uniMed,
                            uniImp: uniImp,
                            canSol: canSol,
                            costUni: cosUni,
                            apoPro: apoPro,
                            apoFed: apoFed,
                            apoEst: apoEst,
                            montApo: monApo,
                            otroApo: otroApo,
                            invTot: invTot,
                            desc: desc,
                            proyecto: proyecto,
                            id: $('#idCotizacionSolicitudes').val()
                        },
                        success: function (data) {
                            if (data !== 'SUCCESS') {
                                Swal.fire({
                                    position: 'top-end',
                                    icon: 'error',
                                    title: 'Ha ocurrido un error inesperado',
                                    showConfirmButton: false,
                                    timer: 1500
                                })
                            } else {
                                if (data === 'SUCCESS') {
                                    Swal.fire({
                                        position: 'top-end',
                                        icon: 'success',
                                        title: 'Guardado exitoso',
                                        showConfirmButton: false,
                                        timer: 1500
                                    })
                                    $('#modalApoyo').modal('hide');
                                    $('#trInicialApoyosSolicitantes').remove();
                                    var totalApoyos = document.getElementById('totalApoyosSolicitudes').innerHTML;
                                    var id = $('#idCotizacionSolicitudes').val();
                                    $('#trTotalApoyoSolicitante').remove();

                                    var elemento = document.getElementsByClassName(`tablaApoyos- ${id}`);
                                    $(elemento).remove();

                                    nuevoContacto.setAttribute("id", $('#idCotizacionSolicitudes').val());
                                    nuevoContacto.setAttribute("class", 'tablaApoyos- ' + $('#idCotizacionSolicitudes').val() + ' tablaApoyos');
                                    
                                    var subConcepto = $('#subconcApoSoli option[value=' + $('#subconcApoSoli').val() + ']').text();

                                    nuevoContacto.innerHTML = `
                                    <td class="text-center">${subConcepto}</td>
                                    <td class="text-center">${desc}</td>
                                    <td class="text-right">$ ${monApo}</td>
                                    <td class="text-right">$ ${apoPro}</td>
                                    <td class="text-right">$ ${invTot}</td>
                                    <td>
                                        <button type="button" onclick="editarApoyoSolicitante(${id})" data-toggle="modal" data-target="#modalApoyo" class="btn btn-success" value=${id}">Editar</button>
                                        <button type="button" class="btn btn-primary" onclick="getApoyosSolicitantes(${id})" data-toggle="modal" data-target="#modalApoyo" value=${id}>Detalles</button>
                                        <button type="button" class="btn btn-danger" onclick="borrarApoyosSolicitantes(this)" value=${id} name=${invTot}>Borrar</button>
                                    </td>
                                    `;

                                    listadoContactos.appendChild(nuevoContacto);
                                    nuevoContacto = document.createElement('tr');

                                    nuevoContacto.setAttribute("id", `trTotalApoyoSolicitante`)
                                    nuevoContacto.innerHTML = `
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td class="text-right font-weight-bold">Total:</td>
                                    <td class="text-right font-weight-bold">$ <span id="totalApoyosSolicitudes" class ="font-weight-bold">0.00</span></th>
                                    <td></td>
                                    `;

                                    listadoContactos.appendChild(nuevoContacto);

                                    var invAnt = parseFloat($('#invTotalAnteriorApoyoSolicitudes').val());
                                    totalApoyos = parseFloat(totalApoyos);
                                    var nueva = invAnt - invTot;
                                    document.getElementById('totalApoyosSolicitudes').innerHTML = totalApoyos - nueva;
                                }
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
    }
    return false;
});

function borrarApoyosSolicitantes(boton) {
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
            var inv = parseFloat(boton.name);

            $.ajax({
                type: 'POST',
                url: "/Solicitudes/deleteCotizacion",
                data: {
                    id: id
                },
                success: function (data) {
                    var elemento = document.getElementsByClassName(`tablaApoyos- ${id}`);

                    $(elemento).remove();
                    document.getElementById('spanApoyosSolicitantes').innerHTML = data;
                    if (data === '0') {
                        $('#trTotalApoyoSolicitante').remove();

                        listadoContactos = document.querySelector('#tablaApoyoSolicitantes');
                        nuevoContacto = document.createElement('tr');

                        nuevoContacto.setAttribute("id", `trInicialApoyosSolicitantes`)
                        nuevoContacto.innerHTML = `
                                <td class="font-weight-normal">Ningún dato disponible en esta tabla</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></th>
                                <td></td>
                            `;

                        listadoContactos.appendChild(nuevoContacto);

                        nuevoContacto = document.createElement('tr');

                        nuevoContacto.setAttribute("id", `trTotalApoyoSolicitante`)
                        nuevoContacto.innerHTML = `
                                <td></td>
                                <td></td>
                                <td></td>
                                <td class="text-right font-weight-bold">Total:</td>
                                <td class="text-right font-weight-bold">$ <span id="totalApoyosSolicitudes" class ="font-weight-bold">0.00</span></th>
                                <td></td>
                            `;

                        listadoContactos.appendChild(nuevoContacto);
                    } else {
                        var totalApoyos = document.getElementById('totalApoyosSolicitudes').innerHTML;
                        totalApoyos = parseFloat(totalApoyos);
                        document.getElementById('totalApoyosSolicitudes').innerHTML = totalApoyos - inv;
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

//Agregue este comentario

function calculoApoyo() {
    var canSol = $('#can_Sol').val();
    var cosUni = $('#cos_Uni').val();
    var apoPro = $('#apo_Pro').val();

    if (canSol === '')
        canSol = 0;
    if (cosUni === '')
        cosUni = 0;
    if (apoPro === '')
        apoPro = 0;

    canSol = parseFloat(canSol);
    cosUni = parseFloat(cosUni);
    apoPro = parseFloat(apoPro);

    $('#apo_Est').val((canSol * cosUni) / 2 - apoPro);

    var apoEst = $('#apo_Est').val();
    var otroApo = $('#otro_Apo').val();
    var apoFed = $('#apo_Fed').val();

    if (apoEst === '')
        apoEst = 0;
    if (otroApo === '')
        otroApo = 0;
    if (apoFed === '')
        apoFed = 0;

    apoEst = parseFloat(apoEst);
    otroApo = parseFloat(otroApo);
    apoFed = parseFloat(apoFed);

    $('#mon_Apo').val(apoFed + apoEst + otroApo);

    var monApo = $('#mon_Apo').val();

    if (monApo === '')
        monApo = 0;
    monApo = parseFloat(monApo);
    $('#inv_Total').val(apoFed + monApo);  
}

function editarApoyoSolicitante(id) {
    getApoyosSolicitantes(id);
    $('#btnGuardarApoyoSolicitantes').show();
    document.getElementById('btnGuardarApoyoSolicitantes').innerHTML = "Editar";
    $('#apoyoSolicitantes span').show();
}

function limpiarModalApoyosSolicitudes() {
    $('#apoyoSolicitantes select').val("");
    $('#apoyoSolicitantes textarea').val("");
    $('#apoyoSolicitantes input').val("");
    $('#apoyoSolicitantes span').hide();
}

function getApoyosSolicitantes(id) {
    $('#btnGuardarApoyoSolicitantes').hide();
    limpiarModalApoyosSolicitudes();
    $.ajax({
        type: 'GET',
        url: "/Solicitudes/GetApoyos",
        data: {
            id: id
        },
        success: function (data) {
            $('#idCotizacionSolicitudes').val(data[0]['cotizacionID']);
            $('#concApoSolic').val(data[0]['concepto_ApoyoID']);
            $('#subconcApoSoli').val(data[0]['subconcepto_ApoyoID']);

            if (data[0]['unidad_Medida'] === "NULL")
                $('#uniMed').val('');
            else
                $('#uniMed').val(data[0]['unidad_Medida']);

            if (data[0]['unidad_Impacto'] === "NULL")
                $('#uniImp').val('');
            else
                $('#uniImp').val(data[0]['cotizacionID']);

            $('#can_Sol').val(data[0]['can_Sol']);
            $('#cos_Uni').val(data[0]['cos_Uni']);
            $('#apo_Pro').val(data[0]['apo_Pro']);
            $('#apo_Fed').val(data[0]['apo_Fed']);
            $('#apo_Est').val(data[0]['apo_Est']);
            $('#mon_Apo').val(data[0]['mon_Apo']);
            $('#otro_Apo').val(data[0]['otro_Apo']);
            $('#inv_Total').val(data[0]['inv_Total']);
            $('#invTotalAnteriorApoyoSolicitudes').val(data[0]['inv_Total']);
            $('#descSolicitanteApoyo').val(data[0]['descripcion']);
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

$('#formBusquedaSolicitante').submit(function () {
    var valor = $('#tipoPersonaSolicitante').val();
    if (valor === '') {        
        Swal.fire({
            position: 'top-end',
            icon: 'warning',
            title: 'Oops...',
            text: 'Faltan Datos',
            showConfirmButton: false,
            timer: 1500
        });
    } else {
        var texto = $('#tipoPersonaSolicitante option[value=' + valor + ']').text();

        if (texto === 'FISICA') {
            $('#personaFisica').show();
            $('#personaMoral').hide();

            if ($('#curpBusquedaSolicitante').val() === '') {
                Swal.fire({
                    position: 'top-end',
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'Faltan Datos',
                    showConfirmButton: false,
                    timer: 1500
                });
            } else {
                var expCURP = new RegExp("^[A-Z]{4}[0-9]{6}[H,M][A-Z]{5}[A-Z,0-9][0-9]");
                if (!expCURP.test($('#curpBusquedaSolicitante').val())) {                    
                    Swal.fire({
                        position: 'top-end',
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'La CURP no es válida',
                        showConfirmButton: false,
                        timer: 1500
                    });
                } else {
                    //AJAX PARA LLENAR ESPACIOS DE INFORMACION PERSONA
                    obtencionFisicaAJAX();
                }
            }
        } else {
            if (texto === 'MORAL') {
                $('#personaFisica').hide();
                $('#personaMoral').show();

                if ($('#rfcBusquedaSolicitante').val() === '') {                    
                    Swal.fire({
                        position: 'top-end',
                        icon: 'warning',
                        title: 'Oops...',
                        text: 'Faltan Datos',
                        showConfirmButton: false,
                        timer: 1500
                    });
                } else {
                    var expRFC = new RegExp("^[A-Z]{4}[0-9]{6}[A-Z,0-9]{3}");
                    if (!expRFC.test($('#rfcBusquedaSolicitante').val())) {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'warning',
                            title: 'Oops...',
                            text: 'El RFC no es válido',
                            showConfirmButton: false,
                            timer: 1500
                        });
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

function obtencionFisicaAJAX() {
    $.ajax({
        type: 'GET',
        url: "/Solicitudes/GetUserFisica",
        data: {
            curp: $('#curpBusquedaSolicitante').val()
        },
        success: function (data) {
            if (Object.keys(data).length === 0) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'La persona no está dada de alta',
                    showConfirmButton: false,
                    timer: 2000
                });
            } else {
                $('#parteBajaSolicitantes').show();

                $('#personaIDSOLICITANTES').val(data[0]['personaID']);

                $('#generoPersona').val(data[0]['generoID']);                
                $('#nacimientoPersona').val(data[0]['fechaNacimiento']);
                $('#civilPersona').val(data[0]['estado_CivilID']);
                $('#nacionalidadPers').val(data[0]['nacionalidadID']);
                $('#tipoIdenPersona').val(data[0]['tipo_IdentidadID']);
                $('#numIdenPersona').val(data[0]['num_identificacion']);

                if (data[0]['etniaID'] === 1) {                    
                    document.getElementById('etniaNegPersona').checked = true;
                    document.getElementById('etniaPosPersona').checked = false;
                } else {
                    document.getElementById('etniaPosPersona').checked = true;
                    document.getElementById('etniaNegPersona').checked = false;
                }

                if (data[0]['discapacidadID'] === 1) {
                    document.getElementById('discNegPersona').checked = true;
                    document.getElementById('discPosPersona').checked = false;
                } else {
                    document.getElementById('discPosPersona').checked = true;
                    document.getElementById('discNegPersona').checked = false;
                }

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
                nuevoContacto.setAttribute("class", 'table-light border border-secondary text-center tablaObtencionDomicilios');
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
                Swal.fire({
                    position: 'top-end',
                    icon: 'warning',
                    title: 'Oops...',
                    text: 'La persona no está dada de alta',
                    showConfirmButton: false,
                    timer: 2000
                });
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
    $('#pantallaDos span.ventanilla').show();
    var year = $('#year').val();
    var programa = $('#programa').val();
    var componente = $('#componente').val();
    var instancia = $('#instancia').val();
    var delegacion = $('#delegacion').val();
    var estado = $('#estadoSolicitud').val();
    var persona = $('#personaIDSOLICITANTES').val();

    if (year === '' || programa === '' || componente === '' || instancia === '' || delegacion === '' || estado === '') {        
        Swal.fire({
            position: 'top-end',
            icon: 'warning',
            title: 'Oops...',
            text: 'Faltan datos',
            showConfirmButton: false,
            timer: 1500
        });
    } else {
        if ($('#btnCrearSolicitudVentanilla').val() === 'Crear') {
            $.ajax({
                type: 'POST',
                url: "/Solicitudes/addSolicitud",
                data: {
                    year: year,
                    programa: programa,
                    componente: componente,
                    instancia: instancia,
                    delegacion: delegacion,
                    estado: estado,
                    persona: persona
                },
                success: function (data) {
                    if (data === '') {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'warning',
                            title: 'Oops...',
                            text: 'La persona ya está dada de alta',
                            showConfirmButton: false,
                            timer: 2000
                        });
                    } else {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Guardado exitoso',
                            showConfirmButton: false,
                            timer: 1500
                        })
                        $('#solicitudID').val(data);
                        $('#btnCrearSolicitudVentanilla').val('Editar');
                        $('#btnSiguienteDos').attr('disabled', false);
                    }
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;
        } else {
            if ($('#btnCrearSolicitudVentanilla').val() === 'Editar') {
                var id = $('#solicitudID').val();
                $.ajax({
                    type: 'POST',
                    url: "/Solicitudes/updateSolicitud",
                    data: {
                        year: year,
                        programa: programa,
                        componente: componente,
                        instancia: instancia,
                        delegacion: delegacion,
                        estado: estado,
                        id: id
                    },
                    success: function (data) {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: 'Editado exitoso',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    },
                    error: function (r) {
                        console.log(r);
                    }
                });
                return false;
            }
        }
    }
    return false;
});

$('#crearProyecto').submit(function () {
    var nombreproyecto = $('#nombreproyecto').val();
    var tipoproyecto = $('#tipoproyecto').val();
    var objetivo = $('#objetivo').val();
    var fecha = $('#fecha').val();
    var solicitudID = $('#solicitudID').val();
    if (objetivo === '')
        objetivo = "NULL"

    if (nombreproyecto === '' || tipoproyecto === '' || fecha === '' || solicitudID === '') {        
        Swal.fire({
            position: 'top-end',
            icon: 'warning',
            title: 'Oops...',
            text: 'Faltan datos',
            showConfirmButton: false,
            timer: 1500
        });
    } else {
        if ($('#btnCrearProyectoSolicitudes').val() === 'Crear') {
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
                        Swal.fire({
                            position: 'top-end',
                            icon: 'error',
                            title: 'Ha ocurrido un error inesperado',
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
                        $('#proyectoSolicitudID').val(data);
                        $('#btnCrearProyectoSolicitudes').val('Editar');
                        $('#btnSiguienteTres').attr('disabled', false);
                    }
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;
        } else {
            if ($('#btnCrearProyectoSolicitudes').val() === 'Editar') {
                var id = $('#proyectoSolicitudID').val();
                $.ajax({
                    type: 'POST',
                    url: "/Solicitudes/updateProyecto",
                    data: {
                        nombreproyecto: nombreproyecto,
                        tipoproyecto: tipoproyecto,
                        objetivo: objetivo,
                        fecha: fecha,
                        solicitudID: solicitudID,
                        id: id
                    },
                    success: function (data) {
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
            }
        }
    }
    return false;
});


function GetCotizacionPersona(id) {
    $.ajax({
        type: 'GET',
        url: "/Solicitudes/GetCotizacion",
        data: {
            id: id
        },
        success: function (data) {
            //$('#trInicialApoyosSolicitantes').remove();
            //$('#trTotalApoyoSolicitante').remove();

            if (data.length === 0) {
                return
            }

            listadoContactos = document.querySelector('#tablaApoyoSolicitantes');
            //nuevoContacto = document.createElement('tr');
            let res1 = document.querySelector('#tablaApoyoSolicitantes');
            res1.innerHTML = '';
            let contador = 0
            let total = 0;
                for (var res of data) {
                    //nuevoContacto.setAttribute("id", `${res.cotizacionID}`);
                    //nuevoContacto.setAttribute("class", `tablaApoyos- ${res.cotizacionID} tablaApoyos`);
                    res1.innerHTML += `
                                <td class="text-center">${res.subconcepto_ApoyoID}</td>
                                <td class="text-center">${res.descripcion}</td>
                                <td class="text-right">$ ${res.mon_Apo}</td>
                                <td class="text-right">$ ${res.apo_Pro}</td>
                                <td class="text-right">$ ${res.inv_Total}</td>
                                <td>
                                    <button type="button" class="btn btn-primary" onclick="getApoyosSolicitantes(${res.cotizacionID})" data-toggle="modal" data-target="#modalApoyo" value=${res.cotizacionID}>Detalles</button>
                                </td>
                               
                            `;
                    contador = contador + 1;
                    total = total + res.inv_Total;

                    if (contador === data.length) {
                        nuevoContacto = document.createElement('tr');
                        nuevoContacto.innerHTML = `
                                <td></td>
                                <td></td>
                                <td></td>
                                <td class="text-right font-weight-bold">Total:</td>
                                <td class="text-right font-weight-bold">$ <span id="totalApoyosSolicitudes" class ="font-weight-bold">${total}</span></th>
                                <td></td>
                            `;

                        listadoContactos.appendChild(nuevoContacto);
                    }

                }
                document.getElementById('spanApoyosSolicitantes').innerHTML = data.length;            
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

var x = $(".proyectoVersionNuevo").val();
//console.log("id", x);

if (x != undefined) {
    GetCotizacionPersona(x);
}
