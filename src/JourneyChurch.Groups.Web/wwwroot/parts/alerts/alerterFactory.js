angular.module('app').factory('Alerter', function($rootScope) {
    $rootScope.alerts = [];

    var add = function (message) {
        $rootScope.alerts.push({ message: message });
    };

    var clear = function() {
        $rootScope.alerts = [];
    };

    return {
        add: add,
        clear: clear
    };
});
