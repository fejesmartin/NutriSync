export class Product {
    productId: number;
    productName: string;
    description: string;
    price: number;

    constructor(productId: number, productName: string, description: string, price: number) {
        this.productId = productId;
        this.productName = productName;
        this.description = description;
        this.price = price;
    }

}