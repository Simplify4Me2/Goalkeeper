import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatchComponent, SpinnerComponent } from './components';

@NgModule({
  declarations: [MatchComponent, SpinnerComponent],
  imports: [
    CommonModule
  ],
  exports: [CommonModule, MatchComponent, SpinnerComponent]
})
export class SharedModule { }
