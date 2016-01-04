var app = angular.module('app', []);
app.controller('pdfController', ['$scope', '$http',
    function ($scope, $http) {
        $scope.GeneratePDF = function () {
            GetDocumentDownLoad();
        }
        function GetDocumentDownLoad() {
            var objectIdValues = $scope.FileObjectId;
            $.ajax({
                cache: false,
                type: "GET",
                url: Url_GetPdfFile,
                data: { objectIdValue: objectIdValues },
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#pdfContainer').html('');
                    $('#pdfContainer').html(data);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                }
            });
        }
    }]);
