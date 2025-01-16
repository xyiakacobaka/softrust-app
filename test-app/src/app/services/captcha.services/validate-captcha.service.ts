import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class ValidateService {
  constructor(private http: HttpClient) {}

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
