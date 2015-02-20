// Create the module and define its dependencies.
var app = angular.module('blog', [
    'ui.router',
    'restangular'
]);

app.config(function ($stateProvider, $urlRouterProvider) {
    var viewBaseUrl = "/app/views/";
    $urlRouterProvider.otherwise('/home');

    $stateProvider.state('home', {
        url: '/home',
        templateUrl: viewBaseUrl + 'home.html',
        controller : 'PostCtrl'
    }).state('about', {});
});

// Execute bootstrapping code and any dependencies.
app.run([
    '$q', '$rootScope', function ($q, $rootScope) {
    }]);
