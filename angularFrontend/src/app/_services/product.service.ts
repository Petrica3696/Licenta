import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Product } from '../_models';
import { Observable } from 'rxjs';

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
}