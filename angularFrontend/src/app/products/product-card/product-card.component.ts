import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Product } from 'src/app/_models';
import { DataService } from '../../_services/data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit {

  @Input() product: Product;

  constructor(private dataService: DataService, private router: Router) { }

  ngOnInit() {
    console.log("produse: ", this.product);
  }

  onSendProduct(product) {
    this.dataService.changeProduct(product);
    //this.router.navigate(['product-details']);
  }

}
