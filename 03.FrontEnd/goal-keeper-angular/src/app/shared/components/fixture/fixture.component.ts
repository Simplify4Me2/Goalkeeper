import { Component, Input, OnInit } from '@angular/core';
import { Match } from '../../models/match.model';

@Component({
  selector: 'app-fixture',
  templateUrl: './fixture.component.html',
  styleUrls: ['./fixture.component.sass']
})
export class FixtureComponent implements OnInit {

  @Input() match: Match;

  constructor() { }

  ngOnInit(): void {
  }

}
