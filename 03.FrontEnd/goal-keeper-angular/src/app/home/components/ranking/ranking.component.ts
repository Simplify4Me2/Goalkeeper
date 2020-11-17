import { Component, Input, OnInit } from '@angular/core';

import { Ranking } from '../../models/ranking.model';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.sass']
})
export class RankingComponent implements OnInit {

  @Input() rankings: Ranking[];

  // rankings: Ranking[] = [{ position: 1, team: 'onwheel', points: 5 }, { position: 1, team: 'onwheel', points: 5 }]

  constructor() { }

  ngOnInit(): void {
  }

}
