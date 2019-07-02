function speakToWindow(message) {
    var msg = new window.SpeechSynthesisUtterance(message);
    msg.voice = window.speechSynthesis.getVoices()[4];
    msg.volume = 1;
    msg.rate = 1;
    msg.pitch = 0;
    msg.lang = 'en-US';
    msg.onend = function (e) {
        console.log('Finished in ' + event.elapsedTime + ' seconds.');
    };
    window.speechSynthesis.speak(msg);
}

$(function () {
    var SpeechRecognition = SpeechRecognition || webkitSpeechRecognition;
    var SpeechGrammarList = SpeechGrammarList || webkitSpeechGrammarList;
    var SpeechRecognitionEvent = SpeechRecognitionEvent || webkitSpeechRecognitionEvent;

     window.SpeechRecognition = window.webkitSpeechRecognition || window.SpeechRecognition;

    if ('SpeechRecognition' in window) {
        // speech recognition API supported
        console.log("good");
    } else {
        // speech recognition API not supported
        console.log("bad");
    }

    var recognition = new window.SpeechRecognition();

    recognition.onresult = (event) => {
        var speechToText = event.results[0][0].transcript;
        var found = false;
        if (speechToText.includes("go") ||speechToText.includes("go to") || speechToText.includes("goto") || speechToText.includes("2 ")) {
            
            if (speechToText.includes("nutrition")) {
                $("#fitpiCarousel").carousel(1);
                found = true;
            }

            if (speechToText.includes("activity")) {
                $("#fitpiCarousel").carousel(0);
                found = true;
            }

            if (speechToText.includes("budget")) {
                $("#fitpiCarousel").carousel(2);
                found = true;
            }

            if (speechToText.includes("timetable")) {
                $("#fitpiCarousel").carousel(3);
                found = true;
            }

            if (speechToText.includes("worklog") || speechToText.includes("work log") || speechToText.includes("log")) {
                $("#fitpiCarousel").carousel(4);
                found = true;
            }

            if (speechToText.includes("weather")) {
                $("#fitpiCarousel").carousel(5);
                found = true;
            }


            if (speechToText.includes("calories")) {
                $("#fitpiCarousel").carousel(0);
                $(".calories-control").click();
                found = true;
            }

            if (speechToText.includes("minutes")) {
                $("#fitpiCarousel").carousel(0);
                $(".minutes-control").click();
                found = true;
            }

            if (speechToText.includes("distance")) {
                $("#fitpiCarousel").carousel(0);
                $(".distance-control").click();
                found = true;
            }

            if (speechToText.includes("steps")) {
                $("#fitpiCarousel").carousel(0);
                $(".steps-control").click();
                found = true;
            }

            if (speechToText.includes("Floors")) {
                $("#fitpiCarousel").carousel(0);
                $(".floors-control").click();
                found = true;
            }

            if (speechToText.includes("weight")) {
                $("#fitpiCarousel").carousel(0);
                $(".weight-control").click();
                found = true;
            }

            if (speechToText.includes("heart rate")) {
                $("#fitpiCarousel").carousel(0);
                $(".heartRate-control").click();
                found = true;
            }

           
        } else {
            if (speechToText.includes("change") ||
                speechToText.includes("modify") ||
                speechToText.includes("edit") ||
                speechToText.includes("record")) {
                var numbers = speechToText.match(/\d+/g).map(Number);
                var selector = "input[name*='[" + numbers[0] + "]'";
                $(selector).val(numbers[1]);
                found = true;
            } else  {
                if (speechToText.includes("what") ||
                    speechToText.includes("are") ||
                    speechToText.includes("my")) {
                    var speakMessage;
                    if (speechToText.includes("calories")) {
                        found = true;
                        speakMessage = "Your logged " + $(".calories-control").val() + "calories today";
                    }

                    if (speechToText.includes("minutes")) {
                        found = true;
                        speakMessage = "Your logged " + $(".minutes-control").val() + "active minutes today";
                    }

                    if (speechToText.includes("distance")) {
                        found = true;
                        speakMessage = "Your logged " + $(".distance-control").val() + "kilometers today";
                    }

                    if (speechToText.includes("steps")) {
                        speakMessage = "Your logged " + $(".steps-control").val() + "steps today";
                        found = true;
                    }

                    if (speechToText.includes("Floors")) {
                        speakMessage = "Your logged " + $(".floors-control").val() + "floors today";
                        found = true;
                    }

                    if (speechToText.includes("weight")) {
                        speakMessage = "Your logged " + $(".weight-control").val() + "weight today";
                        found = true;
                    }

                    if (speechToText.includes("heart rate")) {
                        speakMessage = "Your logged " + $(".heartRate-control").val() + "beats per minute at rest today";
                        found = true;
                    }

                    if (found) {
                        speakToWindow(speakMessage);
                    }
                }
            }



            if (found === false) {
                speakToWindow("Sorry, i couldn't find what you were looking for");
            }
        }

      
        

        console.log(speechToText);
    };

    recognition.onspeechend = function() {
        recognition.stop();
    };


    $(".fitpi-logo").click(function () {
        recognition.start();
        console.log('Ready to receive a color command.');

    });

    //document.body.onclick = function() {
    //    recognition.start();
    //    console.log('Ready to receive a color command.');
    //};

});