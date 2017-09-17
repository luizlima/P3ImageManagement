'use strict'

P3ImageApp.controller("RenderFormController", function ($scope, $http) {
    var pathname = window.location.pathname.split('/');
    var elements = '';
    $http({
        method: "GET",
        url: "/api/subcategory/" + pathname[2] + "/slug"
    }).then(function mySuccess(response) {
        var fields = response.data.fieldsViewModel;
        for (var i = 0; i < fields.length; i++) {
            var field = fields[i];
            switch (field.fieldType) {
                case 'checkbox':
                    var values = field.values.split(',');
                    elements += '<fieldset class="form-group"><legend>' + field.description + '</legend>';
                    for (var j = 0; j < values.length; j++) {
                        var value = values[j];
                        elements += '<div class="form-check form-check-inline" style="float:left;padding:10px;"><label class="form-check-label">';
                        elements += "<input type='checkbox' class='form-check-input' name='" + field.description + "'>" + value + '</input></label></div>';
                    }
                    elements += '</fieldset>';
                    break;
                case 'select':
                    var values = field.values.split(',');
                    elements += '<div class="form-group"><label for="exampleSelect1">' + field.description + '</label>'
                    elements += '<select class="form-control">';
                    for (var j = 0; j < values.length; j++) {
                        var value = values[j];
                        elements += '<option>' + value + '</option>'
                    }
                    elements += '</select></div>';
                    break;
                case 'text':
                    elements += '<div class="form-group"><label for="' + field.description + '">' + field.description + '</label>';
                    elements += '<input type="text" class="form-control" /></div>';
                    break;
                case 'textArea':
                    elements += '<div class="form-group"><label for="exampleTextarea">' + field.description + '</label>';
                    elements += '<textarea class="form-control" rows="3"></textarea></div>';
                    break;
            }

        }
        $('#formFields').html(elements);
    }, function myError(response) {
        $scope.error = response.statusText;
    });
});