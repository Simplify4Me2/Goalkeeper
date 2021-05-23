import { fakeAsync, inject, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { Ranking } from '../../models/ranking.model';
import { RankingService } from './ranking.service';
import { RequestResult } from 'src/app/shared/request-result';

describe('RankingService', () => {

    let httpTestingController: HttpTestingController;
    let rankingService: RankingService;
    let rankingStub: RequestResult<Ranking>;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule]
        });

        httpTestingController = TestBed.inject(HttpTestingController);
        rankingStub = {
            data: {
                competitionName: 'Test competition name',
                teamRankings: [{ teamId: 1, teamName: 'Test Team', points: 0 }]
            },
            messages: []
        };
    });

    beforeEach(inject(
        [RankingService],
        (service: RankingService) => {
            rankingService = service;
        }));

    it('should return data', fakeAsync(() => {
        let result: RequestResult<Ranking>;
        rankingService.get().subscribe(r => {
            result = r;
        });
        const req = httpTestingController.expectOne({
            method: 'GET',
            url: 'https://localhost:5001/api/ranking'
        });

        req.flush(rankingStub);

        expect(result).toEqual(rankingStub);
    }));
});