import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit, OnDestroy {

  constructor(private router: Router) { }

  private timer: any;

  ngOnInit() {
    const delay = 5000;
    this.timer = setTimeout(() => {
      this.router.navigate(['']);
     }, delay);
  }

  ngOnDestroy(){
    clearTimeout(this.timer);
  }

}
