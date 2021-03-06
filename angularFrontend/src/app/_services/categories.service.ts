import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Category } from '../_models/category';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CategoryService {
    constructor(private http: HttpClient) { }

    getAll(): Observable<Category[]> {
        return this.http.get<Category[]>('http://localhost:44800/api/categories');
    }
    getCategoryById(id: string): Observable<Category> {
        return this.http.get<Category>('http://localhost:44800/api/categories/' + id);
    }
}