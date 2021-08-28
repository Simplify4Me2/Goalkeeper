import {
  ChangeDetectionStrategy,
  Component,
  Input,
  OnInit,
} from '@angular/core';
import { Team } from '../../models/team.model';

@Component({
  selector: 'app-team-info',
  templateUrl: './team-info.component.html',
  styleUrls: ['./team-info.component.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TeamInfoComponent implements OnInit {
  @Input() team: Team;

  mockStadiumName: string = 'Bosuilstadion';

  form: Form = {
    previousMatch: 'L',
    twoMatchesAgo: 'W',
    threeMatchesAgo: 'D',
    fourMatchesAgo: 'W'
  };

  constructor() {}

  ngOnInit(): void {
  }

  getTeamBackgroundClass(teamName: string) {
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

  getTeamFormClass(teamName: string) {
    // return {
    //   btn: true,
    //   'btn-primary': true,
    //   'btn-extra-class': this.stateFlag,
    // };
    return {
      'team-form': true,
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

interface Form {
  previousMatch: string;
  twoMatchesAgo: string;
  threeMatchesAgo: string;
  fourMatchesAgo: string;
}
