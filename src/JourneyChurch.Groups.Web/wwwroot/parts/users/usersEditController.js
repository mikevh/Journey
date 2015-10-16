angular.module('app').controller('usersEditController', function($scope, $routeParams, $location, $uibModal, Alerter, User) {

    $scope.userId = $routeParams.id;

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
            $scope.e.resetPassword = password;
        });
    };

    $scope.saveNew = function() {
        var x = new User();
        x.userName = 'admin2';
        x.email = 'foo@bar.com';
        x.resetPassword = 'Pass@word2';
        x.$save().then(function(data) {
            debugger;
        }, function(err) {
            deugger;
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
