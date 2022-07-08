import {Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2} from '@angular/core';
import {HttpClientService} from "../../services/common/http-client.service";
import {NgxSpinnerService} from "ngx-spinner";
import {SpinnerType} from "../../base/base.component";
import {MatDialog} from "@angular/material/dialog";
import {DeleteDialogComponent, DeleteState} from "../../dialogs/delete-dialog/delete-dialog.component";
import {AlertifyService, MessageType, Position} from "../../services/admin/alertify.service";
import {HttpErrorResponse} from "@angular/common/http";
import {DialogService} from "../../services/common/dialog.service";

declare var $:any;
@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  constructor(private element:ElementRef,
              private renderer:Renderer2,
              private httpClientService:HttpClientService ,
              private spinner:NgxSpinnerService,
              public dialog: MatDialog,
              private alertifyService:AlertifyService,
              private dialogService:DialogService) {
    const img=renderer.createElement("img");
    img.setAttribute("src","../../../../../assets/delete.png");
    img.setAttribute("style","cursor:pointer");
    img.width=25;
    img.height=25;
     renderer.appendChild(element.nativeElement,img);

  }

  @Input() id:string;
  @Input() controller:string;
  @Output() callback:EventEmitter<any>=new EventEmitter<any>();

  @HostListener("click")
async onclick(){

    this.dialogService.openDialog({
     componentType:DeleteDialogComponent,
    data:DeleteState.yes,
     afterClosed:(async ()=>{
       this.spinner.show(SpinnerType.BallAtom);
       const td:HTMLTableCellElement=this.element.nativeElement;
       this.httpClientService.delete({
         controller:this.controller,
       },this.id).subscribe(data=>{
         $(td.parentElement).animate({
           opacity:0,
           left:"+=50",
           height:"toggle"
         },700,()=>{
           this.callback.emit();
           this.alertifyService.message("Product succesfully deleted!",{
             dismissOthers:true,
             messageType:MessageType.Success,
             position:Position.TopRight

           })
         })

       },(errorResponse:HttpErrorResponse)=>{
         this.spinner.hide(SpinnerType.BallAtom)
         this.alertifyService.message("unexpected error encountered",{
           dismissOthers:true,
           messageType:MessageType.Error,
           position:Position.TopRight

         })
       } )

     })
    })

  }

  // openDialog(afterClosed:any): void {
  //   const dialogRef = this.dialog.open(DeleteDialogComponent, {
  //     width: '250px',
  //     data: DeleteState.yes,
  //   });
  //
  //   dialogRef.afterClosed().subscribe(result => {
  //     //console.log('The dialog was closed');
  //     if (result == DeleteState.yes) {
  //      afterClosed();
  //     }
  //   });
  //
  //
  // }


  }
