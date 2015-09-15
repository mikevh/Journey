angular.module('app', ['ngRoute', 'ngResource']);

angular.module('app').config(function($routeProvider) {
    var routes = [
        { url: '/dashboard', config: { template: '<mv-groups></mv-groups>' } },
        { url: '/group/:id', config: { templateUrl: 'parts/template/groupsEditTemplate.html', controller: 'groupsEditController' } }
    ];
    _.each(routes, function (x) { $routeProvider.when(x.url, x.config); });
    $routeProvider.otherwise({ redirectTo: '/dashboard' });
});

angular.module('app').factory('Todo', function ($resource) {
    return $resource('/api/todo/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
    );
});

angular.module('app').factory('Group', function ($resource) {
    return $resource('/api/group/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
    );
});
