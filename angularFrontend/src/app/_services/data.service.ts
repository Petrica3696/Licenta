import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../_models';

@Injectable({ providedIn: 'root' })
export class DataService {

  private productSource = new BehaviorSubject(undefined);
  currentSource = this.productSource.asObservable();

  constructor() { }

  changeProduct(product: Product) {
    this.productSource.next(product)
  }

}