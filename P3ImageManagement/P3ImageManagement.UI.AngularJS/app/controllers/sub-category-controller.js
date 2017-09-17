'use strict'
P3ImageApp.controller("SubCategoryController", function ($scope, $http, $window,$route) {
    $scope.fieldTypes = ['checkbox', 'select', 'text', 'textarea'];
    
    $scope.fields = [];
    $scope.subCategory = {
        description: "",
        slug: "",
        category: {
            id: "",
            slug:""
        },
        fields: []
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

    $scope.clearForm = function () {
        $scope.subCategory.description = '';
        $scope.subCategory.slug = '';
        $scope.subCategory.category = '';
        $scope.fields = [];
    }

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
            $('#tableSubcategories').focus();
        }, function myError(response) {
            $scope.error = response.statusText;
        });
    };

    $scope.loadSubCategories();
    $scope.loadCategories();
     
    $scope.saveSubCategory = function () {
        $scope.subCategory.fields = $scope.fields;
        $http({
            method: "POST",
            url: "/api/subcategory",
            data: { slug: $scope.subCategory.slug, description: $scope.subCategory.description, categoryViewModel: $scope.subCategory.category, fieldsViewModel: $scope.subCategory.fields }
        }).then(function mySuccess(response) {
            $scope.loadSubCategories();
            $scope.clearForm();
        }, function myError(response) {
            $scope.error = response.statusText;
        });
    }

});