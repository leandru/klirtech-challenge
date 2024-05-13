import { Component, OnInit } from '@angular/core';
import { CartService } from './cart.service';
import { HttpClient } from '@angular/common/http';
import { Cart, CartItem } from './cart';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgModel } from '@angular/forms';


@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [ RouterLink, CommonModule, HttpClientModule, FormsModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css',
  providers: [ CartService, HttpClient ]
})

export class CartComponent implements OnInit {
  
  constructor(private cartService: CartService) { }

  cart?: Cart;

  ngOnInit() {
    this.cartService.getCart("456ac843-3859-492f-b855-7229b9d81d73")
      .subscribe( c => this.cart = c);
  }
  
  onSelectionChange(event: any) {
    let quantity = event[0].target.value;
    let productId = event[1];

    this.setQuantityOfItem(productId, quantity);
    
    this.cart?.items.map( it => {
      if(it.productId == productId){
        
      }
    });
  }
  
  removeItemFromCart( productId: number){
    let indexToRemove = this.cart?.items.findIndex(item => item.productId === productId);
    if (indexToRemove !== -1) {
      this.cart?.items.splice( indexToRemove == undefined ? 0 : indexToRemove, 1  )
    }
    this.cartService.remove(productId);
  }

  setQuantityOfItem( productId:number, quantity:number){
    this.cartService.setQuantity(productId,quantity);
  }

  finalPriceWithDiscount(){
    let total = 0;
    this.cart?.items.map( it => total += it.total)
    return total;
  }

  finalPrice(){
    let total = 0;
    this.cart?.items.map( it => total += it.quantity * it.price)
    return total;
  }


}
