import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { Matchday } from '../../models/matchday.model';
import { RequestResult } from 'src/app/shared/request-result';

@Injectable({
  providedIn: 'root',
})
export class MatchService {
  
  constructor(private http: HttpClient) {}

  getMatchday(day: number): Observable<RequestResult<Matchday>> {
    return this.http.get<RequestResult<Matchday>>(
      `https://localhost:5001/api/match/matchday/${day}`
    );
  }

  getLastMatchday(): Observable<RequestResult<Matchday>> {
    return this.http.get<RequestResult<Matchday>>(
      'https://localhost:5001/api/match/matchday/last'
    );
  }

  getUpcomingMatchday(day: number): Observable<RequestResult<Matchday>> {
    return this.http.get<RequestResult<Matchday>>(
      `https://localhost:5001/api/match/matchday/upcoming/${day}`
    );
  }
}
