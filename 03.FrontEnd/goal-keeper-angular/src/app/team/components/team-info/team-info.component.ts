import {
  ChangeDetectionStrategy,
  Component,
  Input,
  OnInit,
} from '@angular/core';
import { Team } from '../../../home/models/team.model';

@Component({
  selector: 'app-team-info',
  templateUrl: './team-info.component.html',
  styleUrls: ['./team-info.component.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TeamInfoComponent implements OnInit {
  @Input() team: Team;

  mockStadiumName: string = 'Bosuilstadion';

  constructor() {}

  ngOnInit(): void {
    // console.log(this.team);
  }

  getTeamBackground(teamName: string) {
    // console.log(teamName.replace(/\s+/g, ''));
    // console.log(teamName === 'Royal Antwerp FC');
    console.log(teamName);
    // return {
    //   btn: true,
    //   'btn-primary': true,
    //   'btn-extra-class': this.stateFlag,
    // };
    return {
      'team-background': true,
      'antwerp': teamName === 'Royal Antwerp FC',
      'anderlecht': teamName === 'RSC Anderlecht',
      'beerschot': teamName === 'Beerschot VA',
      'cercle-brugge': teamName === 'Cercle Brugge',
      'charleroi': teamName === 'Royal Charleroi Sporting Club',
      'club-brugge': teamName === 'Club Brugge',
      'eupen': teamName === 'KAS Eupen',
      'genk': teamName === 'KRC Genk',
      'gent': teamName === 'KAA Gent',
      'kortrijk': teamName === 'KV Kortrijk',
      'mechelen': teamName === 'KV Mechelen',
      'ohl': teamName === 'Oud-Heverlee Leuven',
      'oostende': teamName === 'KV Oostende',
      'seraing': teamName === 'RFC Seraing',
      'standard': teamName === 'Standard Luik',
      'stvv': teamName === 'Sint-Truidense VV',
      'union': teamName === 'Union',
      'zulte-waregem': teamName === 'SV Zulte Waregem'
    };
  }
}
