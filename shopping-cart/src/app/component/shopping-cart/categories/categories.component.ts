import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import { Category } from 'src/app/models/category';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  categoryList: Category[];

  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void {
    //console.log(this.categoryService.getCategories());
    //this.categories = this.categoryService.getCategories();
    this.categoryService.getCategories().subscribe((categories:Category[]) =>{
      //console.log(categories)
      this.categoryList = categories;
    })
  }

}
