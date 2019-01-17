import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Product } from 'src/app/_models';
import { DataService } from '../../_services/data.service';

@Component({
  selector: 'app-my-product-card',
  templateUrl: './my-product-card.component.html',
  styleUrls: ['./my-product-card.component.scss']
})
export class MyProductCardComponent implements OnInit {

  @Input() product: Product;

  constructor(private dataService: DataService) { }

  ngOnInit() {
  }

  onSendProduct(product) {
    this.dataService.changeProduct(product);
  }

}
