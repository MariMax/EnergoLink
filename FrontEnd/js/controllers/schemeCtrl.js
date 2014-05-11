define(['./module', 'underscore'], function(controllers, _) {
  'use strict';

  controllers.controller('schemeCtrl', ['$scope', '$newCalculationPopup',
    function($scope, newCalculationPopup) {
      $scope.shemes = [{
        "Id": "15dfd5f7-d61c-495f-9574-5e62caf39b52",
        "Name": "ОАО \"Челябэнергосбыт\"",
        "StartDate": "2014-04-01T00:00:00",
        "EndDate": "2014-05-01T00:00:00",
        "Done": true
      }, {
        "Id": "f3518b55-f4c4-4836-8063-43f2591c4761",
        "Name": "\"ЭСКБ\"",
        "StartDate": "2014-04-01T00:00:00",
        "EndDate": "2014-05-01T00:00:00",
        "Done": false
      }];



      $scope.newCalculation = function() {

        var dialog = newCalculationPopup.create({
          shemes: $scope.shemes
        }).open();

        dialog.then(function(res) {
          debugger;
        });
      };

      $scope.recalc = function(shemeId) {
        var sheme = _.find($scope.shemes, function(scheme) {
          return scheme.Id == shemeId;
        });

      };

      $scope.show = function() {
        debugger;
      }

    }
  ]);
});