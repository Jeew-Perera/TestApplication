export class PaymentDetails {

    cardType : string;
    cardNumber: number;
    expDate : string;
    cvnNumber : number;

    constructor(cardType, cardNumber, expDate, cvnNumber) {
        this.cardType = cardType;
        this.cardNumber = cardNumber;
        this.expDate = expDate;
        this.cvnNumber = cvnNumber;
    }
}