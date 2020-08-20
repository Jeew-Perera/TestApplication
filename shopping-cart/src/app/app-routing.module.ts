import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShoppingCartComponent } from './component/shopping-cart/shopping-cart.component';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { PageNotFoundComponent } from './component/shared/page-not-found/page-not-found.component';
import { ProductViewComponent } from './component/product-view/product-view.component';
import { ProfileComponent } from './component/profile/profile.component';
import { MainCartComponent } from './component/main-cart/main-cart.component';
import { AuthGuard } from './auth/auth.guard';
import { PaymentComponent } from './component/payment/payment.component';

const routes : Routes = [
    //{ path : '', redirectTo: '/products', pathMatch:'full'},
    { path : 'login', component : LoginComponent },
    { path : 'register', component : RegisterComponent},
    { path : 'products', component : ShoppingCartComponent},
    { path : 'product/:id', component: ProductViewComponent },
    { path : 'profile', component: ProfileComponent, canActivate:[AuthGuard] }, 
    { path : 'cart', component : MainCartComponent},  
    { path : 'payment', component : PaymentComponent},  
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