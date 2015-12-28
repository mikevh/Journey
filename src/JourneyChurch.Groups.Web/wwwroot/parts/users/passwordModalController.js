(function () {
    'use strict';

    angular.module('app').controller('passwordModalController', function ($scope, $mdDialog) {


        $scope.okIsDisabled = function () {
            return $scope.password === undefined ||
                $scope.confirmPassword === undefined ||
                $scope.password !== $scope.confirmPassword;
        };

        $scope.modalOk = function () {
            $mdDialog.hide($scope.password);
        };

        $scope.modalCancel = function () {
            $mdDialog.cancel();
        };

        $scope.hide = function() {
            $scope.modalCancel();
        };
    });
})();