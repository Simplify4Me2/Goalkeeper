import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Match } from 'src/app/shared/models/match.model';

@Component({
  selector: 'app-fixtures',
  templateUrl: './fixtures.container.html',
  styleUrls: ['./fixtures.container.sass']
})
export class FixturesContainerComponent implements OnInit {

  fixtures: Observable<Match[]>;

  fakeFixtures: Match[] = [{
    homeTeamId: 11, homeTeam: 'Foo', homeScore: 1, awayTeamId: 22, awayTeam: 'Bar', awayScore: 0, date: '2020-03-03'
  }];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.parent.snapshot.paramMap.get('id'));

    this.fixtures = of(this.fakeFixtures);
  }

}
