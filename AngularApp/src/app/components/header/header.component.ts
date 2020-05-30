import { Component, OnInit } from '@angular/core';

interface LinkListItem{
  link: string;
  text: string;
  pictClass: string;
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  links: LinkListItem[] = [
    {
      link: '/Employees',
      text: 'Сотрудники',
      pictClass: 'fa fa-id-card'
    },
    {
      link: '/Companies',
      text: 'Компании',
      pictClass: 'fa fa-bank'
    },
    {
      link: '/Positions',
      text: 'Должности',
      pictClass: 'fa fa-briefcase'
    },
    {
      link: '/LegalForms',
      text: 'Оргформы',
      pictClass: 'fa fa-book'
    },
    {
      link: '/ActivityTypes',
      text: 'Деятельность',
      pictClass: 'fa fa-flash'
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
