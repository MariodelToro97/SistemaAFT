
$('#crearSolicitud').submit(function () {

    var year = $('#year').val();
    console.log(year)
    var programa = $('#programa').val();
    console.log(year)

    var componente = $('#componente').val();
    console.log(year)

    var instancia = $('#instancia').val();
    console.log(year)

    var delegacion = $('#delegacion').val();
    console.log(year)

    var estado = $('#estadoSolicitud').val();
    console.log(year)


    if (year === '' || programa === '' || componente === '' || instancia === '' || delegacion === '' || estado === '') {
        alert("Faltan Datos");
        return false;
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
                estado: estado,
            },
            success: function (data) {
                if (data === '') {
                    alert('No se insertó por qué ya esta dado de alta');
                } else {
                    alert('Insertado con el id ' + data);
                    $('#solicitudID').val(data);
                    //$('#proyectoSolicitudID').val(data);
                   
                }
            },
            error: function (r) {
                console.log(r);
            }
        });
        return false;
    }

})



$('#crearProyecto').submit(function () {

    var nombreproyecto = $('#nombreproyecto').val();
    console.log(nombreproyecto)
    var tipoproyecto = $('#tipoproyecto').val();
    console.log(tipoproyecto)

    var objetivo = $('#objetivo').val();
    console.log(objetivo)

    var fecha = $('#fecha').val();
    console.log(fecha)

    $('#proyectoSolicitudID').val($('#solicitudID').val());

    var solicitudID = $('#proyectoSolicitudID').val();
    console.log("id de solicitud", solicitudID)

    //return false;

    if (nombreproyecto === '' || tipoproyecto === '' || objetivo === '' || fecha === '' || solicitudID === '') {
        alert("Faltan Datos");
        return false;
    } else {
        $.ajax({
            type: 'POST',
            url: "/Solicitudes/addProyecto",
            data: {
                nombreproyecto: nombreproyecto,
                tipoproyecto: tipoproyecto,
                objetivo: objetivo,
                fecha: fecha,
                solicitudID: solicitudID,
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
    

})

   
    