import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/models/product';
import { MessengerService } from 'src/app/services/messenger.service'
import { CartService } from 'src/app/services/cart.service';
import { ToastrService } from 'ngx-toastr';
import { cartItem } from 'src/app/models/cartItem';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() productItem:Product;
  public userEnteredCount : number=1;
  public cartHasItems : boolean = false;
  public cart : cartItem[] = [];

  constructor(private message:MessengerService, private cartService: CartService, private toastr : ToastrService) { }

  ngOnInit(): void {
    this.cartHasItems = this.cartService.checkCartHasItems();
    if(this.cartHasItems){
     this.cart = this.cartService.getCartItems();
     this.cart.forEach(item =>
      {
         if(item.productId == this.productItem.productId)
          this.productItem.userEnteredCount = item.quantity;
      });
    }
    console.log(this.productItem); 
    
  }

  handleAddToCart(){
    if(this.productItem.userEnteredCount==null){
      this.productItem.userEnteredCount = 1;
      console.log("user entered count ", this.productItem.userEnteredCount);
    }
    if (this.cartService.addToCart(this.productItem)) {
      this.toastr.success(' product added to cart ');
    }
    else{
      this.toastr.error(' product adding failed  ');
    } 
  }

  handleDisplayProductDetails(){
    this.message.sendMsg(this.productItem); 
  }

}
