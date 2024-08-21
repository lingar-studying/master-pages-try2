console.log("js here");
function validateUserForm2() {
    console.log("validate");
    var username = document.getElementById('<%= OfUserName.ClientID %>').value;
    var password = document.getElementById('<%= OfPassword.ClientID %>').value;
    console.log("yser name")
    //if (username.trim() === "") {
    //    console.log("Username is required.");
    //    return false;
    //}
    //if (password.trim() === "") {
    //    console.log("Password is required.");
    //    return false;
    //}
    return username == "111";
}