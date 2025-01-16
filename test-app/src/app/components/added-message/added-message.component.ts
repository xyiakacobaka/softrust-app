import { Component, OnInit } from "@angular/core";
import { AddMessageService } from "@app/services/message.services/add-message.service";

@Component({
  selector: "app-added-message",
  imports: [],
  templateUrl: "./added-message.component.html",
  styleUrl: "./added-message.component.css",
})
export class AddedMessageComponent implements OnInit {
  data: string = "";
  constructor(private addMessageService: AddMessageService) {
    //addMessageService.getThemes
  }
  ngOnInit(): void {}
}
