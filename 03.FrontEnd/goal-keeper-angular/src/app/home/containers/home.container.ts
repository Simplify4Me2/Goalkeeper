import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import { Fixture } from '../models/fixture.model';
import { getFixtures } from '../store/home.actions';
import * as fromHome from '../store';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.container.html',
  styleUrls: ['./home.container.sass'],
})
export class HomeComponent implements OnInit {
  fixtures: Observable<Fixture[]>;

  constructor(private store: Store) {}

  ngOnInit(): void {
      this.store.dispatch(getFixtures());
      this.fixtures = this.store.select(fromHome.selectFixtures);
      console.log('fixtures: ', this.fixtures);
  }
}
