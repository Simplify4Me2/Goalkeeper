import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template:  `<app-header></app-header>
              <div class="content">
                <router-outlet></router-outlet>
              </div>
              <app-footer></app-footer>`,
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'goal-keeper-angular';
}
