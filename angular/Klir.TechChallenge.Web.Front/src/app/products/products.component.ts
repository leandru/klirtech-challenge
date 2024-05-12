import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgIf } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [ RouterLink, CommonModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})

export class ProductsComponent {

  public produtos = [
      {
        "id": 1,
        "name": "Product A",
        "price": "€20",
        "promotion": "Buy 1 Get 1 Free"
      },
      {
        "id": 2,
        "name": "Product B",
        "price": "€2",
        "promotion": ""
      },
      {
        "id": 3,
        "name": "Product C",
        "price": "€4",
        "promotion": "3 for 10 Euro"
      },
      {
        "Id": 4,
        "name": "Product D",
        "price": "€4",
        "promotion": "3 for 10 Euro"
      }
    ]

}
