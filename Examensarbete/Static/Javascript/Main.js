$(document).ready(function () {
    // Gets weather when page loads
   $.getJSON('/umbraco/api/darkskyapi/get')
        .done(function (data) {
            var obj = JSON.parse(data);
          
            var current = obj.CurrentWeather;
            var forecast = obj.DailyWeatherforecasts;
            var hourly = obj.HourlyWeather;

            console.log(obj)
            console.log(hourly)

            SetUpWeatherGadget(current);
            if (document.getElementById('forecastWeatherTable') !== null) {
                SetupWeatherForecastTable(obj);
            }

        });
    

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

        var windSpeedText = document.createTextNode(current.WindBearing + " " + current.WindSpeed + ":m/s");
        windSpeed.appendChild(windSpeedText);

        var currentHourText = document.createTextNode("Senaste mätningen: "+ current.CurrentHour + ":00 ");
        currentHour.appendChild(currentHourText);

        weatherGadget.appendChild(windSpeed);
        weatherGadget.appendChild(currentHour);
        weatherGadget.appendChild(link);
    }


    function SetupWeatherForecastTable(obj) {
        var forecast = obj.DailyWeatherforecasts;
        var hourly = obj.HourlyWeather;

        var tableRef = document.getElementById('forecastWeatherTable').getElementsByTagName('tbody')[0];
        for (var i = 0; i < forecast.length; i++) {
        
          // Insert a row in the table at row index 0
            var newRow = tableRef.insertRow(tableRef.rows.length);
            newRow.classList.add("dailyWeatherRow");
            

            if (i === 0) {
                newRow.id = "myRow";
                var rowHeader = tableRef.insertRow(tableRef.rows.length);
                rowHeader.classList.add("MyTestRow");
                var myTest = rowHeader.insertCell(0);
                myTest.colSpan = 10;
                for (var j = 0; j < hourly.length; j++) {

                    var extraRow = tableRef.insertRow(tableRef.rows.length);
                    var Hour = extraRow.insertCell(0);
                    var HourImage = extraRow.insertCell(1);
                    var HourTemp = extraRow.insertCell(2);
                    var HourWindBearing = extraRow.insertCell(3);
                    var HourWindSpeed = extraRow.insertCell(4);
                    var HourWindGust = extraRow.insertCell(5);

                    var HourlyIconImg = document.createElement("img");
                    HourlyIconImg.src = hourly[j].Icon;
                    HourlyIconImg.alt = hourly[j].Summary;
                    HourlyIconImg.id = "weatherIcon";

                    Hour.innerHTML = "Kl: " + hourly[j].Hour + ":00"; 
                    HourImage.innerHTML = "";
                    HourImage.appendChild(HourlyIconImg);
                    HourTemp.innerHTML = "Temp: " + hourly[j].Temp + "°C";

                    HourWindBearing.innerHTML = hourly[j].WindBearing;
                    HourWindSpeed.innerHTML = hourly[j].WindSpeed + "m/s";
                    HourWindGust.innerHTML = "(" + hourly[j].WindGust + "m/s)";
                }

                var rowFooter = tableRef.insertRow(tableRef.rows.length);
                rowFooter.classList.add("MyTestRow");
                var myTest2 = rowFooter.insertCell(0);
                myTest2.colSpan = 10;

            }

            //// Insert a cell in the row at current index
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

        }
    }
    
    $.fn.datepicker.defaults.format = "dd/mm";
    var date_input = $('.date');
    date_input.datepicker({
        todayHighlight: true,
        //autoclose: true,
        startDate: '-3d'

        // Options:
        // https://bootstrap-datepicker.readthedocs.io/en/latest/
        // http://api.jqueryui.com/datepicker/#option-dateFormat
    }).val();


    $("#forecastWeatherTable").on('click', 'tr#myRow', function() {
        $(this).nextUntil('tr.dailyWeatherRow').slideToggle();
    });
});



