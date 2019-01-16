import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Product } from '../_models';
import { Observable } from 'rxjs';
import { ProductWrite } from '../_models/productWrite';

@Injectable({ providedIn: 'root' })
export class ProductService {
    constructor(private http: HttpClient) { }

    getAll(): Observable<Product[]> {
        return this.http.get<Product[]>('http://localhost:44800/api/products');
    }
    getProductById(id: string): Observable<Product> {
        return this.http.get<Product>('http://localhost:44800/api/products/' + id);
    }
    getAllMyProducts(username: string): Observable<Product[]> {
        return this.http.get<Product[]>('http://localhost:44800/api/products/my-products/' + username);
    }

    async addProduct(product: ProductWrite): Promise<ProductWrite> {
        return this.http.post<ProductWrite>('http://localhost:4900/api/products', product).toPromise<ProductWrite>();
    }
}