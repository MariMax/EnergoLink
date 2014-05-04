define(['./module'], function (controllers) {
    'use strict';
    controllers.controller('CalcCtrl', ['$scope',function ($scope) {
    	$scope.tree=[
        { "itemLabel" : "User", "itemId" : "role1", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36, "items" : [
          { "itemLabel" : "subUser1", "itemId" : "role11",  "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [] },
          { "itemLabel" : "subUser2", "itemId" : "role12",  "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [
            { "itemLabel" : "subUser2-1", "itemId" : "role121", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [
              { "itemLabel" : "subUser2-1-1", "itemId" : "role1211", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [] },
              { "itemLabel" : "subUser2-1-2", "itemId" : "role1212", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [] }
            ]}
          ]}
        ]},

        { "itemLabel" : "Admin", "itemId" : "role2","aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [
          { "itemLabel" : "subAdmin1", "itemId" : "role11", "collapsed" : true, "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [] },
          { "itemLabel" : "subAdmin2", "itemId" : "role12", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [
            { "itemLabel" : "subAdmin2-1", "itemId" : "role121", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [
              { "itemLabel" : "subAdmin2-1-1", "itemId" : "role1211", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [] },
              { "itemLabel" : "subAdmin2-1-2", "itemId" : "role1212", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [] }
            ]}
          ]}
        ]},

        { "itemLabel" : "Guest", "itemId" : "role3", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [
          { "itemLabel" : "subGuest1", "itemId" : "role11", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [] },
          { "itemLabel" : "subGuest2", "itemId" : "role12", "collapsed" : true, "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [
            { "itemLabel" : "subGuest2-1", "itemId" : "role121", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [
              { "itemLabel" : "subGuest2-1-1", "itemId" : "role1211", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [] },
              { "itemLabel" : "subGuest2-1-2", "itemId" : "role1212", "aPositive":25, "rPositive":26, "aNegative":35,"rNegative":36,"items" : [] }
            ]}
          ]}
        ]}
      ];

    }]);
});
