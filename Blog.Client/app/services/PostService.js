(function () {
    'use strict';

    angular
        .module('blog')
        .factory('PostService', PostService);

    PostService.$inject = ['breeze', '$q', 'errorLogger', 'entityManagerFactory'];

    function PostService(breeze, $q, errorLogger, emFactory) {
        var service = {
            getData: getData,
            getPosts: getPosts,
            getPostsWithComments: getPostsWithComments
        };
        var manager = emFactory.newManager(); 
        return service;

        function getData() { }

        function getPosts() {
            var query = breeze.EntityQuery.from("Posts").take(5);
            var promise = manager.executeQuery(query).catch(errorLogger.logError);
            return promise;
        }

            return promise;
    }

        function getPostsWithComments() {
            var query = breeze.EntityQuery.from("Posts").take(5).expand("comments");
            var promise = manager.executeQuery(query).catch(errorLogger.logError);
            return promise;
        }
}
})();