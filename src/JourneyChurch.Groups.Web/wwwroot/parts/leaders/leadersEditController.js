angular.module('app').controller('leadersEditController', function ($scope, $routeParams, $location, User) {
    
    $scope.leaderId = $routeParams.id;

    $scope.save = function() {
        $scope.e.$update().then(function() {
            $location.path('/leaders');
        });
    };

    $scope.cancel = function () {
        $location.path('/leaders');
    };

    if ($scope.leaderId !== 0) {
        User.get({ id: $scope.leaderId }).$promise.then(function (data) {
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
