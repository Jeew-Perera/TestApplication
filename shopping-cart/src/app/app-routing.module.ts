import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShoppingCartComponent } from './component/shopping-cart/shopping-cart.component';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { PageNotFoundComponent } from './component/shared/page-not-found/page-not-found.component';
import { ProductViewComponent } from './component/product-view/product-view.component';

const routes : Routes = [
    { path : '', redirectTo: '/products', pathMatch:'full'},
    { path : 'login', component : LoginComponent },
    { path : 'register', component : RegisterComponent},
    // { path : 'products', component : ShoppingCartComponent, data: { kind: 'list' }},
    { path : 'products', component : ShoppingCartComponent},
    { path : 'product/:id', component: ProductViewComponent },
    //{ path : 'products/category/:id', component: ShoppingCartComponent, data: { kind: 'category' } },  //jeew 
    { path : '**', component : PageNotFoundComponent} 
];

@NgModule({
    imports:[
        RouterModule.forRoot(routes)
    ],
    exports:[
        RouterModule
    ]
})

export class AppRoutingModule{

}