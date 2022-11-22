const APIs = {
    weatherApi: "fd3ea34bb5eb7ae4faae0c8095446b88",
    newsApi: "d1cb154147684011afda58be32a45cf9"
};

// ===== WEATHER ===== //

(async function getApiData(api) {
    const getData = await fetch(`https://api.openweathermap.org/data/2.5/weather?q=Tallinn&units=metric&appid=${api}`)
    const data = await getData.json();
    console.log(data)

    const { icon } = data.weather[0];
    const { temp } = data.main;

    document.querySelector("#temp").innerHTML = `${temp.toFixed(0)}°C`;
    document.querySelector("#image").src = `https://openweathermap.org/img/wn/${icon}.png`;
})(APIs.weatherApi);

// ===== NEWS ===== //

const currentDate = new Date().toJSON().slice(0, 10).replace(/-/g, '/');

const titleDisplay = document.querySelector("#title");
const descriptionDisplay = document.querySelector("#description");
const urlToImageDisplay = document.querySelector("#urltoImage");

const inputText = document.querySelector("#inputText");
const btn = document.querySelector("#btnEnter");


const btnBack = document.querySelector("#back");
const btnForward = document.querySelector("#forward");

[btnBack.disabled, btnForward.disabled] = [true, true];

// ===================================================//

const list = document.querySelector("#listOfCategories");
const links = document.querySelectorAll("#listOfCategories button")

let articleNumber = 0;
let getRequestingArticle;

// === Buttons === //
links.forEach(links => links.addEventListener("click", (event) => {
    btnForward.disabled = false;
    btnBack.disabled = true;
    articleNumber = 0;
    getRequestingArticle = event.target.innerHTML;
    displayNews(getRequestingArticle, currentDate, APIs.newsApi, articleNumber)
    console.log(event.target.innerHTML)
}))

// === "Enter" button === //
btn.addEventListener("click", () => {
    btnForward.disabled = false;
    btnBack.disabled = true;
    articleNumber = 0;
    getRequestingArticle = inputText.value;
    displayNews(getRequestingArticle, currentDate, APIs.newsApi, articleNumber)
})

// === InputText Request === //
inputText.addEventListener("keyup", (event) => {
    if (event.key == "Enter") {
        btnForward.disabled = false;
        btnBack.disabled = true;
        articleNumber = 0;
        getRequestingArticle = event.target.innerHTML;
        console.log(getRequestingArticle)
        displayNews(getRequestingArticle, currentDate, APIs.newsApi, articleNumber)
    }
})

btnBack.addEventListener("click", () => {
    if (articleNumber > 0) articleNumber--;

    (articleNumber > 0) ? btnBack.disabled = false : btnBack.disabled = true;
    (articleNumber > 4) ? btnForward.disabled = true : btnForward.disabled = false;

    displayNews(getRequestingArticle, currentDate, APIs.newsApi, articleNumber)
})


btnForward.addEventListener("click", () => {
    if (articleNumber < 4) articleNumber++;

    (articleNumber > 0) ? btnBack.disabled = false : btnBack.disabled = true;
    (articleNumber < 4) ? btnForward.disabled = false : btnForward.disabled = true;

    displayNews(getRequestingArticle, currentDate, APIs.newsApi, articleNumber)
})


async function displayNews(insertData, currentDate, apiUrl, articleNumb) {
    try {
        const response = await fetch(`https://newsapi.org/v2/everything?q=${insertData}&from=${currentDate}&sortBy=publishedAt&apiKey=${apiUrl}`)
        const data = await response.json();
        console.log(data)

        const { title, description, urlToImage } = data.articles[articleNumb];

        titleDisplay.innerHTML = title;
        descriptionDisplay.innerHTML = description;
        urltoImage.src = urlToImage;
    } catch (err) {
        console.log("Error to find article name.")
        titleDisplay.innerHTML = "Error to find article name.";
        descriptionDisplay.innerHTML = "";
        urltoImage.src = "";
        btnForward.disabled = true;
    }
}

const scrollPoint = document.querySelector("#customRange2");
scrollPoint.addEventListener("change", (event) => document.querySelector("#formLabel").innerHTML = event.target.value);