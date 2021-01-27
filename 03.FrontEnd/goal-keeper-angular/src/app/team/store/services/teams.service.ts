import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Team } from '../../models';
import { RequestResult } from '../../../shared/request-result';

@Injectable({
    providedIn: 'root'
})
export class TeamsService {

    constructor(private http: HttpClient) {}

    getTeam(id: number): Observable<RequestResult<Team>> {
        return this.http.get<RequestResult<Team>>(`https://localhost:5001/api/team/${id}`);
    }
}