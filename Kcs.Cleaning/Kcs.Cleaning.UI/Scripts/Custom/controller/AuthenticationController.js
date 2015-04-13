kcsApp.controller("AuthenticationController", function ($scope, $http) {
    $scope.loginSuccess = false;
    $scope.UserName = "";
    $scope.Password = "";
    $scope.logIn = function () {

        var user = {
            UserName: $scope.UserName,
            Password: $scope.Password
        }
        $http.post("/api/Authentication/login", JSON.stringify(user))
            .success(function (data, status, headers, config) {
                $scope.loginSuccess = true;
            }).error(function (data, status, headers, config) {
                alert("error");
            });

    }

});