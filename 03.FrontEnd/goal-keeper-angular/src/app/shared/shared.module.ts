import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FixtureComponent, SpinnerComponent } from './components';

@NgModule({
  declarations: [FixtureComponent, SpinnerComponent],
  imports: [
    CommonModule
  ],
  exports: [CommonModule, FixtureComponent, SpinnerComponent]
})
export class SharedModule { }
