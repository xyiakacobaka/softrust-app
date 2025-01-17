import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Message } from "@app/shared/classes/message";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class AddMessageService {
  constructor(private http: HttpClient) {}

  addMessage(message: Message): Observable<any> {
    return this.http.post("http://localhost:5192/api/messages", message);
  }
}
