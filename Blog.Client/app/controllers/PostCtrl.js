(function () {
    'use strict';

    angular
        .module('blog')
        .controller('PostCtrl', PostCtrl);

    PostCtrl.$inject = ['$scope', '$location', 'PostService', 'errorLogger'];

    function PostCtrl($scope, $location, PostService, errorLogger) {
        $scope.title = 'PostCtrl';
        $scope.formInfo = {};
        init();
        //getPosts();

        function getPosts() {
            var postRequest = PostService.getPosts();


            postRequest.then(function (data) {
                $scope.posts = data.results;
            });
        }

        function init() {
            configureNgGrid();
            $scope.create = create;
        }


        function create(isValid) {
            if (isValid) {
                var newPost = PostService.create($scope.newPost);
                $scope.posts.unshift(newPost);
                $scope.newPost = '';
            }
        }

        function configureNgGrid() {
            $scope.filterOptions = {
                filterText: "",
                useExternalFilter: false
            };
            $scope.totalServerItems = 0;
            $scope.pagingOptions = {
                pageSizes: [10, 20, 50, 100, 250, 500, 1000],
                pageSize: 20,
                currentPage: 1
            };


            $scope.$watch('pagingOptions', function (newVal, oldVal) {
                if (newVal.currentPage !== oldVal.currentPage || newVal.pageSize !== oldVal.pageSize) {
                    getPagedData();
                }
            }, true);
            $scope.$watch('filterOptions', function (newVal, oldVal) {
                if (newVal !== oldVal) {
                    getPagedData();
                }
            }, true);

            $scope.gridOptions = {
                data: 'posts',
                enablePaging: true,
                showFooter: true,
                showFilter: true,
                totalServerItems: 'totalServerItems',
                pagingOptions: $scope.pagingOptions,
                filterOptions: $scope.filterOptions,
                columnDefs: [
                { field: 'id', displayName: "ID" }, { field: 'title', displayName: 'Title' }, { field: 'status', displayName: 'Status' }]
            };
            getPagedData();
        }

        function getPagedData() {
            var pageSize = $scope.pagingOptions.pageSize;
            var page = $scope.pagingOptions.currentPage;
            var promise = PostService.getPostsForGrid(pageSize, page, $scope.filterOptions.filterText);
            promise.then(function (data) {
                $scope.posts = data.results;
                $scope.totalServerItems = data.inlineCount;
            }, errorLogger.logError);
        }
    }
})();
