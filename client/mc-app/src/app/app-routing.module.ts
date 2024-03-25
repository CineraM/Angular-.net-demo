import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Test } from './components/test.component';

const routes: Routes = [
  { path: 'home', component: Test },
  { path: '', redirectTo: '/home', pathMatch: 'full' } // Redirects to `/home` as the default route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }