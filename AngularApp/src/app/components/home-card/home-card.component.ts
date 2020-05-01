import { Component, OnInit, Input } from '@angular/core';

import { HomeCard } from '../../views/home/home.component';

@Component({
  selector: 'app-home-card',
  templateUrl: './home-card.component.html',
  styleUrls: ['./home-card.component.css']
})
export class HomeCardComponent implements OnInit {

  @Input() homeCard: HomeCard

  constructor() { }

  ngOnInit(): void {
  }

}
