import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { CAPTCHA } from "src/types";

@Injectable({
  providedIn: "root",
})
export class CaptchaService {
  private apiUrl = "http://localhost:3000";

  constructor(private http: HttpClient) {}

  getCaptcha(): Observable<CAPTCHA> {
    return this.http.get<CAPTCHA>(`${this.apiUrl}/captcha`);
  }
}
