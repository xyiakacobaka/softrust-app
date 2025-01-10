import { Injectable } from "@angular/core";

declare const grecaptcha: any; // Объявляем grecaptcha

@Injectable({
  providedIn: "root",
})
export class RecaptchaService {
  private siteKey = "6LfFQLMqAAAAALijqaLVAsOzRXMYNM-CsHYevMNm";

  constructor() {}

  getToken(action: string): Promise<string> {
    return new Promise((resolve, reject) => {
      grecaptcha.ready(() => {
        grecaptcha
          .execute(this.siteKey, { action })
          .then((token: string) => {
            resolve(token);
          })
          .catch((error: any) => {
            reject(error);
          });
      });
    });
  }
}
