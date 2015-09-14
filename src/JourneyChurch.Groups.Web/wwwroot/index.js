var app = angular.module('app', ['ngRoute', 'ngResource']);

app.factory('Todo', function ($resource) {
    return $resource('/api/todo/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
    );
});


app.controller('ctrl', function ($scope, Todo) {

    $scope.saveNew = function () {
        var entry = new Todo();
        angular.extend(entry, $scope.n);
        entry.$save().then(function (data) {
            $scope.todos.push(data);
            $scope.cancelNew();
        });
    };

    $scope.cancelNew = function () {
        $scope.showNewTodo = false;
    };

    $scope.saveEdit = function (t) {
        t.$update().then(function () {
            t.isEditing = false;
        });
    };

    $scope.cancelEdit = function (t) {
        t.title = t.previousTitle;
        t.isEditing = false;
    };

    $scope.openEdit = function (t) {
        t.previousTitle = t.title;
        t.isEditing = true;
    };

    $scope.add = function () {
        $scope.n = { title: '' };
        $scope.showNewTodo = true;
    };

    $scope.remove = function (t) {
        t.$delete().then(function () {
            var index = $scope.todos.indexOf(t);
            $scope.todos.splice(index, 1);
        });
    }

    $scope.toggleDone = function (t) {
        t.isDone = !t.isDone;
        t.$update();
    }

    Todo.query().$promise.then(function (data) {
        $scope.todos = data;
    });
});