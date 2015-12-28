(function () {
    'use strict';

    angular.module('app').directive('mvMenu', function () {
        return {
            restrict: 'E',
            templateUrl: 'parts/menu/menuTemplate.html',
            controller: function($scope, $mdSidenav) {
                $scope.toggleSidenav = function (menuId) {
                    $mdSidenav(menuId).toggle(); 
                };  
            }
        };
    });
})();
