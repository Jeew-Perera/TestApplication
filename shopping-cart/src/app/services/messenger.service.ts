import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessengerService {

  subject = new Subject();
  subjectCat = new Subject();

  constructor() { }

  sendMsg(product){
    console.log(product)
    this.subject.next(product) //triggering an event
  }

  getMsg(){
    return this.subject.asObservable()
  }

  sendCategoryMsg(category){
    console.log(category)
    this.subjectCat.next(category) //triggering an event
  }

  getCategoryMsg(){
    return this.subjectCat.asObservable()
  }
}
