import {  Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  @Input() links!: Link[];

  constructor() {
  }
  ngOnInit(): void {

  }
}

interface Link{
  name: string,
  routerLink: string
}

export {Link}