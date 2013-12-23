(function () {
    'use strict';

    function HomePageViewModel() {
        this.countdownTime = ko.observable('14д 17ч 29м 43с');
    }

    HomePageViewModel.prototype = {
        showFirstName: function () {
            alert(this.firstName());
        }
    }

    $(function () {
        ko.applyBindings(new HomePageViewModel(), $("homeFullScreen")[0]);
    })
})();