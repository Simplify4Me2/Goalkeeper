import { Component, Input, OnInit } from '@angular/core';
import { Fixture } from 'src/app/shared/models/fixture.model';

@Component({
  selector: 'app-match-day',
  templateUrl: './match-day.component.html',
  styleUrls: ['./match-day.component.sass']
})
export class MatchDayComponent implements OnInit {

  @Input() fixtures: Fixture[];

  constructor() { }

  ngOnInit(): void {
  }

}
