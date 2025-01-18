import { Routes } from "@angular/router";
import { MessageFormComponent } from "./components/mesage-form/mesage-form";
import { AddedMessageComponent } from "./components/added-message/added-message.component";
import { NotFoundComponent } from "./components/not-found/not-found.component";

export const appRoutes: Routes = [
  { path: "", component: MessageFormComponent },
  { path: "message", component: AddedMessageComponent },
  { path: "**", component: NotFoundComponent },
];
