import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    const delay = 5000;

    setTimeout(() => {
     let btn = document.getElementById('toHomeBtn');
     btn.click();

    }, delay);
  }

}
