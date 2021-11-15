let trainingTitle = document.getElementById("exampleFormControlInput2");
let emailAddress = document.getElementById("exampleFormControlInput1");
let date = document.getElementById("date");
let comments = document.getElementById("exampleFormControlTextarea1");
let numberOfAttendees = document.getElementById("exampleFormControlInput3");
let submitBtn = document.getElementById("trainingInfoSub");

let createTraining = async() => {
    let training = {
        Title : trainingTitle.value,
        Email : emailAddress.value,
        Date : date.value,
        NumberOfTotalSpots : parseInt(numberOfAttendees.value),
        Comments : comments.value,
        TrainerId: parseInt("1")
    };
    console.log(training.Title);
    console.log(training.Email);
    console.log(training.Date);
    console.log(training.NumberOfTotalSpots);
    console.log(training.Comments);

    let response = await fetch("http://localhost:41296/api/training/create-training", {
        method: "POST",
        mode: "cors",
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type' : 'application/json',
            'Authorization' : `Bearer ${token}`
        },
        body: JSON.stringify(training)
    })
    .then(function(response){
        console.log(response);
            window.location.href = "file:///C:/Users/Stefan/Desktop/STEFAN/SiMaind%20Project/sedc-cp-03/Moderna/trainingList.html";
        })
    .catch(function(error){
        console.log(error);
    })
}

submitBtn.addEventListener("click", createTraining);