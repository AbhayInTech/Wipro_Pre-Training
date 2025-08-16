import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AttendeesList } from './attendees-list/attendees-list';

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild([{ path: '', component: AttendeesList }])],
})
export class AttendeesModule {}
