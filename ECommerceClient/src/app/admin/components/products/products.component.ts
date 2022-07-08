import {Component, OnInit, ViewChild} from '@angular/core';
import {BaseComponent, SpinnerType} from "../../../base/base.component";
import {NgxSpinnerService} from "ngx-spinner";
import {HttpClient} from "@angular/common/http";
import {HttpClientService} from "../../../services/common/http-client.service";
import {Create_Product} from "../../../contracts/create_product";
import {ListComponent} from "./list/list.component";

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

  }
  @ViewChild(ListComponent) listComponents:ListComponent
  createdProduct(createdProduct:Create_Product){
   this.listComponents.getProducts();
  }


}
