import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'hover-menu',
  templateUrl: './hover-menu.component.html',
  styleUrls: ['./hover-menu.component.css']
})
export class HoverMenuComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.reloadComponent();
  }

  reloadComponent() {
    let currentUrl = this.route.url;
        this.router.routeReuseStrategy.shouldReuseRoute = () => false;
        this.router.onSameUrlNavigation = 'reload';
        this.router.navigate([currentUrl]);
    }

}
