define('configuration', ['angular'], function(angular) {

    var config = angular.module('configuration', []);

    function configurationFactory() {
        return {
            baseUrl: 'http://localhost:2226',
        }
    };

    config.factory('$configuration', [configurationFactory]);

    return config;
});