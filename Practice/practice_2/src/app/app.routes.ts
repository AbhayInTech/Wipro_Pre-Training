import { Routes } from '@angular/router';
import { Interpolation } from './interpolation/interpolation';
import { Counter } from './counter/counter';
import { PageNotFound } from './page-not-found/page-not-found';
import { Grade } from './grade/grade';

export const routes: Routes = [
  { path: 'interpolation', component: Interpolation },
  { path: 'counter', component: Counter },
  { path: 'grade', component: Grade },
  { path: '**', component: PageNotFound },
];
