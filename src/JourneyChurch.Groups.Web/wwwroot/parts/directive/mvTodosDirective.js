angular.module('app').directive('mvTodos', function () {
    return {
        templateUrl: 'parts/template/todosTemplate.html',
        controller: 'todoController'
    };
});
