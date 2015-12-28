(function () {
    'use strict';

    angular.module('app').factory('UserRPC', function($http) {
        var updatePassword = function(id, password) {
            return $http.put('/api/users/updatepassword/' + id, { password: password }).then(function(data) {
                return data;
            });
        };

        return {
            updatePassword: updatePassword
        };
    });
})();
