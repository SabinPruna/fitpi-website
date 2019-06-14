$(function () {
    var dates = [];
    var sleeps = [];

    $.ajax({
        type: "GET",
        url: "/Fitbit/SleepJson",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (jsonData) {
            dates = jsonData[0];
            sleeps = jsonData[1];

            console.log(dates);
            console.log(sleeps);

            var gradientChartOptionsConfiguration = {
                maintainAspectRatio: false,
                legend: {
                    display: false,
                    labels: {
                        display: false
                    }
                },

                tooltips: {
                    backgroundColor: "#fff",
                    titleFontColor: "#333",
                    bodyFontColor: "#666",
                    bodySpacing: 4,
                    xPadding: 12,
                    mode: "nearest",
                    intersect: 0,
                    position: "nearest"
                },
                responsive: true,
                scales: {
                    yAxes: [
                        {
                            barPercentage: 1.6,
                            gridLines: {
                                drawBorder: false,
                                color: "rgba(29,140,248,0.0)",
                                zeroLineColor: "transparent",
                            },
                            ticks: {
                                suggestedMin: 50,
                                suggestedMax: 110,
                                padding: 20,
                                fontColor: "#9a9a9a"
                            }
                        }
                    ],

                    xAxes: [
                        {
                            barPercentage: 1.6,
                            gridLines: {
                                drawBorder: false,
                                color: "rgba(220,53,69,0.1)",
                                zeroLineColor: "transparent",
                            },
                            ticks: {
                                padding: 20,
                                fontColor: "#9a9a9a"
                            }
                        }
                    ]
                }
            };

            var ctx = document.getElementById("sleepChart").getContext("2d");
            var gradientStroke = ctx.createLinearGradient(0, 1000, 0, 50);

            gradientStroke.addColorStop(1, "rgba(72,72,176,0.2)");
            gradientStroke.addColorStop(0.2, "rgba(72,72,176,0.0)");
            gradientStroke.addColorStop(0, "rgba(119,52,169,0)"); //purple colors

            var data = {
                labels: dates,
                datasets: [
                    {
                        label: "Sleep",
                        fill: true,
                        backgroundColor: gradientStroke,
                        borderColor: "blueviolet",
                        borderWidth: 3,
                        borderDash: [],
                        borderDashOffset: 0.0,
                        pointBackgroundColor: "white",
                        pointBorderColor: "rgba(255,255,255,0)",
                        pointHoverBackgroundColor: "white",
                        pointBorderWidth: 20,
                        pointHoverRadius: 4,
                        pointHoverBorderWidth: 15,
                        pointRadius: 7,
                        data: sleeps
                    }
                ]
            };

            var sleepChart = new Chart(ctx,
                {
                    type: "line",
                    data: data,
                    options: gradientChartOptionsConfiguration
                });

        }
    });
});