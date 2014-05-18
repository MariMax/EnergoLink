define(['./module'], function(directives) {
		'use strict';
		directives.directive('datePicker', [

			function() {
				return {
					restrict: 'A',
					templateUrl: "/partials/datePicker.html",
				replace: true,
				scope: {
					date: '=',
					dateFormat: '=',
					minDate: '=',
					maxDate: '=',
					required: '=',
				},
				controller: ['$scope',
					function($scope) {

						$scope.format = $scope.dateFormat||'dd-MMMM-yyyy';
						$scope.today = function() {
							$scope.date = new Date();
							
						};
						$scope.today();

						$scope.disabled = function(date, mode) {
							return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
						};

						$scope.open = function($event) {
							$event.preventDefault();
							$event.stopPropagation();

							$scope.opened = true;
						};

						$scope.dateOptions = {
							formatYear: 'yy',
							startingDay: 1
						};
					}
				]
			}
		}]);
});