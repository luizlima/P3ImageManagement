'use strict'
P3ImageApp.controller("SubCategoryController", function ($scope, $http, $window,$route) {
    $scope.fieldTypes = ['checkbox', 'select', 'text', 'textarea'];
    //$scope.fieldTypes =[
    //    {id:0, name: "checkbox"},
    //    {id:1, name:"select"},
    //    {id:2, name:"text"},
    //    {id:3, name:"textarea"}
    //];
    $scope.fields = [];
    $scope.subCategory = {
        description: "",
        slug: "",
        category: {
            id: "",
            slug:""
        },
        fields: $scope.fields
    };

    $scope.field = {
        order: "",
        description: "",
        fieldType: "",
        values:""
    };

    

    $scope.addField = function (order, description, type, values) {
        var f = {
            order: order,
            description: description,
            fieldType: type,
            values: values
        };
        $scope.fields.push(f);

        $scope.field.order = "";
        $scope.field.description = "";
        $scope.field.fieldType = "";
        $scope.field.values = "";
    };

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

    $scope.loadSubCategories = function () {
        $http({
            method: "GET",
            url: "/api/subcategory"
        }).then(function mySuccess(response) {
            $scope.subCategories = response.data;
        }, function myError(response) {
            $scope.error = response.statusText;
        });
    };

    $scope.loadSubCategories();
    $scope.loadCategories();
     
    $scope.saveSubCategory = function () {
        $http({
            method: "POST",
            url: "/api/subcategory",
            data: { slug: $scope.subCategory.slug, description: $scope.subCategory.description, categoryViewModel: $scope.subCategory.category, fieldsViewModel: $scope.subCategory.fields }
        }).then(function mySuccess(response) {
            //$scope.loadSubCategories();
            $routeProviderReference.when($scope.subCategory.category.slug + '/' + $scope.subCategory.slug, {
                templateUrl: "App/Views/private-area.htm",
                controller: "PrivateAreaController"
            });
            $route.reload();
        }, function myError(response) {
            $scope.error = response.statusText;
        });
    }

});