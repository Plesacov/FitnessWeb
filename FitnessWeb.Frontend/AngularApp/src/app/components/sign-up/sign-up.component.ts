import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserForAuthenticationDto, UserForRegistrationDto } from '../sign-in/auth';
import { AuthenticationService } from '../../../services/authentication.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  public registerForm!: FormGroup;
  maxDate: Date = new Date();
  private _returnUrl!: string;

  constructor(private _authService: AuthenticationService, private _router: Router, private _route: ActivatedRoute, private toastr: ToastrService) { }
  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('', Validators.required),
      birthdate: new FormControl('', Validators.required),
      weight: new FormControl('', [Validators.required]),
      height: new FormControl('', Validators.required),
    });

    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear());

    this._returnUrl = this._route.snapshot.queryParams['returnUrl'] || '/';
  }
  public validateControl = (controlName: string) => {
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName)
  }
  public registerUser = (registerFormValue: any) => {
    const formValues = { ...registerFormValue };
    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm,
      birthdate: formValues.birthdate,
      weight: formValues.weight,
      height: formValues.height,
    };
    console.log(user);
    this._authService.registerUser("api/accounts/Registration", user)
      .subscribe(_ => {
        this.showSuccess();
        const userForAuth: UserForAuthenticationDto = {
          email: user.email,
          password: user.password
        }
        this._authService.loginUser('api/accounts/Login', userForAuth)
          .subscribe((res: any) => {
            localStorage.setItem("token", res.token);
            this._router.navigate([this._returnUrl]);
          },
          )
      },
        error => {
          console.log(error.error.errors);
          this.showError(error.error.errors);
        })
  }

  showSuccess() {
    this.toastr.success('Registration successfull', 'Success');
  }
  showError(error: string) {
    this.toastr.error(`${error}', 'Error`);
  }
}