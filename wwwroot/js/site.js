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
});

function limpiarForm() {
    //$("#modalRegisterForm").find("input,textarea,select").val("");
    $("#modalRegisterForm input").val("");
    $("#modalRegisterForm textarea").val("");
    $("#modalRegisterForm select").val("");
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
            var ambito = data[0]['Tipo_AmbitoID'];
            var vialidad = data[0]['Tipo_VialidadID'];
            var municipio = data[0]['MunicipioID'];
            var persona = data[0]['PersonaID'];
            var tipoAsentamiento = data[0]['Tipo_AsentamientoID'];
            var domicilioID = data[0]["domicilioID"];            
            console.log(data[0]['Tipo_VialidadID']);
            //document.getElementById('domicilioTipoVialidad').getElementsByTagName('option')[vialidad].selected = 'selected';


            //$("#domicilioTipoVialidad option[value = " + vialidad + "]").attr("selected", true);
            $("#domicilioTipoAsentamiento option[value = " + tipoAsentamiento + "]").attr("selected", true);
            $("#domicilioPersonaID option[value = " + persona + "]").attr("selected", true);
            $("#domicilioMunicipioID option[value = " + municipio + "]").attr("selected", true);
            $("#domicilioTipoAmbito option[value = " + ambito + "]").attr("selected", true);
           
            /*
            var select = document.getElementById('domicilioTipoVialidad');
            select.addEventListener('change',
                function () {
                    var selectedOption = this.options[select.selectedIndex];
                    ambito = selectedOption.text;
                });

            var select = document.getElementById('domicilioTipoAsentamiento');
            select.addEventListener('change',
                function () {
                    var selectedOption = this.options[select.selectedIndex];
                    console.log(selectedOption.value + ': ' + selectedOption.text);
                });

            var select = document.getElementById('domicilioPersonaID');
            select.addEventListener('change',
                function () {
                    var selectedOption = this.options[select.selectedIndex];
                    console.log(selectedOption.value + ': ' + selectedOption.text);
                });

            var select = document.getElementById('domicilioMunicipioID');
            select.addEventListener('change',
                function () {
                    var selectedOption = this.options[select.selectedIndex];
                    console.log(selectedOption.value + ': ' + selectedOption.text);
                });

            var select = document.getElementById('domicilioTipoAmbito');
            select.addEventListener('change',
                function () {
                    var selectedOption = this.options[select.selectedIndex];
                    console.log(selectedOption.value + ': ' + selectedOption.text);
                });
            */
           
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
