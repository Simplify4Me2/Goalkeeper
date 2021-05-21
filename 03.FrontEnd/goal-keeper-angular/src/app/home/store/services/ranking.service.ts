import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Ranking } from '../../models/ranking.model';
import { Team } from '../../models/team.model';
import { RequestResult } from '../../../shared/request-result';

@Injectable({
    providedIn: 'root'
})
export class RankingService {

    constructor(private http: HttpClient) {}

    ranking: Ranking = {
        competitionName: 'Jupiler Pro League',
        teamRankings: [
            { teamId: 5, teamName: 'Club Brugge', points: 72 },
            { teamId: 98, teamName: 'KAA Gent', points: 59 },
            { teamId: 65, teamName: 'Charleroi', points: 58 },
            { teamId: 10, teamName: 'Antwerp', points: 56 },
            { teamId: 23, teamName: 'Standard', points: 54 },
            { teamId: 67, teamName: 'KV Mechelen', points: 51 },
            { teamId: 29, teamName: 'KRC Genk', points: 51 },
            { teamId: 58, teamName: 'Anderlecht', points: 50 },
            { teamId: 11, teamName: 'Zulte Waregem', points: 49 },
            { teamId: 39, teamName: 'Excel Moeskroen', points: 48 },
            { teamId: 31, teamName: 'KV Kortrijk', points: 47 },
            { teamId: 19, teamName: 'STVV', points: 46 },
            { teamId: 44, teamName: 'KAS Eupen', points: 45 },
            { teamId: 21, teamName: 'Cercle Brugge', points: 42 },
            { teamId: 12, teamName: 'KV Oostende', points: 40 },
            { teamId: 8, teamName: 'Waasland-Beveren', points: 40 },
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