export class cartItem{
    productId: number;
    productName: string;
    //productDescription: string;
    quantity :  number;
    unitPrice: number;
    imageUrl: string;

    constructor(id, name, quantity=1, price=0, imageUrl='assets/img/no-image.jpg') {
        this.productId = id;
        this.productName = name;
        //this.productDescription = description;
        this.quantity = quantity;
        this.unitPrice = price;
        this.imageUrl = imageUrl;
    }
}