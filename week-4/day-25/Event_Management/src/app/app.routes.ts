import { Routes } from '@angular/router';
import { Home } from './home/home';
import { PageNotFound } from './page-not-found/page-not-found';

export const routes: Routes = [
  { path: '', component: Home },
  {
    path: 'events',
    loadChildren: () => import('./event/event-module').then((m) => m.EventModule),
  },
  {
    path: 'attendees',
    loadChildren: () => import('./attendees/attendees-module').then((m) => m.AttendeesModule),
  },
  {
    path: 'event-details',
    loadChildren: () => import('./event/event-module').then((m) => m.EventModule),
  },
  {
    path: 'create-event',
    loadChildren: () => import('./event/event-module').then((m) => m.EventModule),
  },

  { path: '**', component: PageNotFound },
];
