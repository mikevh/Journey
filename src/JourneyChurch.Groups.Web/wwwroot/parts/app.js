angular.module('app', ['ngRoute', 'ngResource']);

angular.module('app').factory('Todo', function ($resource) {
    return $resource('/api/todo/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
    );
});

angular.module('app').factory('Group', function ($resource) {
    return $resource('/api/group/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
    );
});
