var P3ImageApp = angular.module('P3ImageApp', ["ngRoute"]);

var $routeProviderReference;

P3ImageApp.config(function ($routeProvider, $locationProvider) {
    $routeProviderReference = $routeProvider
    $locationProvider.html5Mode(true);
});

P3ImageApp.run(['$route', '$http', '$rootScope', function ($route, $http, $rootScope) {
    $routeProviderReference
        .when("/", {
            templateUrl: "App/Views/public-area.htm",
            controller: "PublicAreaController"
        })
        .when("/private", {
            templateUrl: "App/Views/private-area.htm",
            controller: "PrivateAreaController"
        });
    
    $route.reload()
}]);

//P3ImageApp.config(function ($routeProvider, $locationProvider) {
//    $routeProviderReference = $routeProvider;
//    $routeProviderReference
//    .when("/", {
//        templateUrl: "App/Views/public-area.htm",
//        controller: "PublicAreaController"
//    })
//    .when("/private", {
//        templateUrl: "App/Views/private-area.htm",
//        controller: "PrivateAreaController"
//    });

//    $locationProvider.html5Mode(true);
//});