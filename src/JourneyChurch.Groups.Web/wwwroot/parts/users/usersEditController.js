(function () {
    'use strict';

    angular.module('app').controller('usersEditController', function ($scope, $routeParams, $location, $mdDialog, Toaster, User, UserRPC) {

        $scope.userId = $routeParams.id;
        var edit_mode = $scope.userId !== 0;

        $scope.save = function () {
            $scope.e.$update().then(function() {
                $location.path('/users');
            }, function(err) {
                Toaster.toast(err.statusText);
            });
        };

        $scope.changePassword = function(event) {
            $mdDialog.show({
                controller: 'passwordModalController',
                templateUrl: 'parts/users/passwordModalTemplate.html',
                parent: angular.element(document.body),
                targetEvent: event,
                clickOutsiteToClose: true
            }).then(function(password) {
                if (edit_mode) {
                    UserRPC.updatePassword($scope.e.id, password);
                } else {
                    $scope.e.password = password;
                }
            });
        };

        $scope.is_save_button_disabled = function() {
            return !edit_mode && $scope.e.password === undefined;
        };

        $scope.$watch('e', function(x) { console.log(x); }, true);

        $scope.cancel = function () {
            $location.path('/users');
        };

        if (edit_mode) {
            User.get({ id: $scope.userId }).$promise.then(function (data) {
                $scope.e = data; 
            });
        }
        else {
            $scope.e = new User();
            angular.extend($scope.e,
            {
                id: 0,
                userName: '',
                email: '',
                isAdministrator: false
            });
        }
    });
})();

