import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FitnessProgramService } from 'src/services/fitnessProgram.service';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { HoverMenuComponent } from './components/hover-menu/hover-menu.component';
import { NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialExampleModule } from './material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { FitnessProgramComponent } from './components/fitness-program/fitness-program.component';
import { FitnessProgramResolver } from './components/fitness-program/fitness-program.resolve';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { ToastrModule, ToastNoAnimationModule } from 'ngx-toastr';
import { ProfilePageComponent } from './components/profile-page/profile-page.component';
import { UploadImagesComponent } from './components/upload-image/upload-image.component';
import { DialogComponent } from './components/dialog/dialog.component';
import { FitnessProgramTableComponent } from './components/admin-components/fitness-program-table/fitness-program-table.component';
import { MatSortModule } from '@angular/material/sort';
import { AddEditFitnessProgramComponent } from './components/admin-components/add-edit-fitness-program/add-edit-fitness-program.component';

import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { FitnessTipProgramTableComponent } from './components/admin-components/fitness-tip-program-table/fitness-tip-program-table.component';

@NgModule({
  declarations: [
    AppComponent,
    HoverMenuComponent,
    NavBarComponent,
    FitnessProgramComponent,
    SignInComponent,
    SignUpComponent,
    ProfilePageComponent,
    UploadImagesComponent,
    DialogComponent,
    FitnessProgramTableComponent,
    AddEditFitnessProgramComponent,
    FitnessTipProgramTableComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatNativeDateModule,
    MaterialExampleModule,
    ReactiveFormsModule,
    AppRoutingModule,
    ToastrModule,
    ToastNoAnimationModule.forRoot(),
    MatSortModule,
    MatDialogModule
  ],
  providers: [FitnessProgramService, FitnessProgramResolver,
    {
      provide: MatDialogRef,
      useValue: {}
    },],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ]
})
export class AppModule { }
