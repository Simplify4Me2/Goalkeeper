import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Ranking } from '../../models/ranking.model';
import { RequestResult } from '../../../shared/request-result';

@Injectable({
    providedIn: 'root'
})
export class RankingService {

    constructor(private http: HttpClient) {}

    ranking: Ranking = {
        competitionName: 'Jupiler Pro League',
        teamRankings: [
            { teamId: 5, teamName: 'Club Brugge', points: 72, gamesPlayed: 6 },
            { teamId: 98, teamName: 'KAA Gent', points: 59, gamesPlayed: 6 },
            { teamId: 65, teamName: 'Charleroi', points: 58, gamesPlayed: 6 },
            { teamId: 10, teamName: 'Antwerp', points: 56, gamesPlayed: 6 },
            { teamId: 23, teamName: 'Standard', points: 54, gamesPlayed: 6 },
            { teamId: 67, teamName: 'KV Mechelen', points: 51, gamesPlayed: 6 },
            { teamId: 29, teamName: 'KRC Genk', points: 51, gamesPlayed: 6 },
            { teamId: 58, teamName: 'Anderlecht', points: 50, gamesPlayed: 6 },
            { teamId: 11, teamName: 'Zulte Waregem', points: 49, gamesPlayed: 6 },
            { teamId: 39, teamName: 'Excel Moeskroen', points: 48, gamesPlayed: 6 },
            { teamId: 31, teamName: 'KV Kortrijk', points: 47, gamesPlayed: 6 },
            { teamId: 19, teamName: 'STVV', points: 46, gamesPlayed: 6 },
            { teamId: 44, teamName: 'KAS Eupen', points: 45, gamesPlayed: 6 },
            { teamId: 21, teamName: 'Cercle Brugge', points: 42, gamesPlayed: 6 },
            { teamId: 12, teamName: 'KV Oostende', points: 40, gamesPlayed: 6 },
            { teamId: 8, teamName: 'Waasland-Beveren', points: 40, gamesPlayed: 6 },
        ]
    }

    get(): Observable<RequestResult<Ranking>> {
        // this.http.get<RequestResult<Ranking>>('https://localhost:44393/api/team').subscribe(foo => {
        //     console.log(foo);
        // });
        // this.http.get<RequestResult<Ranking>>('https://localhost:5001/api/ranking').subscribe(foo => {
        //     console.log(foo);
        // });
        
        // return of(this.ranking);
        return this.http.get<RequestResult<Ranking>>('https://localhost:5001/api/ranking');
        // return this.http.get<Ranking>('https://localhost:44393/api/team');
    }
    // TODO: https://www.football-data.org/documentation/quickstart

    // get(): Observable<RequestResult<Ranking>> {
    //     return this.http.get<RequestResult<Ranking>>('https://localhost:44393/api/team');
    // }
}