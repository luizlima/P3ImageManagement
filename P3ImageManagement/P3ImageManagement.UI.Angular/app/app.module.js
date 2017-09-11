var P3ImageApp = angular.module('P3ImageApp', ["ngRoute"]);
P3ImageApp.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "App/Views/public-area.htm",
    })
    .when("/private", {
        templateUrl: "App/Views/private-area.htm",
        controller: "PrivateAreaController"
    });
});