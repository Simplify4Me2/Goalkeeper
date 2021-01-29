import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-fixtures',
  templateUrl: './fixtures.container.html',
  styleUrls: ['./fixtures.container.sass']
})
export class FixturesContainerComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Number(this.route.parent.snapshot.paramMap.get('id'));
  }

}
