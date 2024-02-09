let signup = document.querySelector(".signup");
let login = document.querySelector(".login");
let slider = document.querySelector(".slider");
let formSection = document.querySelector(".form-section");

function ShowLogin() {
    if ($(slider).hasClass("moveslider")) {
        slider.classList.remove("moveslider");
        formSection.classList.remove("form-section-move");
    }
}
signup.addEventListener("click", () => {
    slider.classList.add("moveslider");
    formSection.classList.add("form-section-move");
});
function ShowSignUp() {
    debugger
    $.ajax({
        url: '/Account/SignUp',
        type: "get",
        success: function () {
            debugger
      
        },
    });
}
function addClassToSlider() {
   
}