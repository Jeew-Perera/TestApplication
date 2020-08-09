import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { MessengerService } from 'src/app/services/messenger.service';
import { Product } from 'src/app/models/product';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/models/category';
import { CartService } from 'src/app/services/cart.service';
import { cartItem } from 'src/app/models/cartItem';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  productList:Product[];
  // public cartHasItems : boolean = false;
  // public cart : cartItem[] = [];
  //productListBOC:Product[]=[];

  constructor(private productService:ProductService, private route: ActivatedRoute, 
    private message: MessengerService, private cartService: CartService) { }

  ngOnInit(): void {
    // this.cartHasItems = this.cartService.checkCartHasItems();
    // if(this.cartHasItems){
    //   this.cart = this.cartService.getCartItems();
    //   this.productService.getProducts().subscribe((products:Product[]) =>{
    //     var tempProductList = products;
    //   });

    // }
    // this.route.data.subscribe(data => {
    //   switch(data.kind){
    //     case 'list':
          this.productService.getProducts().subscribe((products:Product[]) =>{
            //console.log(products)
            this.productList = products;
          });
    //       break;
    //     //case 'category':
    //     //   this.GetProductsByCategory();
    //   }
    // })

    this.message.getCategoryMsg().subscribe((category : Category) => {
      this.displayProductsBasedOnCategory(category) 
    });
  }

  displayProductsBasedOnCategory(category : Category){
    this.productService.getProductsByCategory(category.categoryId).subscribe((products:Product[]) => {
      
      this.productList = products;
      console.log(this.productList);
    });
  }

  // GetProductsByCategory(){
  //     this.productService.getProductsByCategory(+this.route.snapshot.params['id']).subscribe((products:Product[]) =>{
  //       this.productList = products;
  //       console.log(this.productList);
  //     });
  //   }


}
