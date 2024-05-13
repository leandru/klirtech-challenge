import { Component, OnInit } from '@angular/core';
import { CartService } from './cart.service';
import { HttpClient } from '@angular/common/http';
import { Cart } from './cart';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [ RouterLink, CommonModule, HttpClientModule],
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

}
