import {Component, OnInit} from '@angular/core';
import {AlertifyService, MessageType, Position} from "../../../services/admin/alertify.service";
import {BaseComponent, SpinnerType} from "../../../base/base.component";
import {NgxSpinnerService} from "ngx-spinner";

declare var alertify:any;

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent extends  BaseComponent implements OnInit {

  constructor(private alertifyService:AlertifyService,spinner:NgxSpinnerService) {
    super(spinner);
  }

  ngOnInit(): void {
  this.showSpinner(SpinnerType.BallAtom)

  }
  m(){
    this.alertifyService.message("Hello",{
      messageType:MessageType.Success,
      delay:5,
      position:Position.BottomRight
    })

  }
  d(){
    this.alertifyService.dismiss();
  }

}
