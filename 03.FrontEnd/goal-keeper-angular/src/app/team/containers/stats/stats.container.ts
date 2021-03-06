import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Player } from '../../models';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.container.html',
  styleUrls: ['./stats.container.sass']
})
export class StatsContainerComponent implements OnInit {

  players: Observable<Player[]>;

  fakePlayers: Player[] = [
    { id: 1, firstName: 'Dieumerci', lastName: 'Mbokani', shirtNumber: 9, position: 'ATT' },
    { id: 2, firstName: 'Lior', lastName: 'Refaelov', shirtNumber: 7, position: 'MID' },
    { id: 3, firstName: 'Richie', lastName: 'De Laet', shirtNumber: 2, position: 'DEF' },
    { id: 4, firstName: 'Pieter', lastName: 'Gerkens', shirtNumber: 8, position: 'MID' },
    { id: 5, firstName: 'Didier', lastName: 'Lamkel Ze', shirtNumber: 11, position: 'ATT' },
  ];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.parent.snapshot.paramMap.get('id'));
    this.players = of(this.fakePlayers);
  }

}
