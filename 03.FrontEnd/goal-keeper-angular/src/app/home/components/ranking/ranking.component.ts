import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Team } from 'src/app/home/models/team.model';

import { Ranking } from '../../models/ranking.model';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.sass']
})
export class RankingComponent implements OnInit {

  @Input() ranking: Ranking;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
}
