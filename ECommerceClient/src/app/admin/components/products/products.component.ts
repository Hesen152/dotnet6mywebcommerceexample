import {Component, OnInit} from '@angular/core';
import {BaseComponent, SpinnerType} from "../../../base/base.component";
import {NgxSpinnerService} from "ngx-spinner";
import {HttpClient} from "@angular/common/http";
import {HttpClientService} from "../../../services/common/http-client.service";

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService, private httpClientservice: HttpClientService) {
    super(spinner);
  }

  ngOnInit(): void {
    this.showSpinner(SpinnerType.BallAtom);
    // this.httpClientservice.get<Product[]>({
    //   controller: 'products',
    //
    // }).subscribe(data => console.log(data));

    // this.httpClientservice.post({
    //   controller: 'products'
    // },{
    //   name:'computer',
    //   stock:5,
    //   price:34
    //
    // }).subscribe();

    // this.httpClientservice.put({
    //   controller: 'products',
    // },{
    //  id:"6623b862-6723-450d-b632-c6f6601ff95e",
    //   name:"computer2",
    //   stock:88,
    //   price:32
    // }).subscribe();
    // this.httpClientservice.delete({
    //   controller: 'products',
    // }, "6623b862-6723-450d-b632-c6f6601ff95e").subscribe();

    // this.httpClientservice.get({
    //    baseUrl:"https://jsonplaceholder.typicode.com",
    //   controller: 'posts'
    //
    //   fullEndPoint: 'https://jsonplaceholder.typicode.com/posts'
    //
    // }).subscribe(data => console.log(data));

  }

}
