import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { CAPTCHA, Theme } from "src/types";

@Injectable({
  providedIn: "root",
})
export class ThemeService {
  constructor(private http: HttpClient) {}

  getThemes(): Observable<Theme[]> {
    return this.http.get<Theme[]>("/assets/initialThemes.json");
  }
}
