import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SerieAlternaComponent } from './serie-alterna.component';

describe('SerieAlternaComponent', () => {
  let component: SerieAlternaComponent;
  let fixture: ComponentFixture<SerieAlternaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SerieAlternaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SerieAlternaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
