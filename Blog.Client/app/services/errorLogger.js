(function () {
    'use strict';

    angular
        .module('blog')
        .factory('errorLogger', errorLogger);

    errorLogger.$inject = [];

    function errorLogger() {
        var service = {
            logError: logError
        };

        return service;

        function logError(error) {
            //logger.error(error.message, "Query failed");
            alert('query failed');
            return $q.reject(error); // so downstream promise users know it failed
        }
    }
})();