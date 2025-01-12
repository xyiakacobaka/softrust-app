import { ApplicationConfig, provideZoneChangeDetection } from "@angular/core";
import { provideNgxMask } from "ngx-mask";
import { options } from "@masks-options/phone.mask.option";
import { provideHttpClient } from '@angular/common/http';


export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideNgxMask(options),
    provideHttpClient()
  ],
};
