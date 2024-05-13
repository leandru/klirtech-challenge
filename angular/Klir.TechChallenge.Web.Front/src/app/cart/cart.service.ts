import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Product } from '../products/product';
import { Observable } from 'rxjs';
import { Cart, CartItem } from './cart';

@Injectable()
export class CartService {

constructor(private http: HttpClient) { }
    protected UrlServiceV1: string = "http://localhost:5196";

    items: CartItem[] = []

    getCart(cartId:string) : Observable<Cart> {
        return this.http
        .get<Cart>(`${this.UrlServiceV1}/cart/${cartId}/checkout`);
    }


    remove(productId: number){
        this.http.delete(this.UrlServiceV1 + "/cart/456ac843-3859-492f-b855-7229b9d81d73/items/" +productId)
        .subscribe();
    }

    setQuantity(productId: number, quantity: number){
        return this.http.patch<number>(this.UrlServiceV1 + "/cart/456ac843-3859-492f-b855-7229b9d81d73/items/" +productId + "/quantity/" + quantity,null)
    }

}