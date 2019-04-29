$(document).ready(function () {
    // Gets weather when page loads
    $.getJSON('/umbraco/api/darkskyapi/get')
        .done(function (data) {
            var obj = JSON.parse(data);
            console.log(obj);
            var current = obj.CurrentWeather;
            console.log(current);
            document.getElementById("Temperature").innerText = current.Temperature + "°";

            var weatherIcon = document.getElementById("weatherIcon");
            weatherIcon.src = current.Icon;
            weatherIcon.alt = "weather icon";
            var weatherGadget = document.getElementById("weatherGadgetDiv");

            var windSpeed = document.createElement("p");
            var currentHour = document.createElement("p");
            var link = document.createElement("a");

            var windSpeedText = document.createTextNode(current.WindBearing + " " + current.WindSpeed + ":m/s " + "(" + current.WindGust + ")");
            windSpeed.appendChild(windSpeedText);

            var currentHourText = document.createTextNode(current.CurrentHour + ":00 ");
            currentHour.appendChild(currentHourText);

            link.href = "/vader";
            link.innerHTML = "Se mer";
            weatherGadget.appendChild(windSpeed);
            weatherGadget.appendChild(currentHour);
            weatherGadget.appendChild(link);
        });



    // Updates weather every hour
    //setInterval(function () {
    //    $.getJSON('/umbraco/api/darkskyapi/get')
    //        .done(function (data) {
    //            console.log(data);
    //            console.table("varje timme?");
    //            console.table("mep: " + data.Icon);
    //        });
    //}, 3600000);

});