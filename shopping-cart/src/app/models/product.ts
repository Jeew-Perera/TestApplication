export class Product {
    // productId: number;
    // productName: string;
    // productDescription: string;
    // unitPrice: number;
    // imageUrl: string;

    // constructor(id:number,name:string, description:string='', price:number=0, imageUrl:string='assets/img/no-image.jpg') {
    //     this.productId = id;
    //     this.productName = name;
    //     this.productDescription = description;
    //     this.unitPrice = price;
    //     this.imageUrl = imageUrl;
    // }

    productId: number;
    productName: string;
    productDescription: string;
    unitPrice: number;
    imageUrl: string;

    constructor(id, name, description='', price=0, imageUrl='assets/img/no-image.jpg') {
        this.productId = id;
        this.productName = name;
        this.productDescription = description;
        this.unitPrice = price;
        this.imageUrl = imageUrl;
    }

    // constructor(userResponse:any) {
    //     this.id = userResponse.productId;
    //     this.name = userResponse.productName;
    //     this.description = userResponse.productDescription;
    //     this.price = userResponse.unitPrice;
    //     this.imageUrl = userResponse.imageUrl;
    // }
}
