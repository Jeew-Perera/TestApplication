import { Customer } from './customer';
import { cartItem } from './cartItem';
import { PaymentDetails } from './paymentDetails';

export class OrderDetails {

    billingDetails : Customer;
    receiverName: string;
    receiverAddress : string;
    receiverPhone : string;
    orderedProducts : cartItem[];
    orderDate: Date;
    orderTotal: number;
    //cardDetails : PaymentDetails;

    constructor(billingDetails, receiverName, receiverAddress, receiverPhone, orderedProducts, orderDate, orderTotal) {
        this.billingDetails = billingDetails;
        this.receiverName = receiverName;
        this.receiverAddress = receiverAddress;
        this.receiverPhone = receiverPhone;
        this.orderedProducts = orderedProducts;
        this.orderDate = orderDate;
        this.orderTotal =orderTotal;
        //this.cardDetails = cardDetails;
    }
}