import { Component, Input, OnInit } from '@angular/core';
import { Fixture } from '../../models/fixture.model';

@Component({
  selector: 'app-fixture',
  templateUrl: './fixture.component.html',
  styleUrls: ['./fixture.component.sass']
})
export class FixtureComponent implements OnInit {

  @Input() fixture: Fixture;

  constructor() { }

  ngOnInit(): void {
  }

}
