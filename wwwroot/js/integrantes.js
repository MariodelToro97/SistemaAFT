$(document).ready(function () {
    $('#integrantesTop').click(function () {
        document.getElementById('btnModalIntegrante').innerHTML = "Guardar";
        limpiarIntegrantes();
        $('#integrantePersonaID').val($('#personaOcultoID').val());
    });

    $('#btnModalIntegrante').click(function () {
        $("span.Integrantes").show();
    });
});

$('#formIntegrantes').submit(function () {
    var curp = $('#integranteCurp').val();
    var nombre = $('#integranteNombre').val();
    var aPaterno = $('#integranteApellidoPaterno').val();
    var aMaterno = $('#integranteApellidoMaterno').val();
    var persona = $('#integrantePersonaID').val();

    if (curp === '' || nombre === '' || aPaterno === '') {
        console.log('FALTAN DATOS');
    } else {
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
                    console.log(data);
                    $('#tableIntegrantes').load(" #tableIntegrantes");
                    $('#modalIntegrantes').modal('hide');
                },
                error: function (r) {
                    console.log(r);
                }
            });
            return false;
        }
    }
});

function limpiarIntegrantes() {
    $("#modalIntegrantes input").val("");
    $("#modalIntegrantes textarea").val("");
    $("#modalIntegrantes select").val("");
    $("span.Integrantes").hide();
}