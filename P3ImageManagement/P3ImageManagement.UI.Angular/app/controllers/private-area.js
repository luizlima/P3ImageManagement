'use strict';
  
P3ImageApp.controller("PrivateAreaController", function ($scope,$routeProvider) {
    $routeProvider
    .when("/private-area/category", {
        templateUrl: "category.htm"
    });
    $scope.Title = "Área privada";
});
