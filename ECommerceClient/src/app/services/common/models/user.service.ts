import {Injectable} from '@angular/core';
import {HttpClientService} from "../http-client.service";
import {User} from "../../../entities/user";
import {Create_user} from "../../../contracts/users/create_user";
import {firstValueFrom, Observable} from "rxjs";
import {Token} from "../../../contracts/token/token";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../../ui/custom-toastr.service";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private httpClientService: HttpClientService,private toastrService:CustomToastrService) {

  }


  async create(user: User): Promise<Create_user> {
    const observable: Observable<Create_user | User> = this.httpClientService.post<Create_user | User>({
      controller: "users"

    }, user);

    return await firstValueFrom(observable) as Create_user;
  }

  async login(userNameOrEmail: string, password: string, callBackFunction?: () => void): Promise<any> {
    const observable: Observable<any|Token> = this.httpClientService.post<any|Token>({
      controller: "users",
      action: "login"
    }, {userNameOrEmail, password})

    const token:Token= await firstValueFrom(observable) as Token;
     if (token)
       this.toastrService.message("User login successfuly provided","Login Sucessful",{
         messageType:ToastrMessageType.Success,
         position:ToastrPosition.TopRight
       })
    callBackFunction();
  }


}
