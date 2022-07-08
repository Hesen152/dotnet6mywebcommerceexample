import {Component, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators} from "@angular/forms";
import {User} from "../../../entities/user";
import {UserService} from "../../../services/common/models/user.service";
import {Create_user} from "../../../contracts/users/create_user";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../../../services/ui/custom-toastr.service";
import {BaseComponent} from "../../../base/base.component";
import {NgxSpinnerService} from "ngx-spinner";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent extends  BaseComponent implements OnInit {

  constructor(private  formBuilder:FormBuilder,
              private userService:UserService,private  toastService:CustomToastrService,spinner:NgxSpinnerService) {
    super(spinner);
  }
  form:FormGroup;
  ngOnInit(): void {
    this.form=this.formBuilder.group({
      nameSurname:["",[
        Validators.required,
        Validators.max(50),
        Validators.minLength(3)
      ]
      ],
      userName:["",[
        Validators.required,
        Validators.max(50),
        Validators.minLength(3)
      ]
      ],
      email:["",
        [
        Validators.required,
        Validators.max(250),
        Validators.email
      ]],
      password:["",[
        Validators.required
      ]],
      passwordConfirm:["",[
        Validators.required
      ]]
    },{validators:(group:AbstractControl):ValidationErrors | null =>{
     let password=group.get("password").value;
     let passwordRepeat=group.get("passwordConfirm").value;
     return password===passwordRepeat? null :{notSame:true};


    }

  })
  }

  get component(){
    return this.form.controls;
  }

  submitted:boolean=false;

   async onSubmit(user:User){
    this.submitted=true;
     // console.log(c.hasOwnProperty.name)


    if (this.form.invalid)
      return;
 const result: Create_user =await this.userService.create(user);
    if (result.succeeded) {
      this.toastService.message(result.message, "Sucefully register", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      })
    }


     else
    {
        this.toastService.message(result.message,"Error",{
          messageType:ToastrMessageType.Error,
          position:ToastrPosition.TopRight
        })
    }

     debugger;
   }

}
