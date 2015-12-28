(function() {
    'use strict';
    angular.module('app').controller('chooserController', function ($scope, $timeout) {

	    $scope.add = function () {
		    var ids = _.pluck($scope.leftSelected, 'id');
		    $scope.selectedIds = $scope.selectedIds.concat(ids);
		    $scope.leftSelected = [];
	    };

	    $scope.remove = function () {
		    var ids = _.pluck($scope.rightSelected, 'id');
		    $scope.selectedIds = _.difference($scope.selectedIds, ids);
		    $scope.rightSelected = [];
	    };

	    $scope.$watch('selectedIds', function () {
		    $scope.left = _.filter($scope.all, function (x) {
			    var index = $scope.selectedIds.indexOf(x.id);
			    return index === -1;
		    });

		    $scope.right = _.filter($scope.all, function (x) {
			    var index = $scope.selectedIds.indexOf(x.id);
			    return index > -1;
		    })
	    });
    });
})();
