function updateProgressBar(control, progress) {
    var currentValue = Number($(control).first()[0].value);
    var goalValue = Number($(control)[1].textContent.match(/\d+/)[0]);
    var percentange = currentValue * 100 / goalValue;

    var v = Math.floor(percentange) + "%";

    $(progress)[0].style.width = v;
    $(progress).eq(0).html(v);

}

function updateProgressBarWeight(control, progress) {
    var currentValue = Number($(control).first()[0].value);
    var goalValue = Number($(control)[1].textContent.match(/\d+/)[0]);

    var lost = 95 - currentValue;

    var percentange = lost * 100 / (95 -goalValue);

    var v = Math.floor(percentange) + "%";

    $(progress)[0].style.width = v;
    $(progress).eq(0).html(v);

}


$(function () {
    console.log("ready!");

    $('#fitpiCarousel').carousel({
        interval: false
    }); 

    $(".activities-nav-hover").click(function(e) {
        $("#fitpiCarousel").carousel(0);
    });
    $(".nutrition-nav-hover").click(function(e) {
        $("#fitpiCarousel").carousel(1);
    });
    $(".budget-nav-hover").click(function(e) {
        $("#fitpiCarousel").carousel(2);
    });
    $(".timetable-nav-hover").click(function(e) {
        $("#fitpiCarousel").carousel(3);
    });
    $(".worklog-nav-hover").click(function(e) {
        $("#fitpiCarousel").carousel(4);
    });
    $(".weather-nav-hover").click(function(e) {
        $("#fitpiCarousel").carousel(5);
    });

    $(".calories-control").on("change paste keyup", function () {
        updateProgressBar(".calories-control", ".calories-control-progress");
    });
    $(".minutes-control").on("change paste keyup", function () {
        updateProgressBar(".minutes-control", ".minutes-control-progress");
    });
    $(".distance-control").on("change paste keyup", function () {
        updateProgressBar(".distance-control", ".distance-control-progress");
    });
    $(".sleep-control").on("change paste keyup", function () {
        updateProgressBar(".sleep-control", ".sleep-control-progress");
    });
    $(".floors-control").on("change paste keyup", function () {
        updateProgressBar(".floors-control", ".floors-control-progress");
    });
    $(".steps-control").on("change paste keyup", function () {
        updateProgressBar(".steps-control", ".steps-control-progress");
    });
    $(".weight-control").on("change paste keyup", function () {
        updateProgressBarWeight(".weight-control", ".weight-control-progress");
    });

    updateProgressBar(".calories-control", ".calories-control-progress");
    updateProgressBar(".minutes-control", ".minutes-control-progress");
    updateProgressBar(".distance-control", ".distance-control-progress");
    updateProgressBar(".sleep-control", ".sleep-control-progress");
    updateProgressBar(".floors-control", ".floors-control-progress");
    updateProgressBarWeight(".weight-control", ".weight-control-progress");
    updateProgressBar(".steps-control", ".steps-control-progress");


    $(".datepicker").flatpickr({
        defaultDate: $(".date-for-datepicker").text(),
        dateFormat: "Y-m-d",
        onClose: function(selectedDates) {
            console.log("entered");
            window.location.href = "/Home/Index/?date=" + selectedDates[0].toISOString().slice(0, 10);
        }
    });

    $(".twitter-fitbit").click(function() {
        $.ajax({
            url: 'Home/Tweet',
            type: 'GET',
            data: { 'date': $(".datepicker").val() },
            success: function (result) {               
            }
        });  

    });

    $(".form-control").on('click', function (e) {
        //if ($(e.target).hasClass(".form-control")) {
            e.preventDefault();
        //}
    });



    $("#tweet-fitbit-button").on('click', function (e) {
        window.location.href = "/Fitbit/HeartRate/";
    });





    //var stepsContext = document.getElementById('stepsChart').getContext('2d');
    //var myChart = new Chart(stepsContext, {
    //    type: 'doughnut',
    //    data: {
    //        datasets: [{
    //            data: [12],
    //            backgroundColor: [
    //                'red'
    //            ],
    //            borderColor: [
    //                'red'
    //            ]
    //        }]
    //    }
    //});

});