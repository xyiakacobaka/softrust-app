import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Message } from "@app/shared/classes/message";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class MessagesService {
  constructor(private http: HttpClient) {}

  addMessage(message: Message): Observable<any> {
    return this.http.post("http://localhost:5192/api/messages", message);
  }
  getMessageById(id: number): Observable<any> {
    return this.http.get(`http://localhost:5192/api/Messages/${id}`);
  }
}
