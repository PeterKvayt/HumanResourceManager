import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit, OnDestroy {

  constructor() { }

  private timer: any;

  ngOnInit() {
    const delay = 5000;
    this.timer = setTimeout(() => {
      const btn = document.getElementById('toHomeBtn');
      btn.click();
     }, delay);
  }

  ngOnDestroy(){
    clearTimeout(this.timer);
  }

}
