define('backEnd', ['angular', 'configuration'], function(angular) {

	var backEnd = angular.module('backEnd', []);

	function backEndFactory($http, $configuration) {
		var baseUrl = $configuration.baseUrl;
		return {
			getSchemes: function(companyId, StartDate, EndDate) {
				return $http({
					url: baseUrl + '/api/XCalculator/GetSchemes',
					method: "POST",
					data: {
						CompanyId: companyId,
						StartDate: StartDate,
						EndDate: EndDate
					}
				});
			},

			calcScheme: function(schemeId, StartDate, EndDate) {
				return $http({
					url: baseUrl + '/api/XCalculator/Calc',
					method: "POST",
					data: {
						SchemeId: schemeId,
						StartDate: StartDate,
						EndDate: EndDate
					}
				});
			},

			calcResult: function(calcId) {
				return $http.get(baseUrl + '/api/XCalculator/GetCalcResult', {
					params: {
						calcId: calcId
					}
				});
			},



		};
	};

	backEnd.factory('$backEnd', ['$http', '$configuration', backEndFactory]);

	return backEnd;
});