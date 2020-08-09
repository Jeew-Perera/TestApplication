export class Product {

    productId: number;
    productName: string;
    productDescription: string;
    unitPrice: number;
    imageUrl: string;
    userEnteredCount : number;

    constructor(id, name, description='', price=0, imageUrl='assets/img/no-image.jpg' ) {
        this.productId = id;
        this.productName = name;
        this.productDescription = description;
        this.unitPrice = price;
        this.imageUrl = imageUrl;
    }
}
