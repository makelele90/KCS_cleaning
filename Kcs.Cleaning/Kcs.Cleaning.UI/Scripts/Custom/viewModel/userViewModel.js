/// <reference path="../../jquery-2.1.3.intellisense.js" />
/// <reference path="../../knockout-3.3.0.debug.js" />

var userViewModel = function () {

    var self = this;

    self.UserName = ko.observable('enter user name');
    self.Password = ko.observable('');
    self.LoginSuccess = ko.observable(false);
    self.LogIn = function () {

        var postdata = ko.toJSON(self)

        $.ajax({
            url: "api/Authentication/LogIn",
            type: "POST",
            data:postdata,
            contentType:"application/json",
            success: function (result) {

                if (result === 'ok')
                self.LoginSuccess(true);
            }
        });
       
       
    }
}