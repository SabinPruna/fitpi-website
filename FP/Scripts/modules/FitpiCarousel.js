$(function() {
    console.log("ready!");
    $('.fitpiCarousel').carousel({
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
});