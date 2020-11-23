import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `<app-header></app-header>
             <router-outlet></router-outlet>`,
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'goal-keeper-angular';
}
