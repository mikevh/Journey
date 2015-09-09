﻿(function(module) {


    module.factory('ResourceGenerator', ['$resource', function ($resource) {
        var get_resource = function (url) {
            var res = $resource(url, null, {
                'update': { method: 'PUT' },
                'insert': { method: 'POST' },
                //'updatevalidate': { method: 'PUT', headers: { 'validation_only': 'true' } },
                //'insertvalidate': { method: 'POST', headers: { 'validation_only': 'true' } }
            });
            return {
                query: function () {
                    return res.query().$promise;
                },
                get: function (id) {
                    return res.get({ id: id }).$promise;
                },
                insert: function (data) {
                    return res.insert(data).$promise;
                },
                //insertvalidate: function (data) {
                //    return res.insertvalidate(data).$promise;
                //},
                del: function (data) {
                    return res.delete(data).$promise;
                },
                update: function (data) {
                    return res.update(data).$promise;
                },
                //updatevalidate: function (data) {
                //    return res.updatevalidate(data).$promise;
                //}
            };
        };
        return {
            GetResource: get_resource
        };
    }]);


}(angular.module('app')));
