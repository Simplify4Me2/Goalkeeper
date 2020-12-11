import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Team } from '../../../shared/models/team.model';

@Injectable({
    providedIn: 'root'
})
export class TeamsService {
    teams = {
      5:   {
        id: 5,
        name: 'Club Brugge'
    },
    98: {
        id: 98,
        name: 'KAA Gent'
    },
    65: {
        id: 65,
        name: 'Charleroi'
    },
    10: {
        id: 10,
        name: 'Antwerp'
    },
    23: {
        id: 23,
        name: 'Standard'
    },
    67: {
        id: 67,
        name: 'KV Mechelen'
    },
    29: {
        id: 29,
        name: 'KRC Genk'
    },
    58: {
        id: 58,
        name: 'Anderlecht'
    },
    11: {
        id: 11,
        name: 'Zulte Waregem'
    },
    39: {
        id: 39,
        name: 'Excel Moeskroen'
    },
    31: {
        id: 31,
        name: 'KV Kortrijk'
    },
    19: {
        id: 19,
        name: 'STVV'
    },
    44: {
        id: 44,
        name: 'KAS Eupen'
    },
    21: {
        id: 21,
        name: 'Cercle Brugge'
    },
    12: {
        id: 12,
        name: 'KV Oostende'
    },
    8: {
        id: 8,
        name: 'Waasland-Beveren'
    },
    }

    get(id: number): Observable<Team> {
        return of(this.teams[id]);
    }
}