import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';
import { Questions } from './pages/questions/questions';
import { QuestionDetail } from './pages/question-detail/question-detail';
import { Ask } from './pages/ask/ask';
import { Admin } from './pages/admin/admin';
import { Welcome } from './pages/welcome/welcome';
import { AuthGuard } from './guards/auth-guard';
import { AdminGuard } from './guards/admin-guard';

export const routes: Routes = [
  { path: 'ask', component: Ask, canActivate: [AuthGuard] },
  { path: 'questions', component: Questions },
  { path: '', component: Welcome },
  { path: 'login', component: Login },
  { path: 'register', component: Register },
  { path: 'q/:id', component: QuestionDetail, canActivate: [AuthGuard] },
  { path: 'admin', component: Admin, canActivate: [AdminGuard] },
];

// @NgModule({ imports: [RouterModule.forRoot(routes)], exports: [RouterModule] })
// export class AppRoutingModule {}
