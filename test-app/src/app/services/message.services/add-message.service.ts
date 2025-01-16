import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Message } from "@app/shared/classes/message";

@Injectable({
  providedIn: "root",
})
export class AddMessageService {
  constructor(private http: HttpClient) {}

  addMessage(message: Message) {
    return this.http.post("http://localhost:5192/api/messages", message);
  }
}
