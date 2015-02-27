(function () {
    'use strict';

    angular
        .module('blog')
        .factory('PostService', PostService);

    PostService.$inject = ['breeze', '$q', 'errorLogger', 'entityManagerFactory', 'breezeSaveChangesFactory'];

    function PostService(breeze, $q, errorLogger, emFactory, breezeSaveChangesFactory) {
        var saveChangesFactory = breezeSaveChangesFactory;
        var service = {
            getData: getData,
            getPosts: getPosts,
            getPostsForGrid: getPostsForGrid,
            getPostWithComments: getPostWithComments,
            create: create
        };
        var manager = emFactory.newManager();
        return service;

        function getData() { }

        function getPosts() {
            var query = breeze.EntityQuery.from("Posts").take(5);
            var promise = manager.executeQuery(query).catch(errorLogger.logError);
            return promise;
        }

        function getPostsForGrid(pageSize, page, searchText) {
            var query = breeze.EntityQuery.from("Posts").skip((page - 1) * pageSize).take(pageSize).inlineCount();
            var promise = manager.executeQuery(query).catch(errorLogger.logError);
            return promise;
        }

        function getPostWithComments(postId) {
            var query = breeze.EntityQuery.from("Posts").where('id', 'eq', 3).expand("comments");
            var promise = manager.executeQuery(query).catch(errorLogger.logError);
            return promise;
        }

        function create(post) {
            var newPost = manager.createEntity('Post', post);
            debugger;
            saveChangesFactory.saveChanges(manager);
            return newPost;
        }
    }
})();