import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.container.html',
  styleUrls: ['./stats.container.sass']
})
export class StatsContainerComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.parent.snapshot.paramMap.get('id'));
  }

}
