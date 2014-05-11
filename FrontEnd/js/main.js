/**
 * configure RequireJS
 * prefer named modules to long paths, especially for version mgt
 * or 3rd party libraries

 Подробное описание как это все работает читать тут http://www.startersquad.com/blog/angularjs-requirejs/
 */
require.config({

    paths: {
        'angular': '//cdnjs.cloudflare.com/ajax/libs/angular.js/1.3.0-beta.3/angular',
        'angular-route': '//cdnjs.cloudflare.com/ajax/libs/angular.js/1.3.0-beta.3/angular-route',
        'domReady': '//cdnjs.cloudflare.com/ajax/libs/require-domReady/2.0.1/domReady.min',
        'ungular-ui':'/js/lib/ui-bootstrap-tpls-0.11.0.min',
        "underscore":'//cdnjs.cloudflare.com/ajax/libs/underscore.js/1.6.0/underscore-min',
        'newCalculationPopup':'/js/popups/newCalculationPopup',
        'configuration':'/js/config',
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
        },
        'ungular-ui': {
            deps: ['angular']
        },
    },

    deps:['./StartApp'],

});
