import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SandboxComponent } from './sandbox/sandbox.component';
import { LigasComponent } from './_components/ligas/ligas.component';
import { TemporadaComponent } from './_components/temporada/temporada.component';

const routes: Routes = [
    { path:'liga/:id', component:LigasComponent },
    { path:'temporada/:id', component:TemporadaComponent },
    { path:'sandbox', component:SandboxComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
