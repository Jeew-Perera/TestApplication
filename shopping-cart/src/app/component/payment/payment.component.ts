import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { CartService } from 'src/app/services/cart.service';
import { cartItem } from 'src/app/models/cartItem';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  cartItems : cartItem[];

  constructor(public userService :UserService, private cartService: CartService) { }

  ngOnInit(): void {
    this.cartItems = this.cartService.getCartItems();
  }

  getCartTotal(){
    return this.cartService.getCartTotal();
  }

  // loggedIn(){
  //   return this.userService.userLoggedIn();
  // }

}
