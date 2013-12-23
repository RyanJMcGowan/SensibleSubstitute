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
    $routeProvider.when('/articles', {
        templateUrl: '/Partials/blog',
        controller: 'OtherController',
    })
    $routeProvider.when('/reviews', {
        templateUrl: '/Partials/Reviews',
        controller: 'OtherController',
    })
    $routeProvider.when('/playbook', {
        templateUrl: '/Partials/Playbook',
        controller: 'OtherController',
    })
    $routeProvider.when('/tales', {
        templateUrl: '/Partials/Tales',
        controller: 'OtherController',
    })
    $routeProvider.when('/tales', {
        templateUrl: '/Partials/Tales',
        controller: 'OtherController',
    })
    $routeProvider.when('/scoop', {
        templateUrl: '/Partials/Scoop',
        controller: 'OtherController',
    })
    $routeProvider.when('/letters', {
        templateUrl: '/Partials/Letters',
        controller: 'OtherController',
    })
    $routeProvider.when('/store', {
        templateUrl: '/Partials/Store',
        controller: 'OtherController',
    })
    $routeProvider.otherwise({
        redirectTo: '/'
    });
    $locationProvider.html5Mode(true);
}]);

var controllers = {};

SensibleApp.controller(controllers);