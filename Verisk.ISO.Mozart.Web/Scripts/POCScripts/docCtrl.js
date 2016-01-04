
var app = angular.module('app', ['pdf']);
app.controller('DocCtrl',['$scope', '$http', function ($scope, $http) {
    
  $scope.getNavStyle = function(scroll) {
    if(scroll > 100) return 'pdf-controls fixed';
    else return 'pdf-controls';
  }

  $scope.onError = function(error) {
    console.log(error);
  }

  $scope.onLoad = function() {
    $scope.loading = '';
  }

  $scope.onProgress = function(progress) {
    console.log(progress);
  }

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
              debugger;
              $scope.$apply(function () {
                  $scope.pdfUrl = data[0].path;
                  $scope.pdfName = data[0].name;
                  $scope.scroll = 0;
                  $scope.loading = 'loading';
              });
          },
          error: function (xhr, ajaxOptions, thrownError) {
              debugger;
          }
      });
  }
}]);
