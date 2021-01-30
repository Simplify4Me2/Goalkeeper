import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Player } from '../../models';
import { selectPlayers } from '../../store';

@Component({
  selector: 'app-players',
  templateUrl: './squad.container.html',
  styleUrls: ['./squad.container.sass']
})
export class SquadContainerComponent implements OnInit {

  players: Observable<Player[]>;

  constructor(private store: Store, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.parent.snapshot.paramMap.get('id'));

    this.players = this.store.select(selectPlayers);
  }

}
