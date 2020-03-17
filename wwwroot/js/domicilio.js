$(document).ready(function () {
    $('#btnAgregarDom').click(function () {
        $('#btnModalDomicilio').show();
        document.getElementById('btnModalDomicilio').innerHTML = "Agregar Domicilio";
        document.getElementById('btnCancelarDom').innerHTML = "Cancelar";
    });

    $('#btnModalDomicilio').click(function () {
        $("span.Modal").show();
    });
});

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
            var municipio = data[0]['municipioID'];
            var persona = data[0]['personaID'];
            var tipoAsentamiento = data[0]['tipo_AsentamientoID'];
            var domicilioID = data[0]["domicilioID"];

            $("#domicilioID").val(domicilioID);
            $('#domicilioNoExterior').val(noExterior);
            $('#domicilioEstado').val(estado);
            $('#domicilioNombreAsentamiento').val(asentamiento);


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

            document.getElementById('domicilioTipoVialidad').getElementsByTagName('option')[vialidad].selected = 'selected';
            document.getElementById('domicilioTipoAsentamiento').getElementsByTagName('option')[tipoAsentamiento].selected = 'selected';
            document.getElementById('domicilioMunicipioID').getElementsByTagName('option')[municipio].selected = 'selected';
            document.getElementById('domicilioTipoAmbito').getElementsByTagName('option')[ambito].selected = 'selected';
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
};

function borrarDom(boton) {
    var id = boton.value;

    $.ajax({
        type: 'POST',
        url: "/Domicilios/deleteDomicilio",
        data: {
            domID: id
        },
        success: function (data) {
            console.log(data);
            $('#tableDomicilio').load(" #tableDomicilio");
        },
        error: function (r) {
            console.log(r);
        }
    });
    return false;
}

$('#formEditDomicilio').submit(function () {

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
                    console.log(data);
                    $('#modalRegisterForm').modal('hide');
                    $('#tableDomicilio').load(" #tableDomicilio");
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
                    console.log(data);
                    $('#modalRegisterForm').modal('hide');
                    $('#tableDomicilio').load(" #tableDomicilio");
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;            
        }
    }
});