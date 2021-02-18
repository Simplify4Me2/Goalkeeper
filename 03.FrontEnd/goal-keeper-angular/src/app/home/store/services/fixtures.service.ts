import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { Fixture } from '../../../shared/models/fixture.model';

@Injectable({
    providedIn: 'root'
})
export class FixturesService {
    fixtures: Fixture[] = [
        { homeTeam: 'OHL', homeScore: 0, awayTeam: 'Anderlecht', awayScore: 1 },
        { homeTeam: 'Club Brugge', homeScore: 4, awayTeam: 'Zulte Waregem', awayScore: 1 },
        { homeTeam: 'KRC Genk', homeScore: 2, awayTeam: 'Sporting Charleroi', awayScore: 4 },
      ];

    // constructor(private http: HttpClient) { }

    get(): Observable<Fixture[]> {
        return of(this.fixtures);
    }

}