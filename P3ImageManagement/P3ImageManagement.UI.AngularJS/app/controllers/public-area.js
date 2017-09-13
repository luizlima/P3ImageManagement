'use strict';

P3ImageApp.controller("PublicAreaController", function ($scope,$route, $http) {

    $scope.loadMenu = function () {
        $http({
            method: "GET",
            url: "/api/category"
        }).then(function mySuccess(response) {
            $scope.categories = response.data;
            for (var i = 0; i < $scope.categories.length; i++) {
                var subs = $scope.getSubCategories($scope.categories[i].id);
                $scope.categories[i].subCategories = subs;
                //for (var j = 0; j < subs.length; j++) {
                //    $routeProviderReference.when($scope.categories[i].slug + '/' + subs[j].slug, {
                //        templateUrl: "App/Views/private-area.htm",
                //        controller: "PrivateAreaController"
                //    });
                //}
            }
        }, function myError(response) {
            $scope.error = response.statusText;
        });


    };

    $scope.loadMenu();





    $scope.getSubCategories = function (subCategoryId) {
        //$http({
        //    method: "GET",
        //    url: "api/subcategories/" + subCategoryId + "/category"
        //}).then(function mySuccess(response) {
        //    $scope.subCategoriesTemp = response.data;
        //}, function myError(response) {
        //    $scope.error = response.statusText;
        //});
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
