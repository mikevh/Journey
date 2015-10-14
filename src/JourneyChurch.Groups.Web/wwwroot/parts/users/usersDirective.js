angular.module('app').directive('users', function () {
    return {
        templateUrl: 'parts/users/usersTemplate.html',
        controller: 'usersController'
    };
});
