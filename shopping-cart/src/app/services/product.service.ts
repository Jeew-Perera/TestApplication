import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/product';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }
  private readonly BaseUri = environment.baseUri;

  getProducts() : Observable<Product[]> {
      return this.http.get<Product[]>(this.BaseUri + 'Product/');
  }

  getProductsByCategory(categoryId:number) : Observable<Product[]>{
    return this.http.get<Product[]>(this.BaseUri + 'Product/Category/'+categoryId);
  }

  getProductById(pid:number) : Observable<Product>{
    return this.http.get<Product>(this.BaseUri + 'Product/'+ pid);
  }

}
