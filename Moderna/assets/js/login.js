let email = document.getElementById("floatingInput");
let password = document.getElementById("floatingPassword");
let logInBtn = document.getElementById("logInBtn");

let login = async() => {
    let user = {
        Email: email.value,
        Password: password.value
    };

    let response = await fetch("http://localhost:41296/api/authentication/login", {
        method: "POST",
        mode: "cors",
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(user)
    })
    .then(function(response){
        response.text()
        .then(function(text){
            localStorage.setItem("loginToken", text);
            console.log("logged");
        })
    })
    .catch(function(error){
        console.log(error);
    })
}

logInBtn.addEventListener("click", login);