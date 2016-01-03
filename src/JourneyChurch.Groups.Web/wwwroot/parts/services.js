(function () {
    'use strict';

    var app = angular.module('app');

    app.factory('GroupData', function ($resource, $http) {

        var resource = $resource('/api/group/:id', { id: '@id' }, { 'update': { method: 'PUT' } } );

        var latestReports = function() {
            return $http.get('/api/group/getLatestReports').then(function(result) {
                return result;
            });
        };

        return {
            resource: resource,
            latestReports: latestReports
        };
    });

    app.factory('User', function ($resource) {
        return $resource('/api/users/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
        );
    });

    app.factory('Meeting', function ($resource) {
        return $resource('/api/meeting/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
        );
    });

    app.factory('ReportData', function($resource) {
        return $resource('/api/report/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
        );
    });

    app.factory('Toaster', function ($mdToast) {
        var toast = function (message, time) {
            $mdToast.show(
              $mdToast.simple().textContent(message)
                .position('top right')
                .hideDelay(time || 3000)
            );
        };
        return {
            toast: toast
        };
    });

})();
