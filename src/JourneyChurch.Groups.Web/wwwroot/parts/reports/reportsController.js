(function() {
    'use strict';

    angular.module('app').controller('reportController', function($scope, $routeParams, $location, ReportData, GroupData) {

        GroupData.resource.get({ id: $routeParams.groupId }).$promise.then(function (data) {
            console.log(data);
            $scope.group = data;
        });

        $scope.save = function () {
            var e = new ReportData();
            angular.extend(e, {
                groupId: $routeParams.groupOd,
                notes: $scope.e.notes,
                attendees: []
            });
            e.$save().then(function (data) {
                $location.path('/');
            });
        };

        $scope.cancel = function() {
            $location.path('/');
        };

    });

})();