import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  form: any = {
    username: null,
    email: null,
    password: null
  };
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';
  constructor(private router:Router) { }
  ngOnInit(): void {
  }
  onSubmit(): void {
    const { username, email, password } = this.form;

  }

  redirectToSignIn(): void {
    this.router.navigate(['/signin']);
  }
}