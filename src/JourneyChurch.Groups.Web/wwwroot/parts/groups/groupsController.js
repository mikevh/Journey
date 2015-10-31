angular.module('app').controller('groupsController', function ($scope, $locale, $location, Group) {

    //     $scope.daysOfWeek = _.map($locale.DATETIME_FORMATS.DAY, function (x, i) {
    //         return { Id: i, Name: x };
    //     });
    // 
    //     $scope.dayOfWeekName = function(i) {
    //         return $locale.DATETIME_FORMATS.DAY[i];
    //     };
    //

    $scope.addReport = function (id) {
        $location.path('/meetings/' + id);
    };

    $scope.editGroup = function (g) {
        $location.path('/groups/' + g.id);
    }; 
    
    $scope.newGroup = function () {
        $location.path('/groups/0');
    };
    // 
    //     $scope.saveNew = function () {
    //         var entry = new Group();
    //         angular.extend(entry, $scope.n);
    //         entry.$save().then(function (data) {
    //             $scope.groups.push(data);
    //             $scope.cancelNew();
    //         });
    //     };
    // 
    //     $scope.cancelNew = function () {
    //         $scope.showNew = false;
    //     };
    // 
    //     $scope.add = function () {
    //         $scope.n = {
    //             name: '',
    //             leader: '',
    //             meetsOn: 4,
    //             notes: ''
    //         };
    //         $scope.showNew = true;
    //     };
    // 
    //     $scope.remove = function (g) {
    //         g.$delete().then(function () {
    //             var index = $scope.groups.indexOf(g);
    //             $scope.groups.splice(index, 1);
    //         });
    //     }

    Group.query().$promise.then(function (data) {
        $scope.groups = data;
    });

});
