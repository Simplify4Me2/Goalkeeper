import { Component, Input, OnInit } from '@angular/core';
import { Match } from 'src/app/shared/models/match.model';
import { Matchday } from '../../models/matchday.model';
import * as moment from 'moment';

@Component({
  selector: 'app-match-day',
  templateUrl: './match-day.component.html',
  styleUrls: ['./match-day.component.sass']
})
export class MatchDayComponent implements OnInit {

  @Input() fixtures: Match[];
  @Input() matchday: Matchday;

  constructor() { }

  ngOnInit(): void {
  }

  click() {
    console.log('Dada: ', this.matchday.matches[0].date);
    const foo = moment(this.matchday.matches[0].date);
    console.log('Dada: ', foo.format('DD/MM'));
  }

}
