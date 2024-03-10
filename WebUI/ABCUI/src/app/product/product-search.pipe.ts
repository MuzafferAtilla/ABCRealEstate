import { Pipe, PipeTransform } from '@angular/core';
import { Product } from './product';

@Pipe({
  name: 'productSearch',
  standalone: true
})
export class ProductSearchPipe implements PipeTransform {

  transform(value: Product[], searchText: string, min:number, max:number): Product[] {
    searchText = searchText?searchText.toLocaleLowerCase():""
    var returnValue = searchText?value.filter((p:Product) => p.productName.toLocaleLowerCase().indexOf(searchText)!==-1):value;
    if(min > 0) {
      returnValue = value.filter(m => m.price >= min);
    }
    if(max > 0) {
      returnValue = value.filter(m => m.price <= max);
    }
    return returnValue

  }

}
