// Create the module and define its dependencies.
var app = angular.module('blog', [
    'ui.router',
    'breeze.angular',
    'ngGrid'
]);

// Execute bootstrapping code and any dependencies.
app.run([
    '$q', '$rootScope', 'breeze',function ($q, $rootScope, breeze) {
    }]);
