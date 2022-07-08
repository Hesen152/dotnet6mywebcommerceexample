import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {List_product} from "../../../../contracts/list_product";
import {ProductService} from "../../../../services/common/models/product.service";
import {BaseComponent, SpinnerType} from "../../../../base/base.component";
import {NgxSpinnerService} from "ngx-spinner";
import {AlertifyService, MessageType, Position} from "../../../../services/admin/alertify.service";
import {MatPaginator} from "@angular/material/paginator";
import {DialogService} from "../../../../services/common/dialog.service";
import {
  SelectProductImageDialogComponent
} from "../../../../dialogs/select-product-image-dialog/select-product-image-dialog.component";
declare var $:any;

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent extends BaseComponent implements OnInit {

  constructor(private productService: ProductService, spinner: NgxSpinnerService,
              private alertifyService: AlertifyService,private dialogService:DialogService) {
    super(spinner);
  }

  displayedColumns: string[] = ['name', 'stock', 'price', 'createdDate', 'updatedDate','photos','edit','delete'];
  dataSource: MatTableDataSource<List_product> = null;
  @ViewChild(MatPaginator) paginator: MatPaginator;


  async getProducts() {
    this.showSpinner(SpinnerType.BallAtom);
    const allProducts:{totalCount:number,products:List_product[]} = await this.productService.read(this.paginator?this.paginator.pageIndex:0,
      this.paginator? this.paginator.pageSize:5,
      () => this.hideSpinner(SpinnerType.BallAtom),
      errorMessage => this.alertifyService.message(errorMessage, {
        dismissOthers: true,
        messageType: MessageType.Error,
        position: Position.TopRight
      })
    )
    this.dataSource = new MatTableDataSource<List_product>(allProducts.products);
    this.paginator.length=allProducts.totalCount;
    //this.dataSource.paginator = this.paginator;
  }

  async pageChanged(){
   await this.getProducts();
  }
//   delete(id,event){
// // alert(id);
// const img:HTMLImageElement=event.srcElement;
//  $(img.parentElement.parentElement).fadeOut(2000);
//   }

  async ngOnInit() {
    this.getProducts()


  }

  addProductImages(id:string){
   this.dialogService.openDialog({
   componentType:SelectProductImageDialogComponent,
     data:id,
     options:{
     width:"1200px"
     }

   })
  }


}
