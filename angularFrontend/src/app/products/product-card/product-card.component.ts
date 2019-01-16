import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Product } from 'src/app/_models';
import { DataService } from '../../_services/data.service';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit {

  @Input() product: Product;

  constructor(private dataService: DataService) { }

  ngOnInit() {
  }

  onSendProduct(product) {
    this.dataService.changeProduct(product);
  }

}
