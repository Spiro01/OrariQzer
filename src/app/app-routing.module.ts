import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  {
    path: '', loadChildren: () => import('src/app/pages/schedule/schedule.module').then(m => m.ScheduleModule)
  },
  {
    path: '',
    redirectTo: '',
    pathMatch: 'full'
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
