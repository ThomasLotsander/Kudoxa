$(document).ready(function () {
    // Gets weather when page loads
    var GetWeather = true;
    if (GetWeather) {

          $.getJSON('/umbraco/api/darkskyapi/get')
        .done(function (data) {
            var obj = JSON.parse(data);
            var current = obj.CurrentWeather;
            var forecast = obj.DailyWeatherforecasts;
            console.log(obj);
            console.log(current);
            console.log(forecast);

            SetUpWeatherGadget(current);

            GetWeather = false; 
            if (document.getElementById('forecastWeatherTable') !== null) {
                SetupWeatherForecastTable(forecast);
                GetWeather = true;
            }

        });
    }

    function SetUpWeatherGadget(current) {
        document.getElementById("Temperature").innerText = current.Temperature + "°C";

        var weatherIcon = document.getElementById("weatherIcon");
        weatherIcon.src = current.Icon;
        weatherIcon.alt = "weather icon";

        var weatherGadget = document.getElementById("weatherGadgetDiv");

        var windSpeed = document.createElement("p");
        var currentHour = document.createElement("p");
        var link = document.createElement("a");
        link.href = "/vader";
        link.innerHTML = "Se mer";

        var windSpeedText = document.createTextNode(current.WindBearing + " " + current.WindSpeed + ":m/s " + "(" + current.WindGust + ")");
        windSpeed.appendChild(windSpeedText);

        var currentHourText = document.createTextNode(current.CurrentHour + ":00 ");
        currentHour.appendChild(currentHourText);

        weatherGadget.appendChild(windSpeed);
        weatherGadget.appendChild(currentHour);
        weatherGadget.appendChild(link);
    }

    function SetupWeatherForecastTable(forecast) {

        var tableRef = document.getElementById('forecastWeatherTable').getElementsByTagName('tbody')[0];
        for (var i = 0; i < forecast.length; i++) {
            console.log(forecast[i].Day);
            // Insert a row in the table at row index 0
            var newRow = tableRef.insertRow(tableRef.rows.length);

            //// Insert a cell in the row at index 0
            var Day = newRow.insertCell(0);
            var WeatherImage = newRow.insertCell(1);
            var MaxTemp = newRow.insertCell(2);
            var MinTemp = newRow.insertCell(3);
            var WindBearing = newRow.insertCell(4);
            var WindSpeed = newRow.insertCell(5);
            var WindGust = newRow.insertCell(6);
            var Summry = newRow.insertCell(7);
            var Sunrise = newRow.insertCell(8);
            var Sunset = newRow.insertCell(9);

            //// Append a text node to the cell
            ////var newText = document.createTextNode('New row')
            var iconImg = document.createElement("img");
            iconImg.src = forecast[i].Icon;
            iconImg.alt = forecast[i].Summary;
            iconImg.id = "weatherIcon";

            Day.innerHTML = forecast[i].Day;
            WeatherImage.innerHTML = "";
            WeatherImage.appendChild(iconImg);
            MaxTemp.innerHTML = "Max: " + forecast[i].TempMax + "°C";
            MinTemp.innerHTML = "Min: " + forecast[i].TempMin + "°C";
            WindBearing.innerHTML = forecast[i].WindBearing;
            WindSpeed.innerHTML = forecast[i].WindSpeed + "m/s";
            WindGust.innerHTML = "(" + forecast[i].WindGust + "m/s)";
            Summry.innerHTML = forecast[i].Summary;
            Sunrise.innerHTML = forecast[i].Sunrise;
            Sunset.innerHTML = forecast[i].SunSet;

            //newCell.appendChild(newText);
        }




    }

    setInterval(function() {
            GetWeather = true;

        },
        5000);

    console.log(GetWeather);


    // Updates weather every hour
    //setInterval(function () {
    //    $.getJSON('/umbraco/api/darkskyapi/get')
    //        .done(function (data) {
    //            console.log(data);
    //            console.table("varje timme?");
    //            console.table("mep: " + data.Icon);
    //        });
    //}, 3600000);

    var date_input = $('.date'); //our date input has the name "date"
    date_input.datepicker({
        todayHighlight: true,
        //autoclose: true,
        //dateFormat: 'dd/MM/yyyy',
        startDate: '-3d'

        // Options:
        // https://bootstrap-datepicker.readthedocs.io/en/latest/
        // http://api.jqueryui.com/datepicker/#option-dateFormat
    });
});