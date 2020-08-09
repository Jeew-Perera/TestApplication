import { Component, OnInit } from '@angular/core';
import { MessengerService } from 'src/app/services/messenger.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartItems =[];

  cartTotal = 0

  constructor(private message: MessengerService) { }

  ngOnInit(): void {
    this.message.getMsg().subscribe((product : Product) => {
      this.addProductToCart(product) 
    });
  }

  addProductToCart(product : Product){

    let productExists = false

      for(let i in this.cartItems){
        if(this.cartItems[i].productId === product.productId){
          this.cartItems[i].qty++
          productExists = true
          break 
        }
      }

    if(!productExists){
      this.cartItems.push(
        {productId:product.productId, productName:product.productName, qty:1, price:product.unitPrice}
      )
    }

    this.cartTotal = 0
    this.cartItems.forEach(item => {
      this.cartTotal += (item.qty*item.price)
    })
  }

}
