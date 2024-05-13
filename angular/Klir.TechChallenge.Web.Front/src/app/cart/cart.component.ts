import { Component, OnInit } from '@angular/core';
import { CartService } from './cart.service';
import { HttpClient } from '@angular/common/http';
import { CartItem } from './cart';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';


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

  items: CartItem[] = [];

  ngOnInit() {
    this.cartService.getCart().subscribe( c => {this.items = c.items});
  }
  
  onSelectionChange(event: any) {
    let quantity = event[0].target.value;
    let productId = event[1];

    this.setQuantityOfItem(productId, quantity);
  }
  
  removeItemFromCart( productId: number){
    let indexToRemove = this.items.findIndex(item => item.productId === productId);
    if (indexToRemove !== -1) {
      this.items.splice( indexToRemove == undefined ? 0 : indexToRemove, 1  )
    }
    this.cartService.remove(productId);
  }

  setQuantityOfItem( productId:number, quantity:number){
    this.cartService.setQuantity(productId,quantity)
    .subscribe( r => this.items.map( it => {
      if(it.productId == productId){ 
        console.log("r" + r)
        it.total = r.total
        it.promotionApplied = r.appliedPromotion
      }
    }));
  }

  finalPriceWithDiscount(){
    let total = 0;
    this.items.map( it => total += it.total)
    return total;
  }

  finalPrice(){
    let total = 0;
    this.items.map( it => total += it.quantity * it.price)
    return total;
  }


}
