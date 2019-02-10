import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Product, ProductEdit, Comment } from '../_models';
import { Observable } from 'rxjs';
import { ProductWrite } from '../_models/productWrite';
import { ProductBid } from '../_models/productBid';
import { catchError } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class ProductService {
    constructor(private http: HttpClient) { }

    getAll(username: string): Observable<Product[]> {
        return this.http.get<Product[]>('http://localhost:44800/api/products/otherproducts/' + username);
    }
    getProductById(id: string): Observable<Product> {
        return this.http.get<Product>('http://localhost:44800/api/products/' + id);
    }
    getAllMyProducts(username: string): Observable<Product[]> {
        return this.http.get<Product[]>('http://localhost:44800/api/products/my-products/' + username);
    }

    getWishlistProducts(userId: string): Observable<Product[]> {
        return this.http.get<Product[]>('http://localhost:44800/api/products/wishlist/' + userId);
    }

    getRecommendations(userId: string): Observable<Product[]> {
        return this.http.get<Product[]>('http://localhost:44800/api/products/recommendations/' + userId);
    }

    getComments(productId: string): Observable<Comment[]> {
        return this.http.get<Comment[]>('http://localhost:44800/api/products/comments/' + productId);
    }

    async addProduct(product: ProductWrite): Promise<ProductWrite> {
        return this.http.post<ProductWrite>('http://localhost:4900/api/products', product).toPromise<ProductWrite>();
    }

    async updateProduct(id: string, product: ProductEdit): Promise<ProductEdit> {
        return this.http.put<ProductEdit>('http://localhost:4900/api/products/' + id, product).toPromise<ProductEdit>();
    }

    async bidProduct(id: string, product: ProductBid): Promise<ProductBid> {
        return this.http.put<ProductBid>('http://localhost:4900/api/products/update-bid/' + id, product).toPromise<ProductBid>();
    }

    async submitComment(comment: Comment): Promise<Comment> {
        return this.http.post<Comment>('http://localhost:4900/api/products/submit-comment/', comment).toPromise<Comment>();
    }

    deleteProduct(id: string): Observable<{}> {
        return this.http.delete('http://localhost:4900/api/products/delete-product/' + id);
    }
}