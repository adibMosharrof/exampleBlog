// Create the module and define its dependencies.
var app = angular.module('blog', [
    'ui.router'
]);

app.config(function ($stateProvider, $urlRouterProvider) {
    var viewBaseUrl = "/app/views/";
    $urlRouterProvider.otherwise('/home');

    $stateProvider.state('home', {
        url: '/home',
        templateUrl: viewBaseUrl+'home.html'
    }).state('about', {});
});

// Execute bootstrapping code and any dependencies.
app.run([
    '$q', '$rootScope', function ($q, $rootScope) {
    }]);
//# sourceMappingURL=app.js.map
