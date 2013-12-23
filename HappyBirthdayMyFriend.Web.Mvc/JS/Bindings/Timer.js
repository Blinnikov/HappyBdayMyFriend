ko.bindingHandlers.timer = {

    update: function (element, valueAccessor) {
        var seconds = valueAccessor();
        var formatTime = function (seconds) {
            var result = "";
            // get the days between now and then    
            var days = parseInt(seconds / (60 * 60 * 24));
            if (days > 0) {
                result += days + ' д ';
            }
            seconds -= (days * 60 * 60 * 24);
            // get hours    
            var hours = parseInt(seconds / (60 * 60));
            if (hours > 0 || (hours == 0 && result != "")) {
                result += hours + ' ч ';
            }
            seconds -= (hours * 60 * 60);
            // get minutes    
            var minutes = parseInt(seconds / (60));
            if (minutes > 0 || (minutes == 0 && result != "")) {
                result += minutes + ' м ';
            }
            seconds -= (minutes * 60);
            result += seconds + ' с';
            return result;
        }

        var timer = setInterval(function () {
            $(element).text(formatTime(--seconds));
            if (seconds == 0) {
                clearInterval(timer);
            }
        }, 1000);
    }
};