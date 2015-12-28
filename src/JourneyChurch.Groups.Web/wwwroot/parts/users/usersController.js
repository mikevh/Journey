(function () {
    'use strict';

    angular.module('app').controller('usersController', function ($scope, $location, User) {
	
        $scope.edit = function (l) {
		    $location.path('/users/' + l.id);
        };

        $scope.new = function() {
            $location.path('/users/0');
        };
	
	    User.query().$promise.then(function(data) {
		    $scope.users = data;
	    });
    });
})();

