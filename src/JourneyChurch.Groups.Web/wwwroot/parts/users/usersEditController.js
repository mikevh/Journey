angular.module('app').controller('usersEditController', function ($scope, $routeParams, $location, User) {
    
    $scope.userId = $routeParams.id;

    $scope.save = function() {
        $scope.e.$update().then(function() {
            $location.path('/users');
        });
    };

    $scope.cancel = function () {
        $location.path('/users');
    };

    if ($scope.userId !== 0) {
        User.get({ id: $scope.userId }).$promise.then(function (data) {
            $scope.e = data;
        });
    }
    else {
        console.log('not implemented');
        $scope.e = new User();
        angular.extend($scope.e,
        {
            id: 0,
            name: 's',
            leader: 'sd' 
        });
    }
});
