import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class RankingsService {
    ranking = [
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
      ];

    get(): Observable<any> {
        return of(this.ranking);
    }
    // TODO: https://www.football-data.org/documentation/quickstart
}