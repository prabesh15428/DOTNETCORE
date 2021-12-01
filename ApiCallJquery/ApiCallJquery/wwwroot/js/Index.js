var location;
var country;
var lat;
var lon;

$(document).ready(function () {

    $("#search").click(function (event) {

        search(event);

    });

    $("#save").click(function (event) {
        sendData(event);
    });

});

function search(event) {

    var request;
    event.preventDefault();

    request = $.ajax({
     
        url: "https://api.weatherapi.com/v1/current.json?key=e79be1ff301249c4bf562139211911&q=" + $("#locationtext").val() + "&aqi=no",
        type: "get",


    });

    request.done(function (response) {
        Update(response);
    });

}

function Update(objData) {
    location = objData.location.name;
    country = objData.location.country;
    lat = objData.location.lat;
    lon = objData.location.lon;

    $("#lbllocation").text(location);
    $("#lblCountry").text(country);
    $("#lbllon").text(lon);
    $("#lbllat").text(lat);


}

function sendData(event) {

    $.ajax({
        url: "/home/AddData",
        type: "post",
        data: { "location": location, "country": country, "lon": lon, "lat": lat },
        success: function (event) {
            alert("Data saved successfully");
        }

    });


}