$(function() {
    var calendarEl = document.getElementById("timetableCalendar");

    var courses = [];

    $.ajax({
        type: "GET",
        url: "/Home/TimetableJson",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(jsonData) {
            courses = jsonData;

            var weekdays = new Array(7);
            weekdays[1] = "Monday";
            weekdays[2] = "Tuesday";
            weekdays[3] = "Wednesday";
            weekdays[4] = "Thursday";
            weekdays[5] = "Friday";

            var weekdaysDateNumber = new Array(7);
            weekdaysDateNumber[1] = 10;
            weekdaysDateNumber[2] = 11;
            weekdaysDateNumber[3] = 12;
            weekdaysDateNumber[4] = 13;
            weekdaysDateNumber[5] = 14;


            var timetable = new Timetable();
            timetable.setScope(7, 23);


            timetable.addLocations(["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"]);


            for (var i = 0; i < courses.length; i++) {
                timetable.addEvent(courses[i]["title"] + " in " + courses[i]["location"],
                    weekdays[courses[i]["daysOfWeek"]],
                    new Date(2019,
                        6,
                        weekdaysDateNumber[courses[i]["daysOfWeek"]],
                        courses[i]["startHour"],
                        courses[i]["endHour"]),
                    new Date(2019,
                        6,
                        weekdaysDateNumber[courses[i]["daysOfWeek"]],
                        courses[i]["endHour"],
                        courses[i]["endMinute"]));
            }

            var renderer = new Timetable.Renderer(timetable);
            renderer.draw(".timetable"); 

            //var calendar = new FullCalendar.Calendar(calendarEl,
            //    {
            //        plugins: ["dayGrid"],
            //        defaultView: "dayGridWeek",
            //        header: {
            //            center: "Timetable",
            //            right: "dayGridWeek"
            //        },
            //        weekends: false,
            //        columnHeaderFormat: {
            //            weekday: "long"
            //        },
            //        minTime: "07:00:00",
            //        maxTime: "22:00:00",
            //        firstDay: 1,
            //        defaultTimedEventDuration: "01:50",

            //        events: [// put the array in the `events` property
            //            {
            //                title: "event1",
            //                startTime: "10:00",
            //                dow: [2, 5]
            //            },
            //            {
            //                title: "event2",
            //                start: "10:20",
            //                end: "2010-01-07"
            //            },
            //            {
            //                title: "event3",
            //                start: "2019-06-11T12:30:00",
            //            }
            //        ]


            //    });

            //calendar.render();
        }
    });
});