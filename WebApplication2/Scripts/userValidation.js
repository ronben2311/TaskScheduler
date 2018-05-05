(function () {
app.controller("userValidCtrl", function ($scope, AjaxCallsFact, $location, sharedData) {

    var ApiFailure = function (err) {
        console.log("err : ", err);
    };

    $scope.ValidateUser = function (iUserLogIn) {
        $scope.searchMessage = 'Searching...';
        AjaxCallsFact.ValidateUser(iUserLogIn).then(
           function (res) {
               if (res.data) {
                   console.log("res.data: ", res.data);
                   sharedData.set(res.data);

                   $location.path('/resultSection.html');
               }
               $scope.searchMessage = 'please try HW and 123';
           }, ApiFailure);
    };

});
}());
