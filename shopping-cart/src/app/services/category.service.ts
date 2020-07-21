import { Injectable } from '@angular/core';
import { Category } from 'src/app/models/category';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  categories: Category[] = [
    new Category(1,'Category 1'),
    new Category(2,'Category 2'),
  ]

  constructor(private http: HttpClient) { }

  readonly BaseUri = 'http://localhost:59278/api';

  getCategories(): Observable<Category[]>{
    //return this.categories;
    return this.http.get<Category[]>(this.BaseUri + '/Category/Categories');
  }
}
