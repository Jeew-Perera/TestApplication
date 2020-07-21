import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/product';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  // products: Product[] = [
  //   Z
  //   new Product(2,'Product 2','This product 2 is really cool',100),
  //   new Product(3,'Product 3','This product 3 is really cool',150),
  //   new Product(4,'Product 4','This product 4 is really cool',200),
  //   new Product(5,'Product 5','This product 5 is really cool',250),
  //   new Product(6,'Product 6','This product 6 is really cool',300),
  //   new Product(7,'Product 7','This product 7 is really cool',350),
  //   new Product(8,'Product 8','This product 8 is really cool',400),
  // ]

  constructor(private http: HttpClient) { }
  readonly BaseUri = 'http://localhost:59278/api';

  getProducts() : Observable<Product[]> {
      return this.http.get<Product[]>(this.BaseUri + '/Product/Products');
    //console.log(products)
    //return this.products;
  }

  getProductsByCategory(categoryId:number) : Observable<Product[]>{
    return this.http.get<Product[]>(this.BaseUri + '/Product/GetProductsByCategory/'+categoryId);
  }

  getProductById(pid:number) : Observable<Product>{
    return this.http.get<Product>(this.BaseUri + '/Product/'+ pid);
  }

}
