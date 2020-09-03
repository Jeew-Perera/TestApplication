import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { cartItem } from '../models/cartItem';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cartItems : cartItem[] = [];
  cartTotal = 0;

  constructor() { }

  addToCart(productitem: Product): boolean {
    let productExists = false;

    for(let i in this.cartItems){
      if(this.cartItems[i].productId === productitem.productId){
        this.cartItems[i].quantity = productitem.userEnteredCount;
        productExists = true;
        break;
      }      
    }
    
    if(!productExists){
      this.cartItems.push(
        {productId:productitem.productId, productName:productitem.productName, 
          quantity:productitem.userEnteredCount, unitPrice:productitem.unitPrice, imageUrl:productitem.imageUrl}
      )
    }
    
    return true;
  }

  checkCartHasItems(){
    if(this.cartItems.length==0)
      return false;
    else
      return true;
  }

  getCartItems(){
    return this.cartItems;
  }

  getCartTotal(){
    this.cartTotal = 0;
    this.cartItems.forEach(cartItem => {
      this.cartTotal += (cartItem.quantity * cartItem.unitPrice);
      console.log(this.cartTotal);
    });
    return this.cartTotal;
  }

  removeItemsFromCart(cartItem : cartItem){
    this.cartItems.splice(this.cartItems.findIndex(x => x.productId === cartItem.productId), 1);
  }

  clearCart(){
    this.cartItems = [];
    return this.cartItems;
  }
  
}
