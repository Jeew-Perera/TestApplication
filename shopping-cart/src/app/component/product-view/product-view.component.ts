import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/models/product';
import { MessengerService } from 'src/app/services/messenger.service';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {

  oneProduct : Product ;

  constructor(private message: MessengerService,private productService : ProductService, private route: ActivatedRoute ) { }

  ngOnInit(): void {
    this.GetProductDetailsFromServer();
  }

  GetProductDetailsFromServer(){
    this.productService.getProductById(+this.route.snapshot.params['id']).subscribe((product:Product) =>{
      this.oneProduct = product;
    });
  }

}
