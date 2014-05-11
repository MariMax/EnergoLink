/** attach controllers to this module 
 * if you get 'unknown {x}Provider' errors from angular, be sure they are
 * properly referenced in one of the module dependencies in the array.
 * below, you can see we bring in our services and constants modules
 * which avails each controller of, for example, the `config` constants object.
 **/
define(['angular', 'ungular-ui', 'newCalculationPopup','angular-file-upload','backEnd'], function(ng) {
	'use strict';
	return ng.module('app.controllers', ['ui.bootstrap', 'newCalculationPopup','angularFileUpload','backEnd']);
});