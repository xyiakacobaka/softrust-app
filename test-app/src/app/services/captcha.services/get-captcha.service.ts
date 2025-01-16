import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { CAPTCHA } from "@types";

@Injectable({
  providedIn: "root",
})
export class GetCaptchaService {
  constructor(private http: HttpClient) {}

  getCaptcha(): Observable<CAPTCHA> {
    return this.http.get<CAPTCHA>(`http://localhost:3000/captcha`);
  }
}
