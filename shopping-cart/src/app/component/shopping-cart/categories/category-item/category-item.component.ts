import { Component, OnInit, Input } from '@angular/core';
import { Category } from 'src/app/models/category';
import { MessengerService } from 'src/app/services/messenger.service';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-category-item',
  templateUrl: './category-item.component.html',
  styleUrls: ['./category-item.component.css']
})
export class CategoryItemComponent implements OnInit {

  @Input() categoryItem:Category;

  constructor(private message:MessengerService, private productService:ProductService) { }

  ngOnInit(): void {
    //console.log(this.categoryItem);
  }

  handleLoadProductsByCategory(category : Category){
    //event.preventDefault();
    this.message.sendCategoryMsg(category);
    event.preventDefault();
  }
}
