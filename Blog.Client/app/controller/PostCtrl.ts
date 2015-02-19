// Update the reference to app1.ts to be that of your module file.
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the .d.ts reference paths,
// then adjust the path value to be relative to this file

/// <reference path="../../scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

interface IPostCtrlScope extends ng.IScope {
    greeting: string;
    changeGreeting: () => void;
}

interface IPostCtrl {
    controllerId: string;
}

class PostCtrl implements IPostCtrl {
    static controllerId: string = "PostCtrl";
    
    constructor(private $scope: IPostCtrlScope, private $http: ng.IHttpService, private $resource: ng.resource.IResourceService) {
        $scope.greeting = "Hello";
        $scope.changeGreeting = () => this.changeGreeting();
    }

    private changeGreeting() {
        this.$scope.greeting = "Bye";
    }
}

// Update the app1 variable name to be that of your module variable
app1.controller(PostCtrl.controllerId, ['$scope', '$http', '$resource', ($scope, $http, $resource) =>
    new PostCtrl($scope, $http, $resource)
]);
