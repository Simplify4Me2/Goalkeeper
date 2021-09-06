import { Component, Input, OnInit } from '@angular/core';
import { Match } from '../../models/match.model';

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.sass']
})
export class MatchComponent implements OnInit {

  @Input() match: Match;

  constructor() { }

  ngOnInit(): void {
  }

}
