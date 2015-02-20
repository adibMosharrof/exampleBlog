(function () {
    'use strict';

    angular
        .module('blog')
        .factory('PostService', PostService);

    PostService.$inject = ['Restangular'];

    function PostService(Restangular) {
        this.$http = $http;
        var _this = this;
        var service = {
            getData: getData,
            getPosts: getPosts
        };

        return service;

        function getData() { }

        function getPosts() {
             //return _this.$http.get('http://localhost:5326/Posts?$orderby=Id desc');
             return _this.$http.get('http://localhost/BlogApi/Posts');
        }
    }
})();