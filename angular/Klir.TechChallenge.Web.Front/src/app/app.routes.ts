import { Routes } from '@angular/router';

import { ProductsComponent } from './products/products.component';


export const routes: Routes = [
    { path: 'home', component: ProductsComponent},
    { path: '', redirectTo: 'home', pathMatch: 'full'}
];