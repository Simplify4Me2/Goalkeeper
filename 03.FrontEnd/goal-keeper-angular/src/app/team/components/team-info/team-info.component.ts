import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Team } from '../../../home/models/team.model';

@Component({
  selector: 'app-team-info',
  templateUrl: './team-info.component.html',
  styleUrls: ['./team-info.component.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TeamInfoComponent implements OnInit {

  @Input() team: Team;

  constructor() { }

  ngOnInit(): void {
    // console.log(this.team);
  }

}
