﻿angular.module('app', ['ngRoute', 'ngResource']);

angular.module('app').config(function($routeProvider) {
    var routes = [
        { url: '/groups', config: { template: '<mv-groups></mv-groups>' } },
        { url: '/users', config: { template: '<users></users>'} },
        { url: '/groups/:id', config: { templateUrl: 'parts/groups/groupsEditTemplate.html', controller: 'groupsEditController' } },
        { url: '/users/:id', config: { templateUrl: 'parts/users/usersEditTemplate.html', controller: 'usersEditController' } }
    ];
    _.each(routes, function (x) { $routeProvider.when(x.url, x.config); });
    $routeProvider.otherwise({ redirectTo: '/groups' });
});

// angular.module('app').factory('Todo', function ($resource) {
//     return $resource('/api/todo/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
//     );
// });

angular.module('app').factory('Group', function ($resource) {
    return $resource('/api/group/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
    );
});

angular.module('app').factory('User', function ($resource) {
    return $resource('/api/users/:id', { id: '@id' }, { 'update': { method: 'PUT' } }
    );
});

angular.module('app').factory('AuthorizationRedirectInterceptor', function ($q, $window, Alert) {
    return {
        responseError: function (responseError) {
            //if (responseError.status === 401) { // authentication issue
            //    $window.location = "/login?redirectUrl=" + encodeURIComponent(document.URL);
            //    return null;
            //}
            if (responseError.status === 404) {
                Alert.add("Error 404: " + responseError.config.method + " " + responseError.config.url);
            }
            return $q.reject(responseError);
        }
    };
});

angular.module('app').config(function ($httpProvider) {
    $httpProvider.interceptors.push('AuthorizationRedirectInterceptor');
});