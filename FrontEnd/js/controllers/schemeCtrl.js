define(['./module', 'underscore'], function(controllers, _) {
  'use strict';

  controllers.controller('schemeCtrl', ['$scope', '$newCalculationPopup', '$backEnd',
    function($scope, newCalculationPopup, $backEnd) {
      $scope.model = {};
      $scope.model.companyId = '3DC72D1C-1DA4-425C-ACFA-99DE60C89BCB';
      $scope.model.schemes = [];

      $scope.newCalculation = function() {

        var dialog = newCalculationPopup.create({
          schemes: $scope.model.schemes
        }).open();

        dialog.then(function(res) {
          $backEnd.calcScheme(res.Id, res.StartDate, res.EndDate).then(function(data){
            debugger;
            var scheme = _.find($scope.model.schemes, function(scheme){return scheme.Id==res.Id});
            $scope.model.schemes.push({Id:data.data.CalcId, StartDate:$scope.model.StartDate, EndDate:$scope.model.EndDate, Done:false, Name:scheme.Name});
          })
        });
      };

      $scope.recalc = function(shemeId) {
        var sheme = _.find($scope.model.schemes, function(scheme) {
          return scheme.Id == shemeId;
        });

      };

      $scope.show = function() {
        $backEnd.getSchemes($scope.model.companyId, $scope.model.StartDate, $scope.model.EndDate).then(function(data) {
          $scope.model.schemes = data.data.Schemes;
        });
      }

    }
  ]);
});