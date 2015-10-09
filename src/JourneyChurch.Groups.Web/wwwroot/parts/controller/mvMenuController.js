angular.module('app').controller('mvMenuController', function($scope, $location) {
	
	// used to add active class on top menu bar
	$scope.isActive = function(path) {
		return $location.path().indexOf(path) > -1;	
	};
	
});