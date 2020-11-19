import { Component, Input, OnInit } from '@angular/core';

import { Ranking } from '../../models/ranking.model';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.sass']
})
export class RankingComponent implements OnInit {

  @Input() rankings: Ranking[];

  constructor() { }

  ngOnInit(): void {
  }

  selectTeam() {
    console.log('Team selected');
  }

}
