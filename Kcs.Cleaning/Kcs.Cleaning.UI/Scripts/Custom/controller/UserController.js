kcsApp.controller("UserController", function ($scope, $http) {

    $scope.User = {

        loginSuccess: false,
        UserName: "",
        Password: "",
        ConfirmPassword: "",
        Telephone: "",
        email: "",
        FisrtName: "",
        LastName: "",
        CreatedOn: ""
    };

    $scope.LockedUsers = [];

    $scope.LoadLockedUsers = function () {

        $http.get('/api/User').
              success(function (users, status, headers, config) {
                  $scope.LockedUsers = users;
              }).
              error(function (data, status, headers, config) {

              });
    }
    angular.element(document).ready(function () {

        $scope.LoadLockedUsers();

    });

    $scope.logIn = function () {

        var user = {
            UserName: $scope.User.UserName,
            Password: $scope.User.Password
        }
        $http.post("/api/Authentication/login", JSON.stringify(user))
            .success(function (data, status, headers, config) {
                $scope.loginSuccess = true;
            }).error(function (data, status, headers, config) {
                alert("error");
            });

    }
    $scope.register = function () {

        //validate password (password and confirm password must be the same)
        //username must be using
        var user = {
            UserName: $scope.User.UserName,
            Password: $scope.User.Password,
            Email: $scope.User.Email,
            FirstName: $scope.User.FisrtName,
            LastName: $scope.User.LastName
        };

        $http.post("/api/User", JSON.stringify(user))
            .success(function (data, status, headers, config) {
                $scope.loginSuccess = true;
            }).error(function (data, status, headers, config) {
                alert("error");
            });
    }

});