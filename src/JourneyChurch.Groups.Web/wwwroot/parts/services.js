(function () {
    'use strict';

    var app = angular.module('app');

    app.factory('Group', function ($resource) {
        return $resource('/api/group/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
        );
    });

    app.factory('User', function ($resource) {
        return $resource('/api/users/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
        );
    });

    app.factory('Meeting', function ($resource) {
        return $resource('/api/meeting/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
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
