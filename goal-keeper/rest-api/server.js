var express = require('express'),
    app = express(),
    port = process.env.PORT || 5000;
var cors = require('cors');

const corsOptions = {
    origin: 'http://localhost:4200',
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