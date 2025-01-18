import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { CAPTCHA } from "@types";

@Injectable({
  providedIn: "root",
})
export class CaptchaService {
  constructor(private http: HttpClient) {}

  getCaptcha(): Observable<CAPTCHA> {
    return this.http.get<CAPTCHA>(`http://localhost:3000/captcha`);
  }
  validateCaptcha(
    captchaId: string,
    userInput: string
  ): Observable<{ valid: boolean }> {
    const body = {
      captchaId: captchaId,
      userInput: userInput,
    };

    return this.http.post<{ valid: boolean }>(
      "http://localhost:3000/validate-captcha",
      body
    );
  }
}
