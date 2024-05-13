import { Routes } from '@angular/router';

import { ProductListComponent } from './products/product-list/product-list.component';
import { CartComponent } from './cart/cart.component';


export const routes: Routes = [
    { path: 'home', component: ProductListComponent},
    { path: '', redirectTo: 'home', pathMatch: 'full'},
    { path: 'cart', component: CartComponent}
];