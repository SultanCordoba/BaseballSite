import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LigasComponent } from './_components/ligas/ligas.component';

const routes: Routes = [
    { path:'liga/:id', component:LigasComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
