import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponentComponent } from 'src/app/pages/home/home-component/home-component.component';
import { InformacionComponenteComponent } from './pages/InformacionComponente/InformacionComponente.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponentComponent,
    },
    {
    path: 'piedras/:idPiedra',
    component: InformacionComponenteComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
