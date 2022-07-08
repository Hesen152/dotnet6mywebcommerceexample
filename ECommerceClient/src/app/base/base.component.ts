import {Component, OnInit} from '@angular/core';
import {NgxSpinnerService} from "ngx-spinner";


export class BaseComponent {

  constructor(private spinner: NgxSpinnerService) {
  }

  showSpinner(spinnerNameType: SpinnerType) {
    this.spinner.show(spinnerNameType)

    setTimeout(
      () => {
        this.spinner.hide(spinnerNameType)
      },
      1200
    );

  }

  hideSpinner(spinnerNameType: SpinnerType) {
    this.spinner.hide(spinnerNameType)
  }
}

export enum SpinnerType {
  BallAtom = "s1",
  BallScaleMuiltiple = "s2",
  BallSpinClockwise = "s3"
}
