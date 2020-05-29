import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import apiCardsData from '../../../assets/data/apiCards.json';

export interface ApiCardInner{
  apiType: string;
  apiPath: string;
  apiDescription: string;
}

export interface ApiCard{
  header: string;
  inners: ApiCardInner[];
}

@Component({
  selector: 'app-api',
  templateUrl: './api.component.html',
  styleUrls: ['./api.component.css']
})
export class ApiComponent implements OnInit {
  apiCards: ApiCard[] = apiCardsData;

  constructor(
    private titleService: Title) { }

  ngOnInit(): void {
    this.titleService.setTitle('Документация по API');
  }
}
