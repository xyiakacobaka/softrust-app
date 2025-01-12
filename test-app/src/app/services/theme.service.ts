import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { CAPTCHA, Theme } from "src/types";

@Injectable({
  providedIn: "root",
})
export class ThemeService {
  private apiUrl = "http://localhost:3000";
  constructor(private http: HttpClient) {}

  getThemes(): Observable<Theme[]> {
    return this.http.get<Theme[]>("/assets/data.json");
  }
  getCAPTCHA() {
    console.log(this.http.get(`${this.apiUrl}/captcha`));
    return this.http.get<CAPTCHA>("http://localhost:3000/captcha");
  }
}
