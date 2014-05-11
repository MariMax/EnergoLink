define('newCalculationPopup', ['angular','ungular-ui'], function(angular) {

    var newComtrollerPopup = angular.module('newCalculationPopup', ['ui.bootstrap']);

    function newCalculationPopupFactory($modal) {
        function keyOptions(options) {
            options = options || {};
            this.dialogOptions = {
                resolve: {
                    items: function() {
                        return options.shemes;
                    }
                },
                templateUrl: 'partials/newCalculationPopup.html',
                controller: function($scope, $modalInstance, items) {
                    if (items) {
                        $scope.schemes = items;
                        $scope.schemes.sel = $scope.schemes[0];
                    }

                    $scope.ok = function() {

                        $modalInstance.close({
                            success: true,
                            StartDate: $scope.schemes.startDate,
                            EndDate: $scope.schemes.endDate,
                            Id: $scope.schemes.sel.Id
                        });

                        
                    };

                    $scope.cancel = function() {
                        $modalInstance.close({
                            success: false
                        });

                        
                    };
                },
            }

            angular.extend(this, api);
        }

        var api = {
            open: function() {
                return $modal.open(this.dialogOptions).result;
            }
        };

        return {
            create: function(options) {
                return new keyOptions(options);
            }
        };

    };

    newComtrollerPopup.factory('$newCalculationPopup', ['$modal', newCalculationPopupFactory]);

    return newComtrollerPopup;


});