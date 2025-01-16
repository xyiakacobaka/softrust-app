import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Contact } from "@app/shared/classes/contact";

@Injectable({
  providedIn: "root",
})
export class AddContactService {
  constructor(private http: HttpClient) {}

  addContact(body: Contact): Observable<any> {
    return this.http.post("http://localhost:5192/api/contacts", body);
  }
}
