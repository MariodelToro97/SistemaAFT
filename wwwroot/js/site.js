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
    
    if(document.getElementById('spanCURP').innerHTML = "This field is required."){
        document.getElementById('spanCURP').innerHTML = "Campo requerido";
    }
    
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
});