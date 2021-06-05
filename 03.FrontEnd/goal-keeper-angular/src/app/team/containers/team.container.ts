import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';

import * as fromTeam from '../store';
import { Observable } from 'rxjs';
import { Team } from '../../team/models';

@Component({
    selector: 'app-team-container',
    templateUrl: './team.container.html',
    styleUrls: ['./team.container.sass']
})
export class TeamContainerComponent implements OnInit {

    team: Observable<Team>;

    constructor(private store: Store, private route: ActivatedRoute) {}

    ngOnInit(): void {
        const name = this.route.snapshot.paramMap.get('name');

        this.store.dispatch(fromTeam.getTeam({ name }));

        this.team = this.store.select(fromTeam.selectTeam);
    }

}