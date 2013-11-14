var SensibleApp = angular.module('SensibleApp', []);

SensibleApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider)
{
    $routeProvider.when('/', {
        templateUrl: '/Partials/Index',
        controller: 'BlogController',
    })
    $routeProvider.when('/Everyone', {
        templateUrl: '/Partials/Index',
        controller: 'OtherController',
    })
    $routeProvider.otherwise({
        redirectTo: '/'
    });
    $locationProvider.html5Mode(true);
}]);

var controllers = {};

SensibleApp.controller(controllers);