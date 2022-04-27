import {Component} from '@angular/core';
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "./services/ui/custom-toastr.service";

declare var $: any;
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ECommerceClient';

  constructor(private toastService:CustomToastrService)
  {
 toastService.message('Welcome to ECommerceClient', 'Welcome',{
   messageType:ToastrMessageType.Warning,
   position:ToastrPosition.TopCenter
  });
 //toastService.message('Welcome to ECommerceClient', 'Welcome',{
 //   messageType:ToastrMessageType.Success,
 //   position:ToastrPosition.BottomLeft
 // });
 //    toastService.message('Welcome to ECommerceClient', 'Welcome',{
 //      messageType:ToastrMessageType.Error,
 //      position:ToastrPosition.BottomFullWidth
 //    });
  }



}

// $.get("https://localhost:7015/api/products",data=>{
//   console.log(data);
// })

