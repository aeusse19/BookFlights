$(function()
{
    get();
    $("#new").click(function(){
        post();
    });    
});

function post(){
    console.log($("#txtOrigin").val(),$("#txtDestination").val(), $("#txtFrom").val());
    var data = {
        "Origin":  $("#txtOrigin").val(), 
        "Destination": $("#txtDestination").val(),
        "From":$("#txtFrom").val()
    };

    $.ajax({
        url: 'http://testapi.vivaair.com/otatest/api/values',
        type: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        success: function (data) {
            alert(data);
            alert('OK');
            get();
        },
        error: function (request, msg, error) {
            alert("Error!" + request + " " + msg + " " + error);
        }
    });
};

function get() {
    $("#grid").empty();
    var $grid = $("#grid");

    var $tr = $("<tr></tr>");
    $tr.append("<td>Origen</td>");
    $tr.append("<td>Destino</td>");
    $tr.append("<td>Fecha vuelo</td>");

    $grid.append($tr);

    $.ajax({
        url: 'https://localhost:44312/api/Flights',
        type: 'GET',
        success: function (data) {
            console.log(data);
            $.each(data, function (idx, item) {
                var $tr = $("<tr></tr>");
                $tr.append("<td>"+item.DepartureStation+"</td>");
                $tr.append("<td>"+item.ArrivalStation+"</td>");
                $tr.append("<td>"+item.DepartureDate+"</td>");

                $grid.append($tr);
            })
        },
        error: function (request, msg, error) {
            alert("Error!" + request + " " + msg + " " + error);
        }
    });
}