import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_guards';

import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { AllProductsComponent } from './products/all-products/all-products.component';
import { ProductDetailsComponent } from './products/product-details/product-details.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'all-products', component: AllProductsComponent, canActivate: [AuthGuard]  },
    { path: 'product-details', component: ProductDetailsComponent, canActivate: [AuthGuard]  },
    

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);