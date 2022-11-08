const APIs = {
    weatherApi: "fd3ea34bb5eb7ae4faae0c8095446b88",
    newsApi: "d1cb154147684011afda58be32a45cf9"
};

// ===== WEATHER ===== //

(async function getApiData(api) {
    const getData = await fetch(`https://api.openweathermap.org/data/2.5/weather?q=Tallinn&units=metric&appid=${api}`)
    const data = await getData.json();

    const { icon } = data.weather[0];
    const { temp } = data.main;

    document.querySelector("#temp").innerHTML = `${temp.toFixed(0)}°C`;
    document.querySelector("#image").src = `https://openweathermap.org/img/wn/${icon}.png`;
})(APIs.weatherApi)

// ===== NEWS ===== //

const currentDate = new Date().toJSON().slice(0, 10).replace(/-/g, '/');

const titleDisplay = document.querySelector("#title");
const descriptionDisplay = document.querySelector("#description");
const urlToImageDisplay = document.querySelector("#urltoImage");

const inputText = document.querySelector("#inputText");
const btn = document.querySelector("#btn");

let articleNumber = 0;

const btnBack = document.querySelector("#back");
const btnForward = document.querySelector("#forward");

[btnBack.disabled, btnForward.disabled] = [true, true];

// ===================================================//

btn.addEventListener("click", () => {
    btnForward.disabled = false;
    displayNews(inputText.value, currentDate, APIs.newsApi, articleNumber)
})

btnBack.addEventListener("click", () => {
    if (articleNumber > 0) {
        articleNumber--;
    } 

    if (articleNumber > 0) {
        btnBack.disabled = false;
    } else {
        btnBack.disabled = true;
    }

    if (articleNumber > 4) {
        btnForward.disabled = true;
    } else {
        btnForward.disabled = false;
    }
    displayNews(inputText.value, currentDate, APIs.newsApi, articleNumber)
})


btnForward.addEventListener("click", () => {
    if (articleNumber < 4) {
        articleNumber++
    }

    if (articleNumber > 0) {
        btnBack.disabled = false;
    } else {
        btnBack.disabled = true;
    }

    if (articleNumber < 4) {
        btnForward.disabled = false;
    } else {
        btnForward.disabled = true;
    }
    displayNews(inputText.value, currentDate, APIs.newsApi, articleNumber)
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
    }
}

const list = document.querySelector("#listOfCategories");

for (const items in list) {
    console.log(list.children[items].lastChild.innerHTML)
}
//console.log(list[0].lastChild.innerHTML)
