import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class RankingsService {
    ranking = [
        { position: 1, team: 'Anderlecht', points: 70 },
        { position: 2, team: 'Zulte Waregem', points: 55 },
        { position: 3, team: 'Sporting Charleroi', points: 54 },
        { position: 4, team: 'Sporting Charleroi', points: 41 },
      ];

    get(): Observable<any> {
        return of(this.ranking);
    }

}