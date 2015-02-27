app.config(function ($stateProvider, $urlRouterProvider) {
    var viewBaseUrl = "/app/views/";
    $urlRouterProvider.otherwise('/posts');

    $stateProvider
        .state('posts', {
            url: '/posts',
            templateUrl: viewBaseUrl + 'posts/home.html',
            controller: 'PostCtrl'
        })
        .state('addPost', {
            url: '/posts/create',
            templateUrl: viewBaseUrl + 'posts/create.html',
            controller : 'PostCtrl'
        });
});