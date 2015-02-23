(function () {
    'use strict';

    angular
        .module('blog')
        .controller('PostCtrl', PostCtrl);

    PostCtrl.$inject = ['$location', 'PostService']; 

    function PostCtrl($location, PostService) {
        /* jshint validthis:true */
        var vm = this;
        //var _this = this;
        vm.title = 'PostCtrl';
        getPosts();
        activate();

        function getPosts() {
            var postRequest = PostService.getPosts();
            //var postRequest = _this.$http.get('http://localhost:5326/Posts');
            //postRequest.success(function(data) {
            //    debugger;

            //});

            postRequest.then(function(data) {
                alert('breeze success');
            });
        }

        function activate() { }
    }
})();
