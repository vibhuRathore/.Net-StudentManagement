function SubmitDataToPostSignUp() {
    debugger
    var receivedUserData = {
        Name: $("#signUpName").val(),
        Email: $("#signUpEmail").val(),
        Password: $("#signUpPassword").val(),
        ConfirmPassword: $("#signUpConfirmPassword").val()
    };
    debugger
    $.ajax({
        url: '/Account/SignUp',
        type: "post",
        data: ({ receivedUserData: receivedUserData }),
        success: function (response) {
            console.log("Success", response);
        },
        error: function (error) {
            console.error("Error:", error);
        }
    });

}

function SubmitDataToPostLogin()
{
    debugger
    var receivedUserData = {
        UserName: $("#loginUserName").val(),
        Password: $("#loginPassword").val()
    };
    debugger
    $.ajax({
        url: '/Account/Login',
        type: "post",
        data: ({ receivedUserData: receivedUserData }),
        success: function (response) {
            console.log("Success", response);
        },
        error: function (error) {
            console.error("Error:", error);
        }
    });
}
function ViewForgot() {
    debugger
    $.ajax({
        type: "GET",
        datatype: "html",
        success: function (result) {
            window.location.href = '/Account/ForgotPassword'
        },
        error: function (error) {
            console.error("Error:", error);
        }
    });
}