angular.module('app').directive('mvTodos', function () {
    return {
        templateUrl: 'parts/todos/todosTemplate.html',
        controller: 'todoController'
    };
});
