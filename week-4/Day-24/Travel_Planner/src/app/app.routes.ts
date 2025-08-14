import { Routes } from '@angular/router';
import { Home } from './home/home';
import { About } from './about/about';
import { Destination } from './destination/destination';
import { Login } from './login/login';
import { Resgister } from './resgister/resgister';
import { PageNotFound } from './page-not-found/page-not-found';

export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: Home },
  { path: 'about', component: About },
  { path: 'destination', component: Destination },
  // lazzy loading of the destination component
  // {
  //   path: 'destination',
  //   loadChildren: () =>
  //     import('./destination/destination').then((m) => m.Destination),
  // },
  { path: 'login', component: Login },
  { path: 'resgister', component: Resgister },
  { path: '**', component: PageNotFound },
];
