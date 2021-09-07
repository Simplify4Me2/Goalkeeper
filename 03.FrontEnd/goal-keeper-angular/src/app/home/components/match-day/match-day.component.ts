import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
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
  @Input() matchday: Matchday;

  @Output() navigateMatchday = new EventEmitter<number>();

  constructor() {}

  ngOnInit(): void {}

  getDistinctMatchDates(): string[] {
    return [...new Set(this.matchday.matches?.map((match) => match.date))];
  }

  getMatchesForDate(date: string): Match[] {
    return this.matchday.matches?.filter((match) => match.date === date);
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
