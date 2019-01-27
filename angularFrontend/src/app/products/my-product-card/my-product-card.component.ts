import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Product } from 'src/app/_models';
import { DataService } from '../../_services/data.service';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-product-card',
  templateUrl: './my-product-card.component.html',
  styleUrls: ['./my-product-card.component.scss']
})
export class MyProductCardComponent implements OnInit {

  @Input() product: Product;
  base64Image

  constructor(
    private dataService: DataService, 
    private domSanitizer: DomSanitizer,
    private router: Router
    ) { }

  ngOnInit() {
    console.log("product: ", this.product);
  }

  onSendProduct(product) {
    this.dataService.changeProduct(product);
  }

  onViewDetails() {
    this.router.navigate(['/my-product-details/' + this.product.id]);
  }
}
