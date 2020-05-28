import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import homeCards from '../../../assets/data/homecards.json';

export interface HomeCard{
  link: string;
  title: string;
  description: string;
  buttonText: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  homeCards: HomeCard[] = homeCards;

  constructor(private titleService: Title) { }

  ngOnInit(): void {
    this.titleService.setTitle('HRM | Human Resource Manager');
  }

}
