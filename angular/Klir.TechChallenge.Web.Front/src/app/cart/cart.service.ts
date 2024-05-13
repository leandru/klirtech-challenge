import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Cart, CartItem } from './cart';
import { environment } from '../../enviroments/environment';
import { SessionService } from '../util/session-service';

@Injectable()
export class CartService {

constructor(private http: HttpClient, private sessionCartService: SessionService) { }
    protected UrlServiceV1: string = environment.apiUrl;

    public SessionCartId: string = this.sessionCartService.getCartId();

    items: CartItem[] = []

    getCart() : Observable<Cart> {
        return this.http
        .get<Cart>(`${this.UrlServiceV1}/cart/${this.SessionCartId}/checkout`);
    }

    remove(productId: number){
        this.http.delete(`${this.UrlServiceV1}/cart/${this.SessionCartId}/items/${productId}`)
        .subscribe();
    }

    setQuantity(productId: number, quantity: number){
        return this.http.patch<{productId: number, total:number, appliedPromotion:string}>(`${this.UrlServiceV1}/cart/${this.SessionCartId}/items/${productId}/quantity/${quantity}`,null)
    }

}