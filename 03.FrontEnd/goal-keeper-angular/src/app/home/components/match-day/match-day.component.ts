import {
  ChangeDetectionStrategy,
  Component,
  Input,
  OnInit,
} from '@angular/core';
import { Match } from 'src/app/shared/models/match.model';
import { Matchday } from '../../models/matchday.model';

@Component({
  selector: 'app-match-day',
  templateUrl: './match-day.component.html',
  styleUrls: ['./match-day.component.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MatchDayComponent implements OnInit {
  @Input() fixtures: Match[];
  @Input() matchday: Matchday;

  constructor() {}

  ngOnInit(): void {}

  getDistinctMatchDates(): string[] {
    return [...new Set(this.matchday.matches?.map((match) => match.date))];
  }

  getMatchesForDate(date: string): Match[] {
    return this.matchday.matches?.filter((match) => match.date === date);
  }
}
