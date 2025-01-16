import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Theme } from "@types";

@Injectable({
  providedIn: "root",
})
export class AddThemeService {
  constructor(private http: HttpClient) {}

  addTheme(theme: Theme): Observable<any> {
    return this.http.post("http://localhost:5192/api/themes", theme);
  }
}
