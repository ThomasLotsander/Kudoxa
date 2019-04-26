$(document).ready(function () {
    // Gets weather when page loads
    $.getJSON('/umbraco/api/darkskyapi/get')
        .done(function (data) {
            var obj = JSON.parse(data);
            console.log(obj);

            document.getElementById("Temperature").innerText = obj.Temperature + "°";

            var weatherIcon = document.getElementById("weatherIcon");
            weatherIcon.src = obj.Icon;
            weatherIcon.alt = "weather icon";
            var weatherGadget = document.getElementById("weatherGadgetDiv");

            var windSpeed = document.createElement("p");
            //var windDirection = document.createElement("p").innerHTML = obj.WindBearing;
            //var timeOfDay = document.createElement("p").innerHTML = obj.WeatherDescription;

            var windSpeedText = document.createTextNode(obj.WindSpeed + "m/s " + obj.WindBearing);
            windSpeed.appendChild(windSpeedText);

            weatherGadget.appendChild(windSpeed);
            //weatherGadget.appendChild(windDirection);
            //weatherGadget.appendChild(timeOfDay);
        });

    // Updates weather every hour
    //setInterval(function () {
    //    $.getJSON('/umbraco/api/darkskyapi/get')
    //        .done(function (data) {
    //            console.log(data);
    //            console.table("varje timme?");
    //            console.table("mep: " + data.Icon);
    //        });
    //}, 1000);

});