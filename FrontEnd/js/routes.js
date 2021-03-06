/**
 * Defines the main routes in the application.
 * The routes you see here will be anchors '#/' unless specifically configured otherwise.
 */

define(['./app'], function (app) {
    'use strict';
    return app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/CalcModule/:id', {
            templateUrl: 'partials/Calc.html',
            controller: 'CalcCtrl'
        });

        $routeProvider.when('/fileUpload', {
            templateUrl: 'partials/fileUpload.html',
            controller: 'fileUpload'
        });

        $routeProvider.when('/login', {
            templateUrl: 'partials/login.html',
            controller: 'fileUpload'
        });

        $routeProvider.when('/schemes', {
            templateUrl: 'partials/schemes.html',
            controller: 'schemeCtrl'
        });

        $routeProvider.otherwise({
            redirectTo: '/CalcModule'
        });
    }]);
});
