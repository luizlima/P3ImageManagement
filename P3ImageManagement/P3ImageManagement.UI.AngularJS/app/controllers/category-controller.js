'use strict';
P3ImageApp.controller("CategoryController", function ($scope, $http, $window) {
    $scope.loadCategories = function () {
        $http({
            method: "GET",
            url: "/api/category"
        }).then(function mySuccess(response) {
            $scope.categories = response.data;
        }, function myError(response) {
            $scope.error = response.statusText;
        });
    }

    $scope.loadCategories();
    

    $scope.Category =
    {
        description:"",
        slug:""
    };

    $scope.saveCategory = function () {
        $http({
            method: "POST",
            url: "/api/category",
            data:{slug: $scope.Category.slug, description: $scope.Category.description}
        }).then(function mySuccess(response) {
            $scope.loadCategories();
            $scope.Category.description = $scope.Category.slug = "";

        }, function myError(response) {
            $scope.error = response.statusText;
        });
    }
});