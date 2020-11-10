import { Component, OnInit } from '@angular/core';
import { Fixture } from './fixture.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass'],
})
export class HomeComponent implements OnInit {
  fixtures: Fixture[] = [
    { homeTeam: 'OHL', homeScore: 0, awayTeam: 'Anderlecht', awayScore: 1 },
    { homeTeam: 'Club Brugge', homeScore: 4, awayTeam: 'Zulte Waregem', awayScore: 1 },
  ];

  constructor() {}

  ngOnInit(): void {}
}
