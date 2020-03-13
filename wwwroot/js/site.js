$(document).ready( function() {
    $('#personaFisica').click(function () {
        $('#nombreMoral').hide();
        $('#curpHistoricas').show();
        $('#nav-representantes-tab').hide();
        $('#nav-integrantes-tab').hide();
        $('#columnaDos').show();
        $('#divCURP').show();
        $('#imagenSearch').show();
        $('#imagenSearchRFC').hide();
        $('#tableCurpHist').hide();
        
        document.getElementById('nombreGeneral').required = true;
        document.getElementById('nombreGeneral').setPointerCapture = "Campo requerido";
        document.getElementById('apellidoPaterno').required = true;
        document.getElementById('rfcPersona').required = false;
    
        document.getElementById('labelRFC').innerHTML = 'RFC:';
        document.getElementById('spanRFC').innerHTML = "";
    }); 
    
    $('#personaMoral').click(function () {
        $('#nombreMoral').show();
        $('#curpHistoricas').hide();
        $('#nav-representantes-tab').show();
        $('#nav-integrantes-tab').show();
        $('#columnaDos').hide();
        $('#divCURP').hide();
        $('#imagenSearch').hide();
        $('#imagenSearchRFC').show();
        $('#tableCurpHist').show();
    
        document.getElementById('nombreGeneral').required = false;
        document.getElementById('apellidoPaterno').required = false;
        document.getElementById('rfcPersona').required = true;
    
        document.getElementById('labelRFC').innerHTML = 'RFC<span class="text-danger font-weight-bold">*</span>:';
    });

    $('#CURP_Historicas').click(function () {
        if ($('#tableCurpHist').is(":visible")) {
            $('#tableCurpHist').hide();
        } else {
            $('#tableCurpHist').show();
        }
    });

    $('#nav-profile-tab').click(function () {
        $('#nav-general').hide();
        $('#formDomicilio').show();
        $('#botonFormUno').hide();
        $('#nav-bajas').hide();
        $('#nav-integrantes').hide();
        $('#nav-representantes').hide();
        $('#nav-obligacion').hide();
        $('#nav-cuenta').hide();
        $('#nav-domicilio').show();
        $('#botonesGeneral').hide();
    });

    $('#nav-home-tab').click(function () {
        $('#nav-general').show();
        $('#formDomicilio').hide();
        $('#botonFormUno').show();
        $('#nav-bajas').hide();
        $('#nav-integrantes').hide();
        $('#nav-representantes').hide();
        $('#nav-obligacion').hide();
        $('#nav-cuenta').hide();
        $('#nav-domicilio').hide();
        $('#botonesGeneral').show();
    });
    
    $('#nav-integrantes-tab').click(function () {
        $('#nav-general').hide();
        $('#formDomicilio').hide();
        $('#botonFormUno').hide();
        $('#nav-bajas').hide();
        $('#nav-integrantes').show();
        $('#nav-representantes').hide();
        $('#nav-obligacion').hide();
        $('#nav-cuenta').hide();
        $('#nav-domicilio').hide();
        $('#botonesGeneral').hide();
    });

    $('#nav-bajas-tab').click(function () {
        $('#nav-general').hide();
        $('#formDomicilio').hide();
        $('#botonFormUno').hide();
        $('#nav-bajas').show();
        $('#nav-integrantes').hide();
        $('#nav-representantes').hide();
        $('#nav-obligacion').hide();
        $('#nav-cuenta').hide();
        $('#nav-domicilio').hide();   
        $('#botonesGeneral').hide();
    });

    $('#btnAgregarDom').click(function () {
        document.getElementById('btnModalDomicilio').innerHTML = "Agregar Domicilio";
    });

    $('#editDom').click(function () {
        document.getElementById('btnModalDomicilio').innerHTML = "Editar Domicilio";
    });
});

function limpiarForm() {
    //$("#modalRegisterForm").find("input,textarea,select").val("");
    $("#modalRegisterForm input").val("");
    $("#modalRegisterForm textarea").val("");
    $("#modalRegisterForm select").val("");
    //document.getElementById('domicilioTipoAmbito').getElementsByTagName('option')[0].selected = 'selected';
}

function editarDom(boton) {
    var id = boton.value;
    
    $.ajax({
        type: 'GET',
        url: "/Domicilios/GetDomicilio",
        data:
        {
            id : id
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
            $('#domicilioNombreInterior').val(nombreInterior);
            $('#domicilioReferenciaVialidad').val(referenciaVialidad);
            $('#domicilioNombreVialidad').val(nombreVialidad);
            $('#domicilioLocalidad').val(localidad);
            $('#domicilioReferenciaPosterior').val(referenciaPosterior);
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
}

$('#formEditDomicilio').submit(function () {
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
    var persona = $("#domicilioPersonaID").val();
    var tipoAsentamiento = $("#domicilioTipoAsentamiento").val();
    var domicilioID = $("#domicilioID").val();

    if (document.getElementById('btnModalDomicilio').innerHTML === "Editar Domicilio") {
        console.log("EDITAR");
    } else {
        console.log("AGREGAR");
    }
    
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
});
