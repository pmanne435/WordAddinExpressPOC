'use strict';


var app = angular.module('app', ['angularFileUpload', 'ui.grid']);

app.config(['$compileProvider', function ($compileProvider) {
    $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|file|tel|iso-mozart):/);
}]);

app.controller('AppController', ['$scope', 'FileUploader', '$http',
    function ($scope, FileUploader, $http) {

        $scope.tags = [{
            Id: 1,
            Name: 'Liquor'
        }, {
            Id: 2,
            Name: 'DUI'
        }, {
            Id: 3,
            Name: 'Drones'
        },
        {
            Id: 4,
            Name: 'Additions'
        },
        {
            Id: 5,
            Name: 'Abuse'
        },
        {
            Id: 6,
            Name: 'GMO'
        }];


        $scope.columns = [
            {
                field: 'FileId',
                displayName: 'Edit',
                width: '10%',
                enableColumnMenu: false,
                //cellTemplate: '<div><a href="iso-mozart://open;id={{row.entity[col.field]}}">{{row.entity[col.field]}}</a></div>'
                cellTemplate: '<div><a href="iso-mozart://open;id={{row.entity[col.field]}}">Edit</a></div>'
            },
            {
                field: 'FormNumber',
                displayName: 'Form Number',
                width: '28%',
                enableColumnMenu: false,
            },
       {
           field: 'FormTitle',
           displayName: 'Form Title',
           width: '29%',
           enableColumnMenu: false,
       },
       {
           field: 'FileName',
           displayName: 'File Name',
           width: '17%',
           enableColumnMenu: false
       }];

        //Grid options
        $scope.formGridOptions = {
            rowHeight: 36,
            enableSorting: true,
            enableFiltering: false,
            columnDefs: $scope.columns,
            //data: $scope.myData,
            paginationPageSizes: [
                25,
                50,
                75,
                100
            ],
            paginationPageSize: 25
        };

        GetFormDetails();

        function GetFormDetails() {
            $http({
                method: 'POST',
                url: 'home/GetAllForms', // dont change this path and it will effect the application
                async: true,
                cache: false,
            }).success(function (data) {
                $scope.formGridOptions.data = angular.fromJson(data.data);
            }).error(function (data, status, headers, config) {
            });
        }

        var uploader = $scope.uploader = new FileUploader({
            url: "home/UploadAllFiles"
        });

        uploader.filters.push({
            name: 'customFilter',
            fn: function (item) {
                //if (/\/(msword)|(pdf)(png)$/.test(item.type) === true) {
                if (/\/(msword)|(document)$/.test(item.type) === true) {
                    return true;
                } else {
                    $scope.fileTypeError = 'Incorrect filetype';
                    return false;
                }
            }
        });
         
        $scope.onFileSelect = function ($files) {
            console.info('OnFile Select', $files);
        }

        //console.info('uploader', uploader);
        // FILTERS

        uploader.filters.push({
            name: 'customFilter',
            fn: function (item /*{File|FileLikeObject}*/, options) {
                return this.queue.length < 10;
            }
        });
        // CALLBACKS
        uploader.onWhenAddingFileFailed = function (item /*{File|FileLikeObject}*/, filter, options) {
            console.info('onWhenAddingFileFailed', item, filter, options);
        };
        uploader.onAfterAddingFile = function (fileItem) {
            console.info('onAfterAddingFile', fileItem);
            $scope.filesAdded = true;
        };
        uploader.onAfterAddingAll = function (addedFileItems) {
            console.info('onAfterAddingAll', addedFileItems);
            $scope.filesAdded = true;
        };

        uploader.onBeforeUploadItem = function (item) {
            item.formData.push($scope.form);
            console.info('onBeforeUploadItem', item);
        };
        uploader.onProgressItem = function (fileItem, progress) {
            console.info('onProgressItem', fileItem, progress);
        };
        uploader.onProgressAll = function (progress) {
            console.info('onProgressAll', progress);
        };
        uploader.onSuccessItem = function (fileItem, response, status, headers) {

            console.info('onSuccessItem', fileItem, response, status, headers);
        };
        uploader.onErrorItem = function (fileItem, response, status, headers) {
            console.info('onErrorItem', fileItem, response, status, headers);
        };
        uploader.onCancelItem = function (fileItem, response, status, headers) {
            console.info('onCancelItem', fileItem, response, status, headers);
        };
        uploader.onCompleteItem = function (fileItem, response, status, headers) {

            console.info('onCompleteItem', fileItem, response, status, headers);
        };
        uploader.onCompleteAll = function () {
            console.info('onCompleteAll');
            GetFormDetails();
        };
    }]);

