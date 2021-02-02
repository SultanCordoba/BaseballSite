import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LigasComponent } from './_components/ligas/ligas.component';
import { TemporadaComponent } from './_components/temporada/temporada.component';

const routes: Routes = [
    { path:'liga/:id', component:LigasComponent },
    { path:'temporada/:id', component:TemporadaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
