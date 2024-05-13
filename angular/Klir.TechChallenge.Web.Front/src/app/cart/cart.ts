export interface CartItem {
    productId: number;
    productName: string;
    quantity: number;
    price: number;
    total: number;
    promotionApplied?: string; 
}

export interface Cart {
    items: CartItem[];
    total: number;
    discount?: number; 
    totalWithDiscount?: number;
}