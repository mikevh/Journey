angular.module('app').controller('passwordModalController', function ($scope, $modalInstance) {

    $scope.okIsDisabled = function () {
        return $scope.password === undefined ||
            $scope.confirmPassword === undefined ||
            $scope.password !== $scope.confirmPassword;
    };

    $scope.modalOk = function () {
        $modalInstance.close($scope.password);
    };

    $scope.modalCancel = function () {
        $modalInstance.dismiss('cancel');
    };
});