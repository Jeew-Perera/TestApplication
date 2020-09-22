import { Component, OnInit } from '@angular/core';
import { MessengerService } from 'src/app/services/messenger.service';
import { Product } from 'src/app/models/product';
import { CartService } from 'src/app/services/cart.service';
import { cartItem } from 'src/app/models/cartItem';
import { Subscription } from 'rxjs/internal/Subscription';

@Component({
  selector: 'app-main-cart',
  templateUrl: './main-cart.component.html',
  styleUrls: ['./main-cart.component.css']
})
export class MainCartComponent implements OnInit {

  cartItems : cartItem[];
  cartTotal = 0;
  private subscription: Subscription;


  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    // this.cartItems = this.cartService.getCartItems();
    // console.log(this.cartItems);
    this.cartService.updateCartState();
    this.subscription = this.cartService.cartSubject
                    .subscribe((c: cartItem[]) => {
                        this.cartItems = c;
                    });
    console.log(this.cartItems);
  }

  removeCartItem(cartItem : cartItem){
    event.preventDefault();
    console.log(cartItem);
    this.cartService.removeItemsFromCart(cartItem);
    //this.cartItems = this.cartService.getCartItems();
    //this.cartTotal = this.cartService.getCartTotal();
  }

  getCartTotal(){
    return this.cartService.getCartTotal();
  }

  changeQty(newQty,cartItem :cartItem){
    cartItem.quantity = newQty;
    this.cartService.changeQty(cartItem);
  }

}
