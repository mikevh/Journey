(function () {
    'use strict';
    var app = angular.module('app', ['ngRoute', 'ngResource', 'ngMaterial']);

    app.config(function ($routeProvider) {
        var routes = [
            { url: '/groups', config: { template: '<mv-groups></mv-groups>' } },
            { url: '/users', config: { template: '<users></users>' } },
            { url: '/reports/forgroup/:groupId', config: { templateUrl: '/parts/reports/newReportTemplate.html', controller: 'reportController'} },
            { url: '/reports/:id', config: { templateUrl: '/parts/reports/newReportTemplate.html', controller: 'reportEditController'} },
            //{ url: '/meetings/:id', config: { templateUrl: 'parts/meetings/meetingsTemplate.html', controller: 'meetingsController' } },
            { url: '/groups/:id', config: { templateUrl: 'parts/groups/groupsEditTemplate.html', controller: 'groupsEditController' } },
            { url: '/users/:id', config: { templateUrl: 'parts/users/usersEditTemplate.html', controller: 'usersEditController' } },
            { url: '/login', config: { templateUrl: 'parts/login/loginForm.html', controller: 'loginController' } }
        ];
        _.each(routes, function (x) { $routeProvider.when(x.url, x.config); });
        $routeProvider.otherwise({ redirectTo: '/groups' });
    });

    app.factory('AuthorizationRedirectInterceptor', function ($q, $window, $log) {
        return {
            responseError: function (responseError) {
                //if (responseError.status === 401) { // authentication issue
                //    $window.location = "/login?redirectUrl=" + encodeURIComponent(document.URL);
                //    return null;
                //}
                if (responseError.status === 404) {
                    $log.error("Error 404: " + responseError.config.method + " " + responseError.config.url);
                } else if (responseError.data) {
                    $log.error(responseError.data);
                } else {
                    $log.error("Error status: " + responseError.status);
                }
                return $q.reject(responseError);
            }
        };
    });

    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push('AuthorizationRedirectInterceptor');
    });

    // app.run(function($rootScope, $log) {
    //     $rootScope.$on('$routeChangeStart', function (event, next, current) {
    //        if (next.$$route) {
    //            $log.log('Route change to ' + next.$$route.originalPath);
    //        }
    //        else if (next.redirectTo) {
    //            $log.log('Route change to ' + next.redirectTo);
    //        } else {
    //            debugger;
    //        }
    //     });
    // 
    //     $rootScope.$on('$locationChangeSuccess', function(event, next, current, d, e) {
    //        $log.log('location change from ' + current + ' to ' + next + ' ' + d + ' ' + e);
    //     });
    // });
})();