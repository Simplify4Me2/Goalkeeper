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
  // https://www.smashingmagazine.com/2015/07/designing-simple-pie-charts-with-css/
  fakePlayers: Player[] = [
    { id: 1, firstName: 'Dieumerci', lastName: 'Mbokani', nationality: 'CD', shirtNumber: 9, position: 'ATT' },
    { id: 2, firstName: 'Lior', lastName: 'Refaelov', nationality: 'IS', shirtNumber: 7, position: 'MID' },
    { id: 3, firstName: 'Richie', lastName: 'De Laet', nationality: 'BE', shirtNumber: 2, position: 'DEF' },
    { id: 4, firstName: 'Pieter', lastName: 'Gerkens', nationality: 'BE', shirtNumber: 8, position: 'MID' },
    { id: 5, firstName: 'Didier', lastName: 'Lamkel Ze', nationality: 'AO', shirtNumber: 11, position: 'ATT' },
  ];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.parent.snapshot.paramMap.get('id'));
    this.players = of(this.fakePlayers);
  }

}
