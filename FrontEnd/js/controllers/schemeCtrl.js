define(['./module','underscore'], function (controllers,_) {
    'use strict';
    controllers.controller('schemeCtrl', ['$scope','$modal', function ($scope,$modal) {
    	$scope.shemes = [{"Id":"15dfd5f7-d61c-495f-9574-5e62caf39b52","Name":"ОАО \"Челябэнергосбыт\"","StartDate":"2014-04-01T00:00:00","EndDate":"2014-05-01T00:00:00","Done":true},
                      {"Id":"f3518b55-f4c4-4836-8063-43f2591c4761","Name":"\"ЭСКБ\"","StartDate":"2014-04-01T00:00:00","EndDate":"2014-05-01T00:00:00","Done":false}];

      

      $scope.newCalculation = function(){

          var modalInstance = $modal.open({
              templateUrl: 'partials/newCalculationPopup.html',
              controller: function ($scope, $modalInstance, items) {
                if(items){
                    $scope.schemes = items;
                    $scope.schemes.selected = $scope.schemes[0];
                }

                $scope.format = 'dd-MMMM-yyyy';
                $scope.today = function() {
                  $scope.StartDate = new Date();
                };
                $scope.today();

                $scope.disabled = function(date, mode) {
                  return ( mode === 'day' && ( date.getDay() === 0 || date.getDay() === 6 ) );
                };

                $scope.openStart = function($event) {
                  $event.preventDefault();
                  $event.stopPropagation();

                  $scope.startOpened = true;
                };

                $scope.openEnd = function($event) {
                  $event.preventDefault();
                  $event.stopPropagation();

                  $scope.endOpened = true;
                };

                $scope.dateOptions = {
                  formatYear: 'yy',
                  startingDay: 1
                };                
                
                $scope.ok = function () {
                    $modalInstance.close({success:true, StartDate:$scope.StartDate, EndDate:$scope.EndDate, Id:$scope.schemes.selected.Id});
                };

                $scope.cancel = function () {
                    $modalInstance.close({success:false});
                };
              },
              
              resolve: {
                  items: function () {
                        return $scope.shemes;
                  }
              }
          });

          modalInstance.result.then(function (res) {
              debugger;
          });
      };

      $scope.recalc = function(shemeId){
        var sheme = _.find($scope.shemes, function(scheme){
          return scheme.Id == shemeId;
        });
        
      };
      /*datepicker*/
      $scope.format = 'dd-MMMM-yyyy';
      $scope.today = function() {
        $scope.StartDate = new Date();
      };
      $scope.today();

      $scope.disabled = function(date, mode) {
        return ( mode === 'day' && ( date.getDay() === 0 || date.getDay() === 6 ) );
      };

      $scope.openStart = function($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.startOpened = true;
      };

      $scope.openEnd = function($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.endOpened = true;
      };

      $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1
      };
    }]);
});
