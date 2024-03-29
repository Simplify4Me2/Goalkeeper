import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { fakeAsync, inject, TestBed } from '@angular/core/testing';

import { RequestResult } from 'src/app/shared/request-result';
import { Team } from '../../models';
import { TeamsService } from './teams.service';

describe('TeamsService', () => {

    let httpTestingController: HttpTestingController;
    let teamsService: TeamsService;
    let teamStub: RequestResult<Team>;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule]
        });

        httpTestingController = TestBed.inject(HttpTestingController);
        teamStub = {
            data: {
                id: 3,
                name: 'FC De Kampioenen',
                stadiumName: 'DDT Ok Cars',
                players: []
            },
            messages: []
        };
    });

    beforeEach(inject([TeamsService], (service: TeamsService) => {
        teamsService = service;
    }));

    it('should return data', fakeAsync(() => {
        const teamName = 'FC De Kampioenen';
        let result: RequestResult<Team>;
        teamsService.getTeam(teamName).subscribe(r => {
            result = r;
        });
        const req = httpTestingController.expectOne({
            method: 'GET',
            url: `https://localhost:5001/api/team/${teamName}`
        });

        req.flush(teamStub);

        expect(result).toEqual(teamStub);
    }));
    
});