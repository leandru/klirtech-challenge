import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Product } from './product';
import { Observable } from 'rxjs';
import { environment } from '../../enviroments/environment';
import { SessionService } from '../util/session-service';
@Injectable()

export class ProductService {

constructor(private http: HttpClient, private sessionCartService: SessionService ) { }
    protected UrlServiceV1: string = environment.apiUrl;
    
    protected SessionCartId: string = this.sessionCartService.getCartId();

    getProducts() : Observable<Product[]> {
        return this.http
        .get<Product[]>(this.UrlServiceV1 + "/products");
    }
    
    add(productId: number){
        this.http.post<{ productId: number }>(`${this.UrlServiceV1}/cart/${this.SessionCartId}/items`, { productId: productId })
        .subscribe( x => console.log( this) );
    }

}