import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class RankingsService {
    ranking = [
        { position: 1, team: { id: 5, name: 'Club Brugge'}, points: 70 },
        { position: 2, team: { id: 98, name: 'KAA Gent' }, points: 55 },
        { position: 3, team: { id: 65, name: 'Charleroi' }, points: 54 },
        { position: 4, team: { id: 10, name: 'Antwerp' }, points: 53 },
        { position: 5, team: { id: 23, name: 'Standard' }, points: 49 },
        { position: 6, team: { id: 67, name: 'KV Mechelen' }, points: 44 },
        { position: 7, team: { id: 29, name: 'KRC Genk' }, points: 44 },
        { position: 8, team: { id: 58, name: 'Anderlecht' }, points: 43 },
        { position: 9, team: { id: 11, name: 'Zulte Waregem' }, points: 36 },
        { position: 10, team: { id: 39, name: 'Excel Moeskroen' }, points: 36 },
        { position: 11, team: { id: 31, name: 'KV Kortrijk' }, points: 33 },
        { position: 12, team: { id: 19, name: 'STVV' }, points: 33 },
        { position: 13, team: { id: 44, name: 'KAS Eupen' }, points: 30 },
        { position: 14, team: { id: 21, name: 'Cercle Brugge' }, points: 23 },
        { position: 15, team: { id: 12, name: 'KV Oostende' }, points: 22 },
        { position: 16, team: { id: 8, name: 'Waasland-Beveren' }, points: 20 },
      ];

    get(): Observable<any> {
        return of(this.ranking);
    }
    // TODO: https://www.football-data.org/documentation/quickstart
}