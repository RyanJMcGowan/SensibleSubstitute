var SensibleApp = angular.module('SensibleApp', []);

SensibleApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider)
{
    $routeProvider.when('/', {
        templateUrl: '/Partials/home',
        controller: 'BlogController',
    })
    $routeProvider.when('/news', {
        templateUrl: '/Partials/News',
        controller: 'OtherController',
    })
    $routeProvider.when('/contact', {
        templateUrl: '/Partials/Contact',
        controller: 'OtherController',
    })
    $routeProvider.otherwise({
        redirectTo: '/'
    });
    $locationProvider.html5Mode(true);
}]);

var controllers = {};

SensibleApp.controller(controllers);