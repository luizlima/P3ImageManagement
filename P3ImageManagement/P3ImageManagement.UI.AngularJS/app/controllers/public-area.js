'use strict';

P3ImageApp.controller("PublicAreaController", function ($scope, $route, $http) {

    $scope.getMenu = function () {
        var categories = [];
        $http({
            method: "GET",
            url: "/api/category"
        }).then(function mySuccess(response) {
            categories = response.data;
            for (var i = 0; i < categories.length; i++) {
                var subs = $scope.getSubCategories(categories[i].id);
                categories[i].subCategories = subs;
            }
        }, function myError(response) {
            $scope.error = response.statusText;
        });

        return categories;
    };

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
