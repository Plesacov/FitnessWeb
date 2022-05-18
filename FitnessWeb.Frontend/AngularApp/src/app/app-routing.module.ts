import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/services/auth.guard';
import { FitnessProgramViewModel } from 'src/viewModels/fitnessProgramViewModel';
import { AboutComponent } from './components/about/about.component';
import { AddEditFitnessProgramComponent } from './components/admin-components/add-edit-fitness-program/add-edit-fitness-program.component';
import { FitnessProgramTableComponent } from './components/admin-components/fitness-program-table/fitness-program-table.component';
import { FitnessTipProgramTableComponent } from './components/admin-components/fitness-tip-program-table/fitness-tip-program-table.component';
import { FitnessProgramComponent } from './components/fitness-program/fitness-program.component';
import { FitnessProgramResolver } from './components/fitness-program/fitness-program.resolve';
import { HomePageComponent } from './components/home-page/home-page.component';
import { ProfilePageComponent } from './components/profile-page/profile-page.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'signin', component: SignInComponent },
  { path: 'signup', component: SignUpComponent },
  { path: 'about', component: AboutComponent, canActivate: [AuthGuard] },
  { path: 'home', component: HomePageComponent },
  { path: 'page', component: ProfilePageComponent, canActivate: [AuthGuard] },
  {
    path: 'fitnessProgram/:id', component: FitnessProgramComponent, resolve: {
      fitnessProgram: FitnessProgramResolver
    }
  },
  { path: 'admin/fitnessPrograms', component: FitnessProgramTableComponent },
  { path: 'admin/fitnessTips', component: FitnessTipProgramTableComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
