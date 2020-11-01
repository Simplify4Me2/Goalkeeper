var express = require('express'),
    app = express(),
    port = process.env.PORT || 5000;
var cors = require('cors');

const corsOptions = {
    origin: 'http://localhost:3000',
    methods: [
        'GET'
    ],
    allowedHeaders: [
        'Content-Type'
    ]
};

app.use(cors(corsOptions));

app.listen(port);

console.log('RESTful API server started on: ' + port);

app.get("/url", (req, res, next) => {
    res.json(["Tony", "Lisa", "Michael", "Ginger", "Food"]);
});

app.get("/match", (req, res, next) => {
    res.json([
        { nr: 1, homeTeam: 'FC De Kampioenen', awayTeam: 'VK Heuvel Lo', homeScore: 3, awayScore: 1 },
        { nr: 2, homeTeam: 'RSC Anderlecht', awayTeam: 'STVV', homeScore: 2, awayScore: 2 },
        { nr: 3, homeTeam: 'Zulte Waregem', awayTeam: 'Cercle Brugge', homeScore: 4, awayScore: 0 },
        { nr: 4, homeTeam: 'RC Genk', awayTeam: 'OHL', homeScore: 0, awayScore: 1 }]);
});

app.get("/ranking", (req, res, next) => {
    res.json([
        { position: 1, team: 'Club Brugge', points: 70 },
        { position: 2, team: 'KAA Gent', points: 55 },
        { position: 3, team: 'Charleroi', points: 54 },
        { position: 4, team: 'Antwerp', points: 53 },
        { position: 5, team: 'Standard', points: 49 },
        { position: 6, team: 'KV Mechelen', points: 44 },
        { position: 7, team: 'KRC Genk', points: 44 },
        { position: 8, team: 'Anderlecht', points: 43 },
        { position: 9, team: 'Zulte Waregem', points: 36 },
        { position: 10, team: 'Excel Moeskroen', points: 36 },
        { position: 11, team: 'KV Kortrijk', points: 33 },
        { position: 12, team: 'STVV', points: 33 },
        { position: 13, team: 'KAS Eupen', points: 30 },
        { position: 14, team: 'Cercle Brugge', points: 23 },
        { position: 15, team: 'KV Oostende', points: 22 },
        { position: 16, team: 'Waasland-Beveren', points: 20 },
    ])
});