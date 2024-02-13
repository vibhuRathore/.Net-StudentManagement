
function afterHomeSignUp() {
    debugger
    $.ajax({
        type: "GET",
        datatype: "html",
        success: function (result) {
            window.location.href = '/Account/SignUp'
        },
        error: function (error) {
            console.error("Error:", error);
        }
    });
}

function afterHomeLogin() {
    debugger
    $.ajax({
        type: "GET",
        url: "../Account/Login",
        datatype: "html",
        success: function (result) {
            window.location.href = '/Account/Login'
        },
        error: function (error) {
            console.error("Error:", error);
        }
    });
}

