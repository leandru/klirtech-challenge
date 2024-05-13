import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Product } from '../products/product';
import { Observable } from 'rxjs';
import { Cart } from './cart';

@Injectable()
export class CartService {

constructor(private http: HttpClient) { }
    protected UrlServiceV1: string = "http://localhost:5196";

    items: Product[] = []

    getCart(cartId:string) : Observable<Cart> {
        return this.http
        .get<Cart>(`${this.UrlServiceV1}/cart/${cartId}/checkout`);
    }

}