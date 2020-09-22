import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { cartItem } from '../models/cartItem';
import { ReplaySubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cartItems : cartItem[] = [];
  cartSubject = new ReplaySubject<cartItem[]>();
  cartTotal = 0;

  constructor() { }

  addToCart(productitem: Product): boolean {

    //this.cartItems = [];
    const localStorageCart = JSON.parse(localStorage.getItem('currentCart'));

    if(localStorageCart != null){
      console.log('not null')
      for(let i=0; i<localStorageCart; i++){
        this.cartItems.push({
          productId: localStorageCart[i].productId,
          productName: localStorageCart[i].productName,
          quantity: localStorageCart[i].quantity,
          unitPrice: localStorageCart[i].unitPrice,
          imageUrl: localStorageCart[i].imageUrl,
        })
      }
    }

    if(this.cartItems.find(x => x.productId == productitem.productId)){
      for(let i in this.cartItems){
          if(this.cartItems[i].productId === productitem.productId){
            this.cartItems[i].quantity = productitem.userEnteredCount;
            break;
          }      
        }
        this.cartSubject.next(this.cartItems);
        this.setLocalStorageCart();
    }

    if(!this.cartItems.find(x => x.productId === productitem.productId)){
      this.cartItems.push({
        productId: productitem.productId,
        productName: productitem.productName,
        quantity: productitem.userEnteredCount,
        unitPrice: productitem.unitPrice,
        imageUrl: productitem.imageUrl,
      });
      this.cartSubject.next(this.cartItems);
      this.setLocalStorageCart();
    }

    return true;

    // let productExists = false;

    // for(let i in this.cartItems){
    //   if(this.cartItems[i].productId === productitem.productId){
    //     this.cartItems[i].quantity = productitem.userEnteredCount;
    //     productExists = true;
    //     break;
    //   }      
    // }
    
    // if(!productExists){
    //   this.cartItems.push(
    //     {productId:productitem.productId, productName:productitem.productName, 
    //       quantity:productitem.userEnteredCount, unitPrice:productitem.unitPrice, imageUrl:productitem.imageUrl}
    //   )
    // }
    
    // return true;
  }

  setLocalStorageCart(){
    localStorage.setItem('currentCart', JSON.stringify(this.cartItems));
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
    this.cartSubject.next(this.cartItems );
    this.setLocalStorageCart();
  }

  clearCart(){
    this.cartItems = [];
    this.cartSubject.next(this.cartItems);
    this.setLocalStorageCart();
    //return this.cartItems;
  }

  updateCartState(){
    this.cartItems = [];
    const localStorageCart = JSON.parse(localStorage.getItem('currentCart'));
    
    if (localStorageCart != null){
      for ( let i = 0; i < localStorageCart.length; i++) {
        this.cartItems.push({
          productId: localStorageCart[i].productId,
          productName: localStorageCart[i].productName,
          quantity: localStorageCart[i].quantity,
          unitPrice: localStorageCart[i].unitPrice,
          imageUrl: localStorageCart[i].imageUrl,
        });
      }
      this.cartSubject.next(this.cartItems);
    }
  }

  changeQty(cartItem : cartItem){
    const localStorageCart = JSON.parse(localStorage.getItem('currentCart'));

    for(let i=0; i<localStorageCart; i++){
      if(localStorageCart[i].productId === cartItem.productId){
        localStorageCart[i].quantity = cartItem.quantity;
      }
    }
    this.cartSubject.next(this.cartItems);
    this.setLocalStorageCart();
  }
  
}
