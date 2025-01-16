import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";

@Component({
  selector: "app-root",
  imports: [CommonModule, RouterOutlet],
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
