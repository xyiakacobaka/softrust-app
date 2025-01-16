import { ApplicationConfig, provideZoneChangeDetection } from "@angular/core";
import { provideNgxMask } from "ngx-mask";
import { PhoneMaskOption } from "@app/options/phone-mask.option";
import { provideHttpClient } from "@angular/common/http";
import { provideRouter } from "@angular/router";
import { appRoutes } from "./app.routes";

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideNgxMask(PhoneMaskOption),
    provideHttpClient(),
    provideRouter(appRoutes),
  ],
};
