import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { first } from 'rxjs/operators';

import { User, Product } from '../_models';
import { UserService, ProductService } from '../_services';
import { Router } from '@angular/router';

@Component({
	selector: 'app-home-component',
	templateUrl: 'home.component.html',
	styleUrls: ['./home.component.scss'],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit {
	users: User[] = [];
	userDetails: User;
	recommendations: Product[] = [];


	constructor(
		private userService: UserService,
		private productService: ProductService,
		private userCredentialsService: UserService, 
		private changeDetectorRef: ChangeDetectorRef,
		private router: Router
		) { }

	ngOnInit() {

		this.userCredentialsService.getUserCredentials().subscribe(
			userDetails => {
				this.userDetails = userDetails;
				this.changeDetectorRef.detectChanges();

				this.productService.getRecommendations(userDetails.id).subscribe(
					recommendations => {
						this.recommendations = recommendations;
						console.log(recommendations);
					}
				);
			}
		);

	}

	onClick() {
		this.router.navigate(['all-products']);
	}
}