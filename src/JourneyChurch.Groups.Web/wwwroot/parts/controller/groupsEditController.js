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

    if($scope.groupId > 0) {
        Group.get({ id: $scope.groupId }).$promise.then(function (data) {
            $scope.e = data;
        });
    }        
    else {
        $scope.e = new Group();
        angular.extend($scope.e, 
        {
            id: 0,
            name: 's',
            leader: 'sd',
            meetsOn: 4,
            notes: 'ff'
        });
    }
});
