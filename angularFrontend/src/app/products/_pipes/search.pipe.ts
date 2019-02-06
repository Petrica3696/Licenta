import { Pipe, PipeTransform } from '@angular/core';
import { Product } from 'src/app/_models';

@Pipe({
  name: 'searchPipe'
})
export class SearchPipe implements PipeTransform {

  transform(value: Product[], args?: string): Product[] {
    if (args) {
      return (value || []).filter((item: Product) => {
        return item.name.toLowerCase().includes(args.toLowerCase());
      });
    }
    return value;
  }

}
