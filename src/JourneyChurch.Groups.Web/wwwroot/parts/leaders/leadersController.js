angular.module('app').controller('leadersController', function ($scope, $location, User) {
	
	$scope.edit = function(l) {
		$location.path('#/leaders/' + l.id);
	};
	
	User.query().$promise.then(function(data) {
		$scope.leaders = data;
	});
});
