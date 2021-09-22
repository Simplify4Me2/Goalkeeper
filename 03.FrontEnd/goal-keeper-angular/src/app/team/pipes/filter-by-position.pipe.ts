import { Pipe, PipeTransform } from '@angular/core';
import { Player } from '../models';

@Pipe({
  name: 'filterByPosition'
})
export class FilterByPositionPipe implements PipeTransform {

  transform(players: Player[], position: string): unknown {
    return players.filter(player => player.position === position);
  }

}
