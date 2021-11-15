let blogTitle = document.getElementById("exampleFormControlInput2");
let category = document.getElementById("exampleFormControlSelect1");
let imageUrl = "https://totalsafeuk.com/wp-content/uploads/2016/05/CAT1519_NEW_BLOG_CREATIVE_HEADER_1440x758px_2-1024x539.jpg";
let writePost = document.getElementById("exampleFormControlTextarea1");
let saveBtn = document.getElementById("BackToTrainingList");

let createBlog = async() => {
    let blog = {
        Title : blogTitle.value,
        Content : writePost.value,
        ImgURL : imageUrl,
        CategoryId: parseInt("1")
    };
    let response = await fetch("http://localhost:41296/api/training/create-blog", {
        method: "POST",
        mode: "cors",
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type' : 'application/json',
            'Authorization' : `Bearer ${token}`
        },
        body: JSON.stringify(blog)
    })
    .then(function(response){
        console.log(response);
            window.location.href = "file:///C:/Users/Stefan/Desktop/STEFAN/SiMaind%20Project/sedc-cp-03/Moderna/trainingList.html";
        })
    .catch(function(error){
        console.log(error);
    })
}