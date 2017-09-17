'use strict'

P3ImageApp.controller("AreasController", function ($scope, $http) {
    $scope.categories = [];
    $scope.welcome = "welcome";
    $scope.areasViews = {
        publicTemplateUrl: "/App/Views/public-area.htm",
        privateTemplateUrl: "App/Views/private-area.htm"
    };
    $scope.privateViews = {
        categoryTemplateUrl: 'App/Views/category/categories.htm',
        subCategoryTemplateUrl: 'App/Views/subCategory/subCategories.htm'
    };

    $scope.currentAreaView = $scope.areasViews.publicTemplateUrl;
    $scope.clickMainMenuItem = function (option) {
        if (option == 'public') {
            window.location = "/";
            //$scope.currentAreaView = $scope.areasViews.publicTemplateUrl;
        }
        else if (option == 'private') {
            $scope.currentAreaView = $scope.areasViews.privateTemplateUrl;
            $scope.currentPrivateView = $scope.privateViews.categoryTemplateUrl;
        }
    }

    $scope.clickPrivateMenuItem = function (option) {
        $('#list-itens-menu li').removeClass('active');
        if (option == 'category') {
            $('#item-category').addClass('active');
            $scope.currentPrivateView = $scope.privateViews.categoryTemplateUrl;
        }
        else if (option == 'subcategory') {
            $('#item-sub-category').addClass('active');
            $scope.currentPrivateView = $scope.privateViews.subCategoryTemplateUrl;
        }
    }

    $scope.getMenu = function () {
        $http({
            method: "GET",
            url: "/api/category"
        }).then(function mySuccess(response) {
            $scope.categories = response.data;
            for (var i = 0; i < $scope.categories.length; i++) {
                var subs = $scope.getSubCategories($scope.categories[i].id);
                $scope.categories[i].subCategories = subs;
            }
        }, function myError(response) {
            $scope.error = response.statusText;
        });
    }

    $scope.getSubCategories = function (subCategoryId) {
        var subCategories;
        $.ajax({
            method: "GET",
            url: "api/subcategories/" + subCategoryId + "/category",
            async: false
        })
      .done(function (response) {
          subCategories = response;
      });

        return subCategories;
    }
});