var sensibleApp = angular.module('SensibleApp', [])

controllers.BlogController = function ($scope)
{
    $scope.Model = {
        name: 'Hello',
        other: 'World'
    }
}

controllers.OtherController = function ($scope)
{
    $scope.Model = {
        name: 'Hello',
        other: 'Everyone'
    }
}

sensibleApp.controller(controllers);