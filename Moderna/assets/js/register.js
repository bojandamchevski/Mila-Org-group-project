let firstName = document.getElementById("firstName");
let lastName = document.getElementById("lastName");
let email = document.getElementById("email");
let password = document.getElementById("password");
let confirmPassword = document.getElementById("password");
let birthDate = document.getElementById("birthDate");
let phoneNumber = document.getElementById("phoneNumber");
let genderMale = document.getElementById("maleRadio");
let genderFemale = document.getElementById("femaleRadio");
let inputString = document.getElementById("name");
let registerBtn = document.getElementById("registerBtn");

let register = async() => {
        
    let userRegister = {
        FirstName: firstName.value,
        LastName: lastName.value,
        Email : email.value,
        Password: password.value,
        ConfirmedPassword: confirmPassword.value,
        DateOfBirth: birthDate.value,
        Role : parseInt("1"),
        Gender: genderFemale.checked ? parseInt(genderFemale.value) : genderMale.checked ? parseInt(genderMale.value) : null
    };
    
    let response = await fetch("http://localhost:41296/api/Authentication/register", {
        method: 'POST',
        mode: "cors",
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(userRegister)
    })
    .then(function(response){
        console.log(response);
    })
    .catch(function(error){
        console.log(error);
    })
}

registerBtn.addEventListener("click", (e) => {
    e.preventDefault();
    register();
});