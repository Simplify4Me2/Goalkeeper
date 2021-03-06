import { Component, Input, OnInit } from '@angular/core';
import { Player } from '../../models';

@Component({
  selector: 'app-team-goals-stats',
  templateUrl: './team-goals-stats.component.html',
  styleUrls: ['./team-goals-stats.component.sass']
})
export class TeamGoalsStatsComponent implements OnInit {

  @Input() players: Player[];

  constructor() { }

  ngOnInit(): void {
  }

}
