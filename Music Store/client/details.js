

var descriptions = {
    
    "Melodrama": "Melodrama is New Zealand singer Lorde’s sophomore album, released on June 16, 2017 via Lava and Republic Records. Inspired in part by the “emotions and insights” gained after her breakup with longtime boyfriend James Lowe, Lorde calls Melodrama “a record about being alone… The good parts and the bad parts”.Lead single “Green Light” was released on March 2, 2017, following a mysterious marketing campaign culminating in a seven-second preview of the song. The second single “Liability” was released on March 9, 2017 without any publicity or promotion. The piano-driven ballad showcases a softer side of Lorde as she opens up about a more personal time in her life. Lorde whispered the album’s title to her mother in her car in 2015.The album’s cover was painted by Brooklyn artist Sam McKinniss, who was initially approached by Lorde over the rest of his work. They became friends, and Lorde eventually commissioned McKinniss for the piece.The album cover is all about her—it’s all about her album and her vision—but she caught me at a really special time for my work…we chatted a lot and I listened to some demos of some early songs, which were really great and exciting and fresh…there were some youthful, nighttime attitudes she was really chasing after and really trying to get into the songs. So what she asked me to do was to meet her [at her studio] and create a kind of colorful teenage restlessness and excitement and energy and potential—to put that into color and put it in my hands.—McKinnis in W Magazine",
    "After Hours":"After Hours is The Weeknd’s fourth studio album. It was released on March 20, 2020, to critical acclaim, with some calling it his best work to date. The album contains themes surrounding loneliness, heartbreak, withdrawal, infidelity, and recklessness.",
    "For All The Dogs":"For All The Dogs is Canadian native Drake’s eighth full-length studio album, following his June 2022 house-based, Honestly, Nevermind, and the 21 Savage collaborative album Her Loss that released in November 2022.The album was teased following the announcement of Drake’s new book, Titles Ruin Everything, on June 24, 2023.",
    "AM":"Featuring the singles “R U Mine?,” “Do I Wanna Know?,” “Why’d You Only Call Me When You’re High?,” “One for the Road,” “Arabella,” and “Snap Out of It,” the album received widespread critical acclaim. It was nominated for the 2013 Mercury Prize for ‘Best Album,’ hailed the Best Album of 2013 by NME magazine, and featured at number 449 on NME’s list of the 500 Greatest Albums of All Time.",
    "The Slow Rush":"The Slow Rush is Tame Impala’s fourth studio album, released on February 14, 2020. The album is centered around the theme and concept of time and how it can both take and give things throughout the progression of one’s life.ame Impala released four singles before the album’s release including “Borderline,” released on April 12, 2019, “It Might Be Time,” released on October 28, 2019, “Posthumous Forgiveness,” released on December 3, 2019, and “Lost In Yesterday,” released on January 8, 2020. However, the single version of “Borderline” was not included in the final version of the record, as the track was reworked by Kevin for the final track listing of The Slow Rush.",
    "HIT ME HARD AND SOFT":"HIT ME HARD AND SOFT is Billie Eilish’s third album, released May 17, 2024 through Interscope Records.A description of the album on her website speaks to its title:[HIT ME HARD AND SOFT] does exactly as the title suggests; hits you hard and soft both lyrically and sonically, while bending genres and defying trends along the way.",
    "Nevermind":"Nirvana’s second album, Nevermind, was the impetus for rock music to resurge on the charts, then dominated by pop stars; it replaced Michael Jackson’s Dangerous for the top spot on the Billboard 200 in January of 1992, four months after its release.Featuring new drummer Dave Grohl and production by Butch Vig—who became highly requested and formed his own band afterward, called Garbage—the project contained much more well-developed material than June 1989’s Bleach, while conveying a level of angst that every Generation X-er could identify with.The surprise success of Nevermind, with over 24 million copies sold worldwide, also brought a spotlight to both Seattle—home of other grunge bands such as Pearl Jam, Soundgarden, and Alice in Chains—and alternative rock as a whole. This helped propel bands like the Smashing Pumpkins and Green Day from the underground to global superstardom.The album has been featured on several “best of” lists, including being named as the best album of the 1990s by Rolling Stone, Associated Press, and Spin magazine.",
     "Californication":"This song is mainly about the dark side of Hollywood that lies underneath the glossy surface. The band might love the city of Los Angeles, but they saw firsthand the effects the Hollywood lifestyle has on its inhabitants and the rest of the world. The song, particularly John Frusciante’s guitar work, sounds different from the rest of the album. That is because the band originally planned to scrap the song because they couldn’t find the music to match Kiedis' lyrics, but Anthony encouraged Frusciante to get creative because he knew they could be dealing with a great song"
};


var params = new URLSearchParams(window.location.search);
var album = params.get('album');
var artist = params.get('artist');
var price = params.get('price');
var image = 'images/' + album.trim() + '.png'; 

var description = descriptions[album];

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

