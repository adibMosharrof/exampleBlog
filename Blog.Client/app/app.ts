/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the reference paths,
// then adjust the path value to be relative to this file

interface Iapp extends ng.IModule { }

// Create the module and define its dependencies.
var app: Iapp = angular.module('app', [
    // Angular modules 
    'ngResource',       // $resource for REST queries
    'ngAnimate',        // animations
    'ngRoute'           // routing

    // Custom modules 

    // 3rd Party Modules
]);

// Execute bootstrapping code and any dependencies.
app.run(['$q', '$rootScope', ($q, $rootScope) => {

}]);
