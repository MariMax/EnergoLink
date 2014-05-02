/**
 * configure RequireJS
 * prefer named modules to long paths, especially for version mgt
 * or 3rd party libraries
 */
require.config({

    paths: {
        'angular': '//cdnjs.cloudflare.com/ajax/libs/angular.js/1.3.0-beta.3/angular',
        'angular-route': '//cdnjs.cloudflare.com/ajax/libs/angular.js/1.3.0-beta.3/angular-route',
        'domReady': '//cdnjs.cloudflare.com/ajax/libs/require-domReady/2.0.1/domReady.min'
    },

    /**
     * for libs that either do not support AMD out of the box, or
     * require some fine tuning to dependency mgt'
     */
    shim: {
        'angular': {
            exports: 'angular'
        },
        'angular-route': {
            deps: ['angular']
        }
    },

    deps:['./StartApp'],

});
