(function () {
    'use strict';

    angular.module('blog')
         .factory('entityManagerFactory', ['breeze', emFactory]);

    function emFactory(breeze) {
        // Convert properties between server-side PascalCase and client-side camelCase
        breeze.NamingConvention.camelCase.setAsDefault();
        breeze.config.initializeAdapterInstance('dataService', 'webApiOData', true);
        // Identify the endpoint for the remote data service
        var serviceRoot = window.location.protocol + '//' + window.location.host + '/';
        //var serviceName = serviceRoot + 'breeze/breeze'; // breeze Web API controller
        var serviceName ="localhost/BlogApi/"; // breeze Web API controller

        // the "factory" services exposes two members
        var factory = {
            newManager: function () { return new breeze.EntityManager(serviceName); },
            serviceName: serviceName
        };

        return factory;
    }
})();