(function () {
    'use strict';

    angular.module('common.services')
        .factory('checkoutResource', ['$resource', 'appSettings', checkoutResource]);

    function checkoutResource($resource, appSettings) {
        return $resource(appSettings.serverPath + 'api/checkouts/');
    }
}());