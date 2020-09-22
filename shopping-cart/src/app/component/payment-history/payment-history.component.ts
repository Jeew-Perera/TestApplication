import { Component, OnInit } from '@angular/core';
import { OrderDetails } from 'src/app/models/orderDetails';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-payment-history',
  templateUrl: './payment-history.component.html',
  styleUrls: ['./payment-history.component.css']
})
export class PaymentHistoryComponent implements OnInit {

  constructor(private paymentService:PaymentService) { }
  customerId :  number;
  orderDetails: any[] = [];
  orderDetails1: any[] = [];
  orderi : number;

  ngOnInit(): void {
    var retrivedCustomerDetails = localStorage.getItem('customer');
    const cusDetails = JSON.parse(retrivedCustomerDetails);
    this.customerId = cusDetails['customerId'];
    console.log(this.customerId);
    
    this.paymentService.getPaymentHistory(this.customerId).subscribe((orderDetails:any[]) =>{
      console.log(orderDetails);
      this.orderi=-1;
      //var ordttl;
      for(let i in orderDetails){
        //console.log(orderDetails[i]);
        //console.log(this.orderi);
        if(this.orderi != orderDetails[i].orderId){
          this.orderDetails1.push(orderDetails[i]);
        }
        else{
          // this.cartItems.push({
          //   productId: localStorageCart[i].productId,
          //   productName: localStorageCart[i].productName,
          //   quantity: localStorageCart[i].quantity,
          //   unitPrice: localStorageCart[i].unitPrice,
          //   imageUrl: localStorageCart[i].imageUrl,
          // })
          this.orderDetails1.push({
            orderId : "",
            orderDate : "",
            productName : orderDetails[i].productName,
            unitPrice : orderDetails[i].unitPrice,
            quantity : orderDetails[i].quantity,
            orderTotal : ""
          })
        }
        
        this.orderi = orderDetails[i].orderId;

      }
      console.log(this.orderDetails1);
      this.orderDetails = this.orderDetails1;
    });
  }
}
