import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FixtureComponent } from './fixture.component';

describe('FixtureComponent', () => {
  let component: FixtureComponent;
  let fixture: ComponentFixture<FixtureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FixtureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FixtureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
