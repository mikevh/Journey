angular.module('app').controller('groupsController', function ($scope, Group) {

    $scope.saveNew = function () {
        var entry = new Group();
        angular.extend(entry, $scope.n);
        entry.$save().then(function (data) {
            $scope.groups.push(data);
            $scope.cancelNew();
        });
    };

    $scope.cancelNew = function () {
        $scope.showNew = false;
    };

    $scope.add = function () {
        $scope.n = {
            name: '',
            leader: ''
        };
        $scope.showNew = true;
    };

    $scope.remove = function (g) {
        g.$delete().then(function () {
            var index = $scope.groups.indexOf(g);
            $scope.groups.splice(index, 1);
        });
    }

    console.log('g');
    Group.query().$promise.then(function (data) {
        $scope.groups = data;
    });

});
