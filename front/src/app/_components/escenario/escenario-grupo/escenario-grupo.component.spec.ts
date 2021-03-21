import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EscenarioGrupoComponent } from './escenario-grupo.component';

describe('EscenarioGrupoComponent', () => {
  let component: EscenarioGrupoComponent;
  let fixture: ComponentFixture<EscenarioGrupoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EscenarioGrupoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EscenarioGrupoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
