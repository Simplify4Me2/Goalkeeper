import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Match } from 'src/app/shared/models/match.model';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.container.html',
  styleUrls: ['./matches.container.sass']
})
export class MatchesContainerComponent implements OnInit {

  matches: Observable<Match[]>;

  fakeFixtures: Match[] = [{
    homeTeamId: 11, homeTeamName: 'Foo', homeTeamScore: 1, awayTeamId: 22, awayTeamName: 'Bar', awayTeamScore: 0, date: '2020-03-03'
  }];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.parent.snapshot.paramMap.get('id'));

    this.matches = of(this.fakeFixtures);
  }

}
