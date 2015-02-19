// Update the reference to app1.ts to be that of your module file.
// Install the angularjs.TypeScript.DefinitelyTyped NuGet package to resolve the .d.ts reference paths,
// then adjust the path value to be relative to this file
/// <reference path="../../scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

var PostCtrl = (function () {
    function PostCtrl($scope, $http, $resource) {
        var _this = this;
        this.$scope = $scope;
        this.$http = $http;
        this.$resource = $resource;
        $scope.greeting = "Hello";
        $scope.changeGreeting = function () {
            return _this.changeGreeting();
        };
    }
    PostCtrl.prototype.changeGreeting = function () {
        this.$scope.greeting = "Bye";
    };
    PostCtrl.controllerId = "PostCtrl";
    return PostCtrl;
})();

// Update the app1 variable name to be that of your module variable
app.controller(PostCtrl.controllerId, [
    '$scope', '$http', '$resource', function ($scope, $http, $resource) {
        return new PostCtrl($scope, $http, $resource);
    }
]);
//# sourceMappingURL=PostCtrl.js.map
