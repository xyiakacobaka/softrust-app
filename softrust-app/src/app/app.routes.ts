import { Routes } from '@angular/router';

import { MessageFormComponent } from '@components/message-form/message-form.component';
import { AddedMessageComponent } from '@components/added-message/added-message.component';
import { NotFoundComponent } from '@components/not-found/not-found.component';

export const routes: Routes = [
  { path: '', component: MessageFormComponent },
  { path: 'message', component: AddedMessageComponent },
  { path: '**', component: NotFoundComponent },
];
