import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserForAuthenticationDto } from './auth';
import { AuthenticationService } from '../../../services/authentication.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  public loginForm!: FormGroup;
  public errorMessage: string = '';
  public showError!: boolean;
  private _returnUrl!: string;

  constructor(private _authService: AuthenticationService, private _router: Router, private _route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    })
    this._returnUrl = this._route.snapshot.queryParams['returnUrl'] || '/';
  }
  public validateControl = (controlName: string) => {
    return this.loginForm.controls[controlName].invalid && this.loginForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.loginForm.controls[controlName].hasError(errorName)
  }
  public loginUser = (loginFormValue: any) => {
    this.showError = false;
    const login = { ...loginFormValue };
    const userForAuth: UserForAuthenticationDto = {
      email: login.username,
      password: login.password
    }
    this._authService.loginUser('api/accounts/Login', userForAuth)
      .subscribe((res: any) => {
        localStorage.setItem("token", res.token);
        this.showSuccess();
        this.refresh();
      },
        () => {
          this.errorMessage = "Invalid Email or Password";
          this.showError = true;
        })
  }

  showSuccess() {
    this.toastr.success('Login successfull', 'Success');
  }

  refresh(): void {
    this._router.navigate([this._returnUrl]).then(() => {
      window.location.reload();
    }
    )}
  }


