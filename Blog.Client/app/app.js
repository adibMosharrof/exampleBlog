/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the reference paths,
// then adjust the path value to be relative to this file

// Create the module and define its dependencies.
var app = angular.module('app', [
    'ngResource',
    'ngAnimate',
    'ngRoute'
]);

// Execute bootstrapping code and any dependencies.
app.run([
    '$q', '$rootScope', function ($q, $rootScope) {
    }]);
//# sourceMappingURL=app.js.map
