'use strict';
  
P3ImageApp.controller("PrivateAreaController", function ($scope) {
    
    $scope.Title = "Área privada";
    $scope.views =
        [
            { url: 'App/Views/category/categories.htm' },
            { url: 'App/Views/subCategory/subCategories.htm' }
        ];
    $scope.currentView = $scope.views[0];
    $scope.clickMenuItem = function (option) {
        $('#list-itens-menu li').removeClass('active');
        if (option == 'category') {
            $('#item-category').addClass('active');
            $scope.currentView = $scope.views[0];
        }else
        {
            $('#item-sub-category').addClass('active');
            $scope.currentView = $scope.views[1];
        }
    };
});
