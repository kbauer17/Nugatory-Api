window.addEventListener('load', (event) => {
    getData("/api/word");
});

// get initial data from db using AJAX
function getData(url) {
    fetch(url)
        .then(response => response.json())
        .then(data => {
            showData(data);
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
        });
}

function showData(data) {
    for (let i = 0; i < data.length; i++){
        console.log(data[i]);
    }
}