import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Ranking } from '../../models/ranking.model';

@Injectable({
    providedIn: 'root'
})
export class RankingService {

    constructor(private http: HttpClient) {}

    ranking: Ranking = {
        teams: [
            { id: 5, name: 'Club Brugge' },
            { id: 98, name: 'KAA Gent' },
            { id: 65, name: 'Charleroi' },
            { id: 10, name: 'Antwerp' },
            { id: 23, name: 'Standard' },
            { id: 67, name: 'KV Mechelen' },
            { id: 29, name: 'KRC Genk' },
            { id: 58, name: 'Anderlecht' },
            { id: 11, name: 'Zulte Waregem' },
            { id: 39, name: 'Excel Moeskroen' },
            { id: 31, name: 'KV Kortrijk' },
            { id: 19, name: 'STVV' },
            { id: 44, name: 'KAS Eupen' },
            { id: 21, name: 'Cercle Brugge' },
            { id: 12, name: 'KV Oostende' },
            { id: 8, name: 'Waasland-Beveren' },
        ]
    }

    get(): Observable<Ranking> {
        this.http.get('localhost:5000/api/team').subscribe(foo => {
            console.log(foo);
        });
        return of(this.ranking);
    }
    // TODO: https://www.football-data.org/documentation/quickstart
}