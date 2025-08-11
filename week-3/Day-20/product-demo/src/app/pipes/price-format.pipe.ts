import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'priceFormat',
})
export class PriceFormatPipe implements PipeTransform {
  transform(
    value: number | null | undefined,
    currency: string = 'USD',
    local: string = 'en-US'
  ): string {
    if (value === null || value === undefined) return '';
    if (isNaN(Number(value))) return '';
    try {
      return new Intl.NumberFormat(local, {
        style: 'currency',
        currency,
      }).format(value);
    } catch (e) {
      return `${currency} ${(value ?? 0).toFixed(2)}`;
    }
  }
}
