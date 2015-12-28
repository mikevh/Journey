(function () {
    'use strict';

    angular.module('app').factory('MeetingRPC', function($http) {
        var getPrevousReportsForGroup = function(id, password) {
            return $http.get('/api/meeting/getPrevousReportsForGroup/' + id).then(function(result) {
                return result.data;
            });
        };

        return {
            getPrevousReportsForGroup: getPrevousReportsForGroup
        };
    });
})();