//var key = 'ZIi8ZAGyb3g3xh5ixf1SN8WBwTbkB6lEstdeqEbb'



'use strict';
const app =
{
    rover: document.getElementById('rover'),
   
    button1: document.getElementById('button1'),
    button2: document.getElementById('button2'),
    button3: document.getElementById('button3'),
    home: document.getElementById('home'),
    buttons: [button1, button2, button3, home]
}

getRover();

app.home.addEventListener('click', function () {
    app.rover.innerHTML = ` <h2>Välkommen till Uddebos rymdförening</h2>
        <h3>
            I den första versionen av våran hemsidan kan ni kika på bilder ifrån NASAS landfarkoster på mars!
            Dessa kallas för "rovers" och i menyn ovanför hittar ni Spirit, Opportunity samt Curiosity
        </h3> `
})


function getRover() {
    fetch('api/rover')
        .then(resp => resp.json())
        .then(data => showRovers(data))
        
}

function showRovers(data) {

    for (var i = 0; i < data.length; i++) {
        let rover = data[i];
        let name = rover.name;
        let id = rover.id;
        let button = app.buttons[i];
        button.innerHTML = name;
        button.id = id;
        button.addEventListener('click', function () {
            getRoverById(id);
        })
    }
}

function getRoverById(id) {
    fetch('api/rover/' + id)
        .then(resp => resp.json())
        .then(data => showDescription(data))
        
}

function showPhotos(data) {
    app.rover.innerHTML = '';
    for (var i = 0; i < data.photos.length; i++) {

        let objectURL = data.photos[i].img_src;

        let picture = document.createElement('img');
        picture.src = objectURL;
        app.rover.insertAdjacentElement('afterbegin', picture)
    }
}

function getPictures(name, id) {
    fetch('https://api.nasa.gov/mars-photos/api/v1/rovers/' + name + '/photos?sol=739&page=' + id + '&api_key=ZIi8ZAGyb3g3xh5ixf1SN8WBwTbkB6lEstdeqEbb')
        .then(resp => resp.json())
        .then(data => showPhotos(data))
        
}


function showDescription(data) {
    app.rover.innerHTML = '';
    app.rover.innerHTML = `<div id="Pictures"><img src="Images/` + data.name + `.jpg"/></div><div id="descriptions"<p>` + data.description + `</p></div><button id="photobutton">Bilder</button>`;
    const photobutton = document.getElementById('photobutton');
    photobutton.addEventListener('click', function () {
        getPictures(data.name, data.id);
    })
}


