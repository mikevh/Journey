angular.module('app', ['ngRoute', 'ngResource']);

angular.module('app').factory('Todo', function ($resource) {
    return $resource('/api/todo/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
    );
});
