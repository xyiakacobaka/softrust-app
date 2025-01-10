import { NgxMaskConfig } from "ngx-mask";

export const options: Partial<NgxMaskConfig> | (() => Partial<NgxMaskConfig>) =
  {
    validation: true, // Отключить валидацию
    thousandSeparator: " ", // Разделитель тысяч
    decimalMarker: ".", // Разделитель десятичных
  };
