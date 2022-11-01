const date = new Date();
const time = `${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`;

const timer = () => {
    setInterval(() => {
        console.log(time)
    }, 1000)
}