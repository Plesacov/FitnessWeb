import { Injectable, NgModule } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterModule, RouterStateSnapshot, Routes, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthGuard } from 'src/services/auth.guard';
import { AuthenticationService } from 'src/services/authentication.service';
import { FitnessProgramViewModel } from 'src/viewModels/fitnessProgramViewModel';
import { CanActivateAdmin } from './canActivateAdminComponents';
import { AboutComponent } from './components/about/about.component';
import { AddEditFitnessProgramComponent } from './components/admin-components/add-edit-fitness-program/add-edit-fitness-program.component';
import { FitnessExerciseTableComponent } from './components/admin-components/fitness-exercise-table/fitness-exercise-table.component';
import { FitnessProgramTableComponent } from './components/admin-components/fitness-program-table/fitness-program-table.component';
import { FitnessTipProgramTableComponent } from './components/admin-components/fitness-tip-program-table/fitness-tip-program-table.component';
import { FitnessTrainingTableComponent } from './components/admin-components/fitness-training-table/fitness-training-table.component';
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
  { path: 'admin/fitnessPrograms', component: FitnessProgramTableComponent, canActivate: [CanActivateAdmin] },
  { path: 'admin/fitnessTips', component: FitnessTipProgramTableComponent, canActivate: [CanActivateAdmin] },
  { path: 'admin/fitnessTrainings', component: FitnessTrainingTableComponent, canActivate: [CanActivateAdmin] },
  { path: 'admin/fitnessExercises', component: FitnessExerciseTableComponent, canActivate: [CanActivateAdmin] },
  { path: '**', redirectTo: '/home', pathMatch: 'full' }];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })],
  exports: [RouterModule],
  providers: [CanActivateAdmin]
})
export class AppRoutingModule {
}