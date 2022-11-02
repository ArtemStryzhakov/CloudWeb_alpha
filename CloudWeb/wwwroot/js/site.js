const api = "fd3ea34bb5eb7ae4faae0c8095446b88";

(async function getApiData(api) {
    const getData = await fetch(`https://api.openweathermap.org/data/2.5/weather?q=Tallinn&units=metric&appid=${api}`)
    const data = await getData.json();
    console.log(data)

    const { icon } = data.weather[0];
    const { temp } = data.main;

    console.info(icon)

    document.querySelector("#temp").innerHTML = `${temp}°C`;
    document.querySelector("#image").src = `https://openweathermap.org/img/wn/${icon}.png`;
})(api)

// document.querySelector("#temp").innerHTML = "16C"