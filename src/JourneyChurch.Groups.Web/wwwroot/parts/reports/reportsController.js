(function() {
    'use strict';

    angular.module('app').controller('reportController', function($scope, $routeParams, $location, ReportData, GroupData) {

        GroupData.resource.get({ id: $routeParams.groupId }).$promise.then(function (data) {
            $scope.group = data;
        });

        $scope.save = function () {
            var e = new ReportData();
            angular.extend(e, {
                id: 0,
                groupId: $routeParams.groupId,
                notes: $scope.e.notes,
                attendees: [{ name: 'foo' }, { name: 'bar' }],
                date: $scope.e.date
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