import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Fixture } from 'src/app/shared/models/fixture.model';

@Component({
  selector: 'app-fixtures',
  templateUrl: './fixtures.container.html',
  styleUrls: ['./fixtures.container.sass']
})
export class FixturesContainerComponent implements OnInit {

  fixtures: Observable<Fixture[]>;

  fakeFixtures: Fixture[] = [{
    homeTeam: 'Foo', homeScore: 1, awayTeam: 'Bar', awayScore: 0
  }];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.parent.snapshot.paramMap.get('id'));

    this.fixtures = of(this.fakeFixtures);
  }

}
