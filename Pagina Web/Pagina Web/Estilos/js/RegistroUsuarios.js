function ConsultarNombre()
{
    let identificacion = $("#Identificacion").val();

    $.ajax({
        url: "https://apis.gometa.org/cedulas/" + identificacion,
        method: "GET",
        data: {},
        datatype: "json",
        success: function (response)
        {
            $("#Nombre").val(response.nombre);
        },
        error: function (response)
        {

        }
    })
}