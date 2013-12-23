var app = angular.module('SensibleApp');
var controllers = {};

controllers.StoreController = function ($scope)
{
    $scope.title = 'Resource Store';
};

app.controller(controllers);