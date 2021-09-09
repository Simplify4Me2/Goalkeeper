import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Ranking } from '../../models/ranking.model';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RankingComponent implements OnInit {

  @Input() ranking: Ranking;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
}
