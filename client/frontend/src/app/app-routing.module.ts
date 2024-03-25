import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonalComp } from './components/Personal.component';

const routes: Routes = [
  
  {'path': '', 'redirectTo': 'personal', 'pathMatch': 'full'},
  {'path': 'personal', component : PersonalComp},
  // {'path': 'test', component : PersonalComp},
  // {'path': 'anime', component : AnimeListComponent},
  // {'path': 'anime/save', component : AnimeNewComponent},
  // {'path': 'anime/:id', component : AnimeFetchIdComponent},
  // {'path': 'anime/title/:search', component : AnimeTitleSearchComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
