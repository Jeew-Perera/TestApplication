import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http'; 
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './component/shared/header/header.component';
import { FooterComponent } from './component/shared/footer/footer.component';
import { NavComponent } from './component/shared/nav/nav.component';
import { ShoppingCartComponent } from './component/shopping-cart/shopping-cart.component';
import { FiltersComponent } from './component/shopping-cart/filters/filters.component';
import { ProductListComponent } from './component/shopping-cart/product-list/product-list.component';
import { CartComponent } from './component/shopping-cart/cart/cart.component';
import { CartItemComponent } from './component/shopping-cart/cart/cart-item/cart-item.component';
import { ProductItemComponent } from './component/shopping-cart/product-list/product-item/product-item.component';
import { CategoriesComponent } from './component/shopping-cart/categories/categories.component';
import { CategoryItemComponent } from './component/shopping-cart/categories/category-item/category-item.component';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { PageNotFoundComponent } from './component/shared/page-not-found/page-not-found.component';
import { ProductViewComponent } from './component/product-view/product-view.component';
import { RouterModule } from '@angular/router';
import { UserService } from './services/user.service';
import { ProfileComponent } from './component/profile/profile.component';
import { MainCartComponent } from './component/main-cart/main-cart.component';
//import { ProductDetailComponent } from './product-detail/product-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NavComponent,
    ShoppingCartComponent,
    FiltersComponent,
    ProductListComponent,
    CartComponent,
    CartItemComponent,
    ProductItemComponent,
    CategoriesComponent,
    CategoryItemComponent,
    LoginComponent,
    RegisterComponent,
    PageNotFoundComponent,
    ProductViewComponent,
    ProfileComponent,
    MainCartComponent,
    //ProductDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
