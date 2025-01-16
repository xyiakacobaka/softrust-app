import { NgxMaskConfig } from "ngx-mask";

export const PhoneMaskOption:
  | Partial<NgxMaskConfig>
  | (() => Partial<NgxMaskConfig>) = {
  validation: true,
  thousandSeparator: " ",
  decimalMarker: ".",
};
