import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { OrderDetails } from '../models/orderDetails';
import { Observable, Subject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})

export class PaymentService{

    private readonly baseUrl = environment.baseUri + 'Order/';
    subjectOrder = new Subject();

    constructor(private httpClient : HttpClient){}

    saveOrder(orderDetails : OrderDetails){
        console.log(orderDetails);
        return this.httpClient.post( this.baseUrl, orderDetails );
    }
    
    getPaymentHistory(customerId : number) : Observable<OrderDetails[]> {
        return this.httpClient.get<OrderDetails[]>(this.baseUrl + customerId);
    }
}