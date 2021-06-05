import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { Match } from '../../../shared/models/match.model';
import { Matchday } from '../../models/matchday.model';
import { RequestResult } from 'src/app/shared/request-result';

@Injectable({
  providedIn: 'root',
})
export class MatchService {
  fixtures: Match[] = [
    {
      homeTeamId: 1,
      homeTeamName: 'Oud-Heverlee Leuven',
      homeTeamScore: 0,
      awayTeamId: 2,
      awayTeamName: 'Anderlecht',
      awayTeamScore: 1,
      date: '2020-01-01',
    },
    {
      homeTeamId: 3,
      homeTeamName: 'Club Brugge',
      homeTeamScore: 4,
      awayTeamId: 4,
      awayTeamName: 'Zulte Waregem',
      awayTeamScore: 1,
      date: '2020-02-02',
    },
    {
      homeTeamId: 5,
      homeTeamName: 'KRC Genk',
      homeTeamScore: 2,
      awayTeamId: 6,
      awayTeamName: 'Sporting Charleroi',
      awayTeamScore: 4,
      date: '2020-03-03',
    },
  ];

  matchday: Matchday = {
    day: 12,
    matches: [],
  };

  constructor(private http: HttpClient) {}

  get(): Observable<Match[]> {
    return of(this.fixtures);
  }

  getLastMatchday(): Observable<RequestResult<Matchday>> {
    // return of(this.matchday);
    return this.http.get<RequestResult<Matchday>>(
      'https://localhost:5001/api/match/matchday/last'
    );
  }
}
