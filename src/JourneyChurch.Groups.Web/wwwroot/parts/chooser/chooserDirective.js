(function () {
    'use strict';
    angular.module('app').directive('chooser', function () {
        return {
            scope: {
                all: '=',
                selectedIds: '=', // the ids from the objects in all that are selected
                leftTitle: '@',
                rightTitle: '@'
            },
            templateUrl: 'parts/chooser/chooserTemplate.html',
            controller: 'chooserController'
        };
    });

})();