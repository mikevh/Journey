angular.module('app').controller('usersEditController', function($scope, $routeParams, $location, $uibModal, Alerter, User, UserRPC) {

    if (isNaN($routeParams.id)) {
        Alerter.add("Invalid id: " + $routeParams.id);
        return;
    }
    
    $scope.userId = parseInt($routeParams.id);

    $scope.save = function () {
        $scope.e.$update().then(function() {
            $location.path('/users');
        });
    };

    $scope.changePassword = function() {

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'parts/users/passwordModalTemplate.html',
            controller: 'passwordModalController'
        });

        modalInstance.result.then(function (password) {
            UserRPC.updatePassword($scope.e.id, password);
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
