import { Component, Input, OnInit } from '@angular/core';
import { Player } from '../../models';

@Component({
  selector: 'app-team-cards-stats',
  templateUrl: './team-cards-stats.component.html',
  styleUrls: ['./team-cards-stats.component.sass']
})
export class TeamCardsStatsComponent implements OnInit {

  @Input() players: Player[];

  constructor() { }

  ngOnInit(): void {
  }

}
