import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/models/product';
import { MessengerService } from 'src/app/services/messenger.service';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute } from '@angular/router';
import { cartItem } from 'src/app/models/cartItem';
import { CartService } from 'src/app/services/cart.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {

  oneProduct : Product ;
  tempProduct : Product ;
  public cartHasItems : boolean = false;
  public cart : cartItem[] = [];

  constructor(private message: MessengerService,private productService : ProductService, 
    private route: ActivatedRoute, private cartService : CartService, private toastr : ToastrService ) { }

  ngOnInit(): void { 
    this.GetProductDetailsFromServer();
  }

  GetProductDetailsFromServer(){

    this.productService.getProductById(+this.route.snapshot.params['id']).subscribe((product:Product) =>{
      this.oneProduct = product;
      this.tempProduct = product;
      console.log(this.oneProduct);
      
      //****
      this.cartHasItems = this.cartService.checkCartHasItems();
    if(this.cartHasItems){
     this.cart = this.cartService.getCartItems();
     this.cart.forEach(item =>
      {
         if(item.productId == this.tempProduct.productId){
          this.tempProduct.userEnteredCount = item.quantity;
          console.log(this.tempProduct);
         }
      });
    } 
      //****
      this.oneProduct = this.tempProduct;
      console.log(this.oneProduct);
    });
  }

  handleAddToCartFromProductDetailPage(){
    if(this.oneProduct.userEnteredCount==null){
      this.oneProduct.userEnteredCount = 1;
      console.log("user entered count ", this.oneProduct.userEnteredCount);
    }
    if (this.cartService.addToCart(this.oneProduct)) {
      this.toastr.success(' product added to cart ');
    }
    else{
      this.toastr.error(' product adding failed  '); 
    } 
  }

}
