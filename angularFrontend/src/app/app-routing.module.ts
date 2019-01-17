import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_guards';

import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { AllProductsComponent } from './products/all-products/all-products.component';
import { ProductDetailsComponent } from './products/product-details/product-details.component';
import { MyProductsComponent } from './products/my-products/my-products.component';
import { AddProductComponent } from './products/add-product/add-product.component';
import { MyProductDetailsComponent } from './products/my-product-details/my-product-details.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'all-products', component: AllProductsComponent, canActivate: [AuthGuard]  },
    { path: 'my-products', component: MyProductsComponent, canActivate: [AuthGuard]  },
    { path: 'product-details/:id', component: ProductDetailsComponent, canActivate: [AuthGuard]  },
    { path: 'add-product', component: AddProductComponent, canActivate: [AuthGuard]  },
    { path: 'my-product-details/:id', component: MyProductDetailsComponent, canActivate: [AuthGuard]  },
    

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);