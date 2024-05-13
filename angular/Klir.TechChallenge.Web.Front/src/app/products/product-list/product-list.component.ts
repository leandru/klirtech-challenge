import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from '../product.service';
import { RouterLink } from '@angular/router';
import { Product } from '../product';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [ RouterLink, CommonModule, HttpClientModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css',
  providers: [ProductService, HttpClient]
})
export class ProductListComponent implements OnInit {

  constructor(private productService: ProductService) { }

  products: Product[]  = [];

  ngOnInit() {
    this.productService.getProducts()
      .subscribe( p => this.products = p);
  }

  addItemToCart( productId: number){
    this.productService.add(productId);
  }
  
}