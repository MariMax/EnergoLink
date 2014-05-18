/*

	[TREE attribute]
	angular-treeview: the treeview directive
	tree-id : each tree's unique id.
	tree-model : the tree model on $scope.
	node-id : each node's id
	node-label : each node's label
	node-children: each node's children

	<div
		data-angular-treeview="true"
		data-tree-id="tree"
		data-tree-model="roleList"
		data-node-id="roleId"
		data-node-label="roleName"
		data-node-children="children" >
	</div>
*/

define(['./module'], function (directives) {
	'use strict';

	directives.directive( 'tableModel', ['$compile','$rootScope', function( $compile, $rootScope ) {
		return {
			restrict: 'A',
			link: function ( $scope, $element, attrs ) {

			
				//tree model
				var treeModel = attrs.tableModel;

				//children
				var nodeChildren = attrs.nodeChildren || 'children';

				var aPositive = attrs.aPositive||'aPositive';

				var aNegative = attrs.aNegative||'aNegative';

				var rPositive = attrs.rPositive||'rPositive';

				var rNegative = attrs.rNegative||'rNegative';



				//tree template
				var template =
					'<div data-ng-repeat="node in ' + treeModel + '">'+
					'<div class="row"><div class="cell">{{node.'+aPositive+'}}</div><div class="cell">{{node.'+aNegative+'}}</div><div class="cell">{{node.'+rPositive+'}}</div><div class="cell">{{node.'+rNegative+'}}</div></div>'+
					'<div ng-if="!node.collapsed" data-ng-hide="node.collapsed" data-table-model="node.' + nodeChildren + '" data-node-children=' + nodeChildren + '></div>'+
					'</div>';


				if(  treeModel ) {

					$element.html('').append( $compile( template )( $scope ) );
				}
			}
		};
	}]);
});