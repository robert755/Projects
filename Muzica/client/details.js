

var descriptions = {
    "Radical Optimism": "Radical Optimism is Dua Lipa’s long-awaited third studio album.The sound of Radical Optimism is described as ‘70s-type psychedelic pop",
    "Melodrama": "Melodrama is New Zealand singer Lorde’s sophomore album, released on June 16, 2017 via Lava and Republic Records.The album’s cover was painted by Brooklyn artist Sam McKinniss, who was initially approached by Lorde over the rest of his work. They became friends, and Lorde eventually commissioned McKinniss for the piece.",
    "After Hours":"After Hours is The Weeknd’s fourth studio album. It was released on March 20, 2020, to critical acclaim, with some calling it his best work to date. The album contains themes surrounding loneliness, heartbreak, withdrawal, infidelity, and recklessness."
    
};

// Obține parametrii din URL pentru album, artist și preț, precum și pentru imagine
var params = new URLSearchParams(window.location.search);
var album = params.get('album');
var artist = params.get('artist');
var price = params.get('price');
var image = 'images/' + album.trim() + '.png'; // Assume că imaginile au aceleași nume ca și numele albumului, dar în litere mici și cu extensia .jpg

// Obține descrierea pentru albumul selectat
var description = descriptions[album];

// Obține elementele HTML pentru album, artist, preț și imagine
var albumElement = document.getElementById("album");
var artistElement = document.getElementById("artist");
var priceElement = document.getElementById("price");
var imageElement = document.createElement("img"); // Creează un element imagine
var descriptionElement = document.createElement("div"); // Creează un element pentru descriere
// Adaugă clasa "description" la elementul pentru descriere
descriptionElement.classList.add("description");
imageElement.classList.add("image")
// Introdu dinamic valorile în elementele HTML
albumElement.textContent = album;
artistElement.textContent = artist;
priceElement.textContent = price;
imageElement.src = image; // Setează sursa imaginii
descriptionElement.textContent = description; // Setează descrierea

// Adaugă imaginea și descrierea la div-ul pentru imagine
document.body.appendChild(imageElement);
document.body.appendChild(descriptionElement);

