import { Pipe, PipeTransform } from '@angular/core';
import { Product } from 'src/app/_models';
import { SortOrder } from 'src/app/_models/sortOrder';
import { orderBy } from 'lodash';

@Pipe({
  name: 'orderBy'
})
export class OrderByPipe implements PipeTransform {

  transform(value: Product[], args?: SortOrder): Product[]{
    if(args){
      return orderBy(value, [value => value[args.orderBy] ? value[args.orderBy] : ''], [args.sortOrder]);
    }else{
      return value;
    }
  }

}
