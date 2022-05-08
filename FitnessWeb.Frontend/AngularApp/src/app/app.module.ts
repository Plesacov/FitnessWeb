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
import { ToastrModule, ToastNoAnimation, ToastNoAnimationModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    HoverMenuComponent,
    NavBarComponent,
    FitnessProgramComponent,
    SignInComponent,
    SignUpComponent
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
  ],
  providers: [FitnessProgramService,FitnessProgramResolver],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ]
})
export class AppModule { }
