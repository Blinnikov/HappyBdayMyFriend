(function () {
    'use strict';

    function HomePageViewModel() {
        this.flag = ko.observable(false);
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