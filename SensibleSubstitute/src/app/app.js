var sensibleApp = angular.module('SensibleApp', ['ngRoute','BlogController']);

sensibleApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider)
{
    //$locationProvider.html5Mode(true);
        $routeProvider.when('/',
        {
            controller: 'BlogController',
            templateUrl: '/Partials'
        });
        $routeProvider.when('/view',
        {
            controller: 'BlogController',
            templateUrl: '/Partials/partial2.html'
        })
        $routeProvider.otherwise({ redirectTo: '/' });
}]);

    // A run block is the code which needs to run to kickstart the application.
    // You can have as many of these as you want.
    // You can only inject instances (not Providers)
    // into the run blocks.

var controllers = {};


/*
.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        
        // Specify the three simple routes ('/', '/About', and '/Contact')
        $routeProvider.when('/', {
            templateUrl: '/Home/Home',
            controller: 'homeCtrl',
        });
        $routeProvider.when('/About', {
            templateUrl: '/Home/About',
            controller: 'aboutCtrl',
        });
        $routeProvider.when('/Contact', {
            templateUrl: '/Home/Contact',
            controller: 'contactCtrl'
        });
        $routeProvider.otherwise({
            redirectTo: '/'
        });

        // Specify HTML5 mode (using the History APIs) or HashBang syntax.
        $locationProvider.html5Mode(false).hashPrefix('!');

    }]);
    */