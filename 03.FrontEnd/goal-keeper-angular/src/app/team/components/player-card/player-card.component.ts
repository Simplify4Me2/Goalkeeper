import { Component, Input, OnInit } from '@angular/core';
import { Player } from '../../models';

@Component({
  selector: 'app-player-card',
  templateUrl: './player-card.component.html',
  styleUrls: ['./player-card.component.sass']
})
export class PlayerCardComponent implements OnInit {

  @Input() player: Player;

  constructor() { }

  ngOnInit(): void {
  }

}
