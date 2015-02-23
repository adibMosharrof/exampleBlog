(function () {
    'use strict';

    angular
        .module('blog')
        .factory('PostService', PostService);

    PostService.$inject = ['breeze', '$q'];

    function PostService(breeze, $q) {
        //this.$http = $http;
        var _this = this;
        var service = {
            getData: getData,
            getPosts: getPosts
        };

        return service;

        function getData() { }

        function getPosts() {
            //return _this.$http.get('http://localhost:5326/Posts?$orderby=Id desc');
            //return _this.$http.get('http://localhost/BlogApi/Posts');
            //debugger;
            var dataService = new breeze.DataService({
                serviceName: 'http://localhost/BlogApi/'
                //serviceName: 'http://localhost/BlogApi/',
                //hasServerMetadata: false
            });
            breeze.NamingConvention.camelCase.setAsDefault();

            breeze.config.initializeAdapterInstance('dataService', 'webApiOData', true);
            var manager = new breeze.EntityManager({ dataService :dataService});
            var query = breeze.EntityQuery.from("Posts").take(5).expand("comments");
            //var query = breeze.EntityQuery.from("Posts").take(5);
            var promise = manager.executeQuery(query).catch(queryFailed);
            return promise;
    }

    function queryFailed(error) {
        //logger.error(error.message, "Query failed");
        alert('query failed');
        return $q.reject(error); // so downstream promise users know it failed
    }
}
})();