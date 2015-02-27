(function () {
    'use strict';

    angular.module('blog')
         .factory('entityManagerFactory', ['breeze', emFactory]);

    function emFactory(breeze) {
        configureBreeze();
        var serviceName = "http://localhost/BlogApi";
        var factory = {
            newManager: newManager,
            serviceName: serviceName
        };

        return factory;

        function configureBreeze() {
            // use Web API OData to query and save
            breeze.config.initializeAdapterInstance('dataService', 'webApiOData', true);

            // convert between server-side PascalCase and client-side camelCase
            breeze.NamingConvention.camelCase.setAsDefault();
        }

        function newManager() {
            var mgr = new breeze.EntityManager(serviceName);
            return mgr;
        }
    }

})();