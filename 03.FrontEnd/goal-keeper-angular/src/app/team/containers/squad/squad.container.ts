import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Player } from '../../models';

@Component({
  selector: 'app-players',
  templateUrl: './squad.container.html',
  styleUrls: ['./squad.container.sass']
})
export class SquadContainerComponent implements OnInit {

  players: Player[] = [
    { id: 1, position: 'GK', shirtNumber: 1, firstName: 'Michel', lastName: `Preud'Homme` }
  ];
  players$: Observable<Player[]> = of(this.players);

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.parent.snapshot.paramMap.get('id'));
  }

}
