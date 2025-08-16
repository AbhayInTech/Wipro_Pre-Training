import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { EventList } from './event-list/event-list';
import { EventDetails } from './event-details/event-details';
import { EventCreate } from './event-create/event-create';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: EventList },
      { path: 'event-details', component: EventDetails },
      { path: 'create-event', component: EventCreate },
    ]),
  ],
})
export class EventModule {}
