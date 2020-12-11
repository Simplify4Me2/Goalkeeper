import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Team } from '../../models/team.model';

@Injectable({
    providedIn: 'root'
})
export class TeamsService {
    team: Team = {
        Name: 'SV Zulte Waregem'
    }

    get(): Observable<Team> {
        return of(this.team);
    }
}