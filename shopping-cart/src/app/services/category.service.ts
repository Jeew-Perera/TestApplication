import { Injectable } from '@angular/core';
import { Category } from 'src/app/models/category';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  categories: Category[] = [
    new Category(1,'Category 1'),
    new Category(2,'Category 2'),
  ]

  constructor(private http: HttpClient) { }

  readonly BaseUri = environment.baseUri;

  getCategories(): Observable<Category[]>{
    return this.http.get<Category[]>(this.BaseUri + 'Category');
  }
}
