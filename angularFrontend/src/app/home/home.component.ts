import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User, Product } from '../_models';
import { UserService, ProductService } from '../_services';
import { Router } from '@angular/router';

@Component({
	selector: 'app-home-component',
	templateUrl: 'home.component.html',
	styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
	users: User[] = [];
	userDetails: User = new User;
	products: Product[];
	product: Product;


	constructor(
		private userService: UserService,
		private productService: ProductService,
		private userCredentialsService: UserService, 
		private router: Router
		) {
			this.userCredentialsService.getUserCredentials().subscribe(
				userDetails => {
					this.userDetails = userDetails;
					this.productService.getRecommendations(this.userDetails.id.toString()).subscribe(
						products => {
							this.products = products;
							console.log(products);
							console.log(products.length);
							if(products.length == 0) {
								this.productService.getAll(this.userDetails.id.toString()).subscribe(products => this.products = products);
							}
						}
					);
				}
			);
	
		 }

	ngOnInit() {

	}

	onClick() {
		this.router.navigate(['all-products']);
	}
}