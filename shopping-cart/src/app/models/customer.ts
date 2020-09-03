export class Customer {

    customerId : number;
    email: string;
    customerName: string;
    customerAddress: string;
    phone : number;

    constructor(customerId, email, customerName, customerAddress, phone) {
        this.customerId = customerId;
        this.email = email;
        this.customerName = customerName;
        this.customerAddress = customerAddress;
        this.phone = phone;
    }
}