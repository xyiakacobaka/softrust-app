import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Theme } from "@types";

@Injectable({
  providedIn: "root",
})
export class GetThemeService {
  constructor(private http: HttpClient) {}

  getThemes(): Observable<Theme[]> {
    return this.http.get<Theme[]>("/assets/initialThemes.json");
  }
}
