$(function()
{
    $("#new").click(function(){
        post();
    });    
});

function post(){
    var data = new Object();
    data.Origin = $('#txtOrigin').val();
    data.Destination = $('#txtDestination').val();
    data.From = $('#txtFrom').val();

    console.log(data.Origin, data.Destination, data.From);

    $("#grid").empty();
    var $grid = $("#grid");

    var $tr = $("<tr></tr>");
    $tr.append("<td>Origen</td>");
    $tr.append("<td>Destino</td>");
    $tr.append("<td>Fecha vuelo</td>");
    $grid.append($tr);

    $.ajax({
        url: 'https://testapi.vivaair.com/otatest/api/values',
        type: 'POST',
        data: JSON.stringify(data),
        contentType: "application/json", 
        success: function (data) {
            alert(data.Origin, data.Destination, data.From);
            alert(data);
            $.each(data, function (idx, item) {
                var $tr = $("<tr></tr>");
                $tr.append("<td>" + item.DepartureStation + "</td>");
                $tr.append("<td>" + item.ArrivalStation + "</td>");
                $tr.append("<td>" + item.DepartureDate + "</td>");
                $grid.append($tr);
            })
        },
        error: function (request, msg, error) {
            console.log("Error in method post!");
        }
    });
};
