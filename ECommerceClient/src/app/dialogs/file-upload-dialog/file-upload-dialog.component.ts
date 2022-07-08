import {Component, Inject, OnInit} from '@angular/core';
import {Basedialog} from "../base/basedialog";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-file-upload-dialog',
  templateUrl: './file-upload-dialog.component.html',
  styleUrls: ['./file-upload-dialog.component.css']
})
export class FileUploadDialogComponent extends  Basedialog<FileUploadDialogComponent>{

  constructor(dialogRef:MatDialogRef<FileUploadDialogComponent> ,
              @Inject(MAT_DIALOG_DATA) public data: FileUploadDialogState) {
  super(dialogRef);
  }

  ngOnInit(): void {
  }

}
export enum FileUploadDialogState{
  yes,
  no
}
