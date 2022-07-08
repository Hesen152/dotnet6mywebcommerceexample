import {Component, Inject, OnInit, Output} from '@angular/core';
import {Basedialog} from "../base/basedialog";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {DeleteDialogComponent, DeleteState} from "../delete-dialog/delete-dialog.component";
import {FileUploadOptions} from "../../services/common/fileupload/fileupload.component";
import {ProductService} from "../../services/common/models/product.service";
import {List_Product_Image} from "../../contracts/list_product_image";
import {NgxSpinnerService} from "ngx-spinner";
import {SpinnerType} from "../../base/base.component";
import {DialogService} from "../../services/common/dialog.service";

declare var $: any

@Component({
  selector: 'app-select-product-image-dialog',
  templateUrl: './select-product-image-dialog.component.html',
  styleUrls: ['./select-product-image-dialog.component.css']
})
export class SelectProductImageDialogComponent extends Basedialog<SelectProductImageDialogComponent> implements OnInit {

  constructor(dialogRef: MatDialogRef<SelectProductImageDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: SelectProductImageState | string,
              private productService: ProductService, private spinner: NgxSpinnerService, private dialogService: DialogService) {
    super(dialogRef)
  }


  images: List_Product_Image[];


  @Output() options: Partial<FileUploadOptions> = {
    accept: ".png,.jpg,.jpeg,.gif",
    action: "upload",
    controller: "products",
    explanation: "select image or drop here ",
    isAdminPage: true,
    queryString: `id=${this.data}`
  }

  async ngOnInit() {
    this.spinner.show(SpinnerType.BallAtom);
    this.images = await this.productService.readImages(this.data as string, () => this.spinner.hide(
      SpinnerType.BallAtom
    ))
  }

  async deleteImage(imageId: string, event: any) {

    this.dialogService.openDialog({
      componentType: DeleteDialogComponent,
      data: DeleteState.yes,
      afterClosed: async () => {
        this.spinner.show(SpinnerType.BallAtom);
        //debugger;-
        await this.productService.deleteImages(this.data as string, imageId, () => {
          this.spinner.hide(SpinnerType.BallAtom);

          var card = $(event.srcElement).parent().parent();
          card.fadeOut(500);

          debugger;
        })
      }
    })

  }

}

export enum SelectProductImageState {
  close
}
