var app = angular.module('SensibleApp');
var controllers = {};

controllers.BlogController = function ($scope) {
    $scope.name = 'Hello';
    $scope.other = 'Tim. It works';
};

controllers.OtherController = function ($scope) {
    $scope.name = 'Hello';
    $scope.other = 'Everyone';
};

app.controller(controllers);