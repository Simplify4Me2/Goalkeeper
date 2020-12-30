import { Component, Input, OnInit } from '@angular/core';

import { Player } from '../../models';

@Component({
  selector: 'app-team-players',
  templateUrl: './team-players.component.html',
  styleUrls: ['./team-players.component.sass']
})
export class TeamPlayersComponent implements OnInit {

  @Input() players: Player[];

  constructor() { }

  ngOnInit(): void {
  }

}
