
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
                    //limpiarPersona();
                    //$('#personaGeneralID').val(data);
                    // habilitarModales();
                }
            },
            error: function (r) {
                console.log(r);
            }
        });
        return false;
    }

    /*

        if (rfc === 'NULL' || nombreMoral === 'NULL' || genero === '' || nacimiento === '' || civil === '' || nacionalidad === '' || numIdent === '' || identidad === '') {
            console.log("FALTAN DATOS");
        } else {
            var expRFC = new RegExp("^[A-Z]{4}[0-9]{6}[A-Z,0-9]{3}");
            if (!expRFC.test(rfc)) {
                alert('El RFC no es válido');
            } else {
                $.ajax({
                    type: 'POST',
                    url: "/Personas/addPersona",
                    data: {
                        curp: curp,
                        rfc: rfc,
                        nombrePersona: nombrePersona,
                        aPaterno: aPaterno,
                        aMAterno: aMAterno,
                        correo: correo,
                        nacimiento: nacimiento,
                        nacionalidad: nacionalidad,
                        genero: genero,
                        civil: civil,
                        identidad: identidad,
                        numIdent: numIdent,
                        tipoPersona: tipoPersona,
                        etnia: etnia,
                        discapacidad: discapacidad,
                        suri: suri,
                        nombreMoral: nombreMoral
                    },
                    success: function (data) {
                        if (data === '') {
                            alert('No se insertó por qué ya esta dado de alta');
                        } else {
                            alert('Insertado con el id ' + data);
                            //limpiarPersona();
                            $('#personaGeneralID').val(data);
                        }
                    },
                    error: function (r) {
                        console.log(r);
                    }
                });
                //console.log("retorno falso")
                return false;
            }
        }
        */
})
   
    