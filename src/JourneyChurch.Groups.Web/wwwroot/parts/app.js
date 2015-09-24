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
app.factory('Alert', function($rootScope) {
    $rootScope.alerts = [];

    var add = function (message) {
        $rootScope.alerts.push({ message: message });
    };

    var clear = function() {
        $rootScope.alerts = [];
    };

    return {
        add: add,
        clear: clear
    };
});

app.factory('AuthorizationRedirectInterceptor', function ($q, $window, Alert) {
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

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('AuthorizationRedirectInterceptor');
});