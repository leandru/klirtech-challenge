import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Product } from './product';
import { Observable } from 'rxjs';

@Injectable()

export class ProductService {

constructor(private http: HttpClient) { }
    protected UrlServiceV1: string = "http://localhost:5196";

    getProducts() : Observable<Product[]> {
        return this.http
        .get<Product[]>(this.UrlServiceV1 + "/products");
    }
    
    add(productId: number){
        this.http.post<{ productId: number }>(this.UrlServiceV1 + "/cart/456ac843-3859-492f-b855-7229b9d81d73/items", { productId: productId })
        .subscribe( x => console.log( this) );
    }

    
}