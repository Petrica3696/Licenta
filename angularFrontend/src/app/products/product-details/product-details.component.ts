import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../../_services/data.service';
import { Product } from 'src/app/_models';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product: Product;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.dataService.currentSource.subscribe(product => this.product = product);
    console.log("destinatie: ", this.product);
  }

}
