import { Component, OnInit } from '@angular/core';

interface LinkListItem{
  link: string
  text: string
  pictClass: string
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  links: LinkListItem[] =[
    {
      link: '/employees',
      text: 'Сотрудники',
      pictClass: 'fa fa-id-card'
    },
    {
      link: '/companies',
      text: 'Компании',
      pictClass: 'fa fa-bank'
    },
    {
      link: '/positions',
      text: 'Должности',
      pictClass: 'fa fa-briefcase'
    },
    {
      link: '/legalForms',
      text: 'Оргформы',
      pictClass: 'fa fa-book'
    },
    {
      link: '/activityTypes',
      text: 'Деятельность',
      pictClass: 'fa fa-flash'
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
