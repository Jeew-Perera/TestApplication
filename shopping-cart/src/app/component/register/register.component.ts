import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';

//If data is valid return null else return an object
function symbolValidator(control){  // control = registerForm.get('password')
  //console.log(control);
  if(control.hasError('required')){
    return null;
  }
  if(control.hasError('minlength')){
    return null;
  }
  if(control.value.indexOf('@') > -1){
    return null;
  }
  else{
    return {symbol : true};
  }
}

/** 
 * 
 * @param form
*/

function passwordsMatchValidator(form){
  const password = form.get('password');
  const confirmPassword = form.get('confirmPassword');

  if(password.value !== confirmPassword.value){
    form.confirmPassword.setErros({passwordsMatch : true});
  }
  else{
    form.confirmPassword.setErros({passwordsMatch : false});
  }
  return null;
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(public service : UserService) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit(){
    this.service.register().subscribe(
      (res:any) => {
        if(res.succeded){
          this.service.formModel.reset();
        }
        else{
          res.errors.forEach(element => {
            switch(element.code){
              case 'DuplicateUserName':
                break;
              default:
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}
