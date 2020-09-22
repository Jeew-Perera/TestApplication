import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { CartService } from 'src/app/services/cart.service';
import { cartItem } from 'src/app/models/cartItem';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { OrderDetails } from 'src/app/models/orderDetails';
import { Customer } from 'src/app/models/customer';
import { PaymentDetails } from 'src/app/models/paymentDetails';
import { PaymentService } from 'src/app/services/payment.service';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs/internal/Subscription';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  cartItems : cartItem[];
  id : number;
  name : string;
  email : string;
  address : string;
  phone : number;
  loggedincustomer : Customer;
  orderDetails : any = {};
  private subscription : Subscription ;
  //cardDetails : PaymentDetails;

  paymentFormModel = this.fb.group({ 
    receivername: ['', Validators.required],
    receiveraddress: ['', Validators.required],
    receiverphone: ['', Validators.required],
    // cardtype: ['',Validators.required],
    // cardnumber: ['',Validators.required],
    // expdate: ['',Validators.required],
    // cvnnumber: ['',Validators.required],
  });

  constructor(public userService :UserService, private cartService: CartService, 
    public router : Router, private fb : FormBuilder, private paymentService : PaymentService, private toastr : ToastrService) { }

  ngOnInit(): void {
    if(this.loggedIn()){
      //this.cartItems = this.cartService.getCartItems();
      this.cartService.updateCartState();
      this.subscription = this.cartService.cartSubject
                    .subscribe((c: cartItem[]) => {
                        this.cartItems = c;
                    });
      //
      var retrivedCustomerDetails = localStorage.getItem('customer');
      const cusDetails = JSON.parse(retrivedCustomerDetails);
      this.id = cusDetails['customerId'];
      this.email = cusDetails['email'];
      this.name = cusDetails['customerName'];
      this.address = cusDetails['customerAddress'];
      this.phone = cusDetails['phone'];
      this.loggedincustomer = new Customer(this.id,this.email,this.name,this.address,this.phone);
    }
    else{
      console.log('Nt logged in');
      this.router.navigateByUrl('/login');
    }
  }

  getCartTotal(){
    return this.cartService.getCartTotal();
  }

  loggedIn(){
    return this.userService.userLoggedIn();
  }

  onCheckboxChange(e){
    if (e.target.checked) {
      this.paymentFormModel.controls['receivername'].setValue(this.name);
      this.paymentFormModel.controls['receiveraddress'].setValue(this.address);
      this.paymentFormModel.controls['receiverphone'].setValue(this.phone);
      document.getElementById("recName").setAttribute('readonly',"true");
      document.getElementById("recAddress").setAttribute('readonly',"true");
      document.getElementById("recPhone").setAttribute('readonly',"true");
    }
    else{
      this.paymentFormModel.controls['receivername'].setValue(null);
      this.paymentFormModel.controls['receiveraddress'].setValue(null);
      this.paymentFormModel.controls['receiverphone'].setValue(null);
      document.getElementById("recName").removeAttribute('readonly');
      document.getElementById("recAddress").removeAttribute('readonly');
      document.getElementById("recPhone").removeAttribute('readonly');
    }
  }

  onPay(){
    var order = this.setOrderDetails(); 
    
    this.paymentService.saveOrder(order).subscribe( 
      next => {
        this.toastr.success('Order placed successfully','Message');
        this.router.navigateByUrl('/paymentHistory');
      },
      error => {
        this.toastr.error('Error in order placing, please try again later','Error');
      }
    );
    this.cartService.clearCart();
  }

  setOrderDetails(): OrderDetails{
    //this.cardDetails = new PaymentDetails(this.paymentFormModel.value.cardtype,this.paymentFormModel.value.cardnumber,this.paymentFormModel.value.expdate,this.paymentFormModel.value.cvnnumber);

    this.orderDetails.billingDetails = this.loggedincustomer;
    this.orderDetails.receiverName = this.paymentFormModel.value.receivername;
    this.orderDetails.receiverAddress = this.paymentFormModel.value.receiveraddress;
    this.orderDetails.receiverPhone = this.paymentFormModel.value.receiverphone;
    this.orderDetails.orderedProducts = this.cartItems;
    this.orderDetails.orderDate = new Date().toDateString();
    this.orderDetails.orderTotal = this.cartService.getCartTotal();
    //this.orderDetails.cardDetails = this.cardDetails;
    return this.orderDetails;
  }

  // ngOnDestroy() {
  //   this.subscription.unsubscribe();
  // }

}
