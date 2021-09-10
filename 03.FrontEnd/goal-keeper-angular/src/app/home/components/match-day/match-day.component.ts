import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import moment from 'moment';

import { Match } from 'src/app/shared/models/match.model';
import { Matchday } from '../../models/matchday.model';

@Component({
  selector: 'app-match-day',
  templateUrl: './match-day.component.html',
  styleUrls: ['./match-day.component.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MatchDayComponent implements OnInit {
  @Input() matchday: Matchday;

  @Output() navigateMatchday = new EventEmitter<number>();

  constructor() {}

  ngOnInit(): void {}

  getDistinctMatchDates(): string[] {
    return [...new Set(this.matchday.matches?.map((match) => moment(match.date).format('DD/MM')))];
  }

  getMatchesForDate(date: string): Match[] {
    return this.matchday.matches?.filter((match) => moment(match.date).format('DD/MM') === date);
  }

  leftClick() {
    !this.matchday.isOpeningMatchday &&
      this.navigateMatchday.emit(this.matchday.day - 1);
  }

  rightClick() {
    if (!this.matchday.isClosingMatchday)
      this.navigateMatchday.emit(this.matchday.day + 1);
  }
}
