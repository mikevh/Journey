(function () {
    'use strict';

    angular.module('app').controller('meetingsController', function ($scope, $routeParams, $location, Group, Meeting, MeetingRPC) {
        if ($routeParams.id === undefined) {
            $location.path('/');
            return;
        }

        $scope.groupId = $routeParams.id;

        $scope.save = function() {
            var e = new Meeting();
            angular.extend(e, {
                groupId: $routeParams.id,
                notes: $scope.e.notes,
                attendance: $scope.e.attendance 
            });
            e.$save().then(function(data) {
                $location.path('/');
            });
        };
    
        $scope.loadGroup = function(id) {
            Group.get({ id: id }).$promise.then(function (data) {
                $scope.group = data;
            });
        };

        $scope.loadPreviosReportsForGroup = function(id) {
            MeetingRPC.getPrevousReportsForGroup(id).then(function(data) {
               console.log(data);
               $scope.reports = data; 
            });
        };

        $scope.cancel = function() {
            $location.path('/');
        };
    
        $scope.loadGroup($scope.groupId);
        $scope.loadPreviosReportsForGroup($scope.groupId);
    });
})();