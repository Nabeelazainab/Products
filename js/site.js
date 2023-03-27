var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http) {

    $http.get("/api/product")
        .then(function (response) {
            $scope.myData = response.data;
        });
    $scope.Savechanges = function () {
        $http({
            method: 'POST',
            url: "/api/product",
            data: $scope.save

        }).then(function (response) {
            $scope.ResponseText = "Saved";
            $scope.save = null;

        });


    }
    $scope.DeleteData = function (id) {
        $http.delete("/api/product/DeleteWebitems/" + id)
            .then(function (response) {
                alert('Successfully Deleted, Refresh The Page For Update');
            }, function (error) {
                alert('Already Deleted');
            });

    };

});