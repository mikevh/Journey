angular.module('app').controller('groupsEditController', function ($scope, $locale, $routeParams, $location, Group) {

    $scope.groupId = $routeParams.id;

    $scope.daysOfWeek = _.map($locale.DATETIME_FORMATS.DAY, function (x, i) {
        return { Id: i, Name: x };
    });

    $scope.save = function () {
         $scope.e.$update().then(function() {
            $location.path('/');
        });
    };

    $scope.cancel = function () {
        $location.path('/');
    };

    Group.get({ id: $scope.groupId }).$promise.then(function (data) {
        $scope.e = data;
    });

});
