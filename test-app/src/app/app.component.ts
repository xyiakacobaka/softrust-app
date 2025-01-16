import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";

import { MessageFormComponent } from "@app/components/forms/mesage-form";

@Component({
  selector: "app-root",
  imports: [MessageFormComponent, CommonModule],
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
  standalone: true,
})
export class AppComponent {
  formValid: boolean = false;
  onFormSubmitted(data: boolean) {
    this.formValid = data;
    console.log(this.formValid);
  }
}
