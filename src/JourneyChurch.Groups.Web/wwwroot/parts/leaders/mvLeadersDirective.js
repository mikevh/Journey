angular.module('app').directive('mvLeaders', function () {
    return {
        templateUrl: 'parts/leaders/leadersTemplate.html',
        controller: 'leadersController'
    };
});
