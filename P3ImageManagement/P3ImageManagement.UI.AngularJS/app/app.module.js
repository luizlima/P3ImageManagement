var P3ImageApp = angular.module('P3ImageApp', ["ngRoute"]);

var $routeProviderReference;

P3ImageApp.config(function ($routeProvider, $locationProvider) {
    $routeProviderReference = $routeProvider;
    $routeProviderReference.eagerInstantiationEnabled(false);
    $locationProvider.html5Mode(true);
});

P3ImageApp.run(['$route', '$http', '$rootScope', function ($route, $http, $rootScope) {

    //$http({
    //    method: "GET",
    //    url: "/api/p3route"
    //}).then(function mySuccess(response) {
    //    $rootScope.routes = response.data;
    //}, function myError(response) {
    //    $rootScope.error = response.statusText;
    //});

    $.ajax({
        method: "GET",
        url: "/api/p3route",
        async: false
    })
     .done(function (response) {
         $rootScope.routes = response;
     });

    $routeProviderReference
        .when("/", {
            templateUrl: "/App/Views/public-area.htm",
            controller: "PublicAreaController"
        })
        .when("/private", {
            templateUrl: "App/Views/private-area.htm",
            controller: "PrivateAreaController"
        });

    if ($rootScope.routes != null && $rootScope.routes.length > 0) {
        for (var i = 0; i < $rootScope.routes.length; i++) {
            var route = $rootScope.routes[0];

            $routeProviderReference.when(route.path, {
                templateUrl: route.templateUrl,
                controller: route.controller
            });
        }
    }
    
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