import {Injectable} from '@angular/core';
import {Create_Product} from "../../../contracts/create_product";
import {HttpClientService} from "../http-client.service";
import {HttpErrorResponse} from "@angular/common/http";
import {List_product} from "../../../contracts/list_product";
import {firstValueFrom, Observable} from "rxjs";
import {List_Product_Image} from "../../../contracts/list_product_image";

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClientService: HttpClientService) {

  }

  create(product: Create_Product, successCallBack?: ()=>void, errorCallBack?: (errorMessage:string)=>void) {
    this.httpClientService.post({
      controller: 'products',

    }, product)
      .subscribe(result => {
        successCallBack();
      },(errorResponse:HttpErrorResponse )=>{
        const _error:Array<{key:string,value:Array<string>}>=errorResponse.error;
        let message="";
        _error.forEach((v,index)=>{
          v.value.forEach((_v,_index)=>{
            message+=`${_v}</br>`
          });
        });

        errorCallBack(message);

      } )

  }

 async read( page:number=0,size:number=5,sucessCallBack?:()=>void,errorCallBack?:(errorMessage:string)=>void):Promise<{totalCount:number,products:List_product[]}>{
   const promiseData: Promise<{totalCount:number,products:List_product[]}> =this.httpClientService.get<{totalCount:number,products:List_product[]}>(
      {
        controller:'products',
        queryString:`page=${page}&size=${size}`
      }).toPromise();
   promiseData.then(d=>sucessCallBack())
     .catch((errorResponse:HttpErrorResponse)=>errorCallBack(errorResponse.message))

   return await promiseData;

}

 async delete(id:string){
    const deleteObservable:Observable<any>=this.httpClientService.delete({
      controller:"products"
    },id);

    await firstValueFrom(deleteObservable);

 }

 async readImages(id:string,successCallBack?:()=>void):Promise<List_Product_Image[]>{
  const getObservable:Observable<List_Product_Image[]>= this.httpClientService.get<List_Product_Image[]>({
      action:"getProductImages",
      controller:"products",

    },id);

  const images:List_Product_Image[]=await firstValueFrom(getObservable)
   successCallBack();

  return  images;

 }
 async  deleteImages(id:string,imageId:string,successCallBack?:()=>void){
     const deleteObservable=this.httpClientService.delete({
        action:"deleteProductImage",
        controller:"products",
        queryString:`imageId=${imageId}`,

      },id)

   await  firstValueFrom(deleteObservable);
    successCallBack();

  }


}
