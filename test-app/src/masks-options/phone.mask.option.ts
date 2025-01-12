import { NgxMaskConfig } from "ngx-mask";

export const options: Partial<NgxMaskConfig> | (() => Partial<NgxMaskConfig>) =
  {
    validation: true,
    thousandSeparator: " ", 
    decimalMarker: ".",
  };
