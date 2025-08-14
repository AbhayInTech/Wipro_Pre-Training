import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Users } from './users/users';
import { Register } from './register/register';
import { About } from './about/about';
import { Contact } from './contact/contact';
import { Login } from './login/login';
import { PageNotFound } from './page-not-found/page-not-found';

export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: Home },
  { path: 'register', component: Register },
  { path: 'about', component: About },
  { path: 'contact', component: Contact },
  { path: 'login', component: Login },
  { path: 'users', component: Users },
  { path: '**', component: PageNotFound }, // Wildcard route for a 404 page
];
