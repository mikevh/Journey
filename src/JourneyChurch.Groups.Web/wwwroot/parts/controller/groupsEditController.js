﻿angular.module('app').controller('groupsEditController', function ($scope, $locale, $routeParams, $location, Group) {

    $scope.groupId = $routeParams.id;

    //$scope.daysOfWeek = _.map($locale.DATETIME_FORMATS.DAY, function (x, i) {
    //    return { Id: i, Name: x };
    //});

    //$scope.dayOfWeekName = function(i) {
    //    return $locale.DATETIME_FORMATS.DAY[i];
    //};

    //$scope.saveNew = function () {
    //    var entry = new Group();
    //    angular.extend(entry, $scope.n);
    //    entry.$save().then(function (data) {
    //        $scope.groups.push(data);
    //        $scope.cancelNew();
    //    });
    //};

    //$scope.cancelNew = function () {
    //    $scope.showNew = false;
    //};

    //$scope.add = function () {
    //    $scope.n = {
    //        name: '',
    //        leader: '',
    //        meetsOn: 4
    //    };
    //    $scope.showNew = true;
    //};

    //$scope.remove = function (g) {
    //    g.$delete().then(function () {
    //        var index = $scope.groups.indexOf(g);
    //        $scope.groups.splice(index, 1);
    //    });
    //}
    console.log($scope.groupId);
    
    Group.get({ id: $scope.groupId }).$promise.then(function (data) {
        $scope.e = data;
    });

});