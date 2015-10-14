angular.module('app').controller('usersController', function ($scope, $location, User) {
	
    $scope.edit = function (l) {
		$location.path('/users/' + l.id);
	};
	
	User.query().$promise.then(function(data) {
		$scope.users = data;
	});
});
