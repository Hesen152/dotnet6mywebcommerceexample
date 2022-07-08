import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {LayoutModule} from "./layout/layout.module";
import {ComponentsModule} from "./components/components.module";
import { DeleteDirective } from './directives/delete.directive';
import {AppComponent} from "../app.component";



@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    LayoutModule
  ],
    exports: [
        LayoutModule,
        ComponentsModule,

    ]
})
export class AdminModule { }
