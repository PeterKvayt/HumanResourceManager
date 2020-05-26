import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

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

  //
  homeCards: HomeCard[] = [
    {
      link : '/employees',
      title: 'Управление сотрудниками',
      description : 'Для просмотра, удаления, изменения и создания новых сотрудников, нажмите',
      buttonText : 'Просмотреть сотрудников'
    },
    {
      link : '/positions',
      title: 'Управление должностями',
      description : 'Для просмотра, удаления, изменения и создания новых должностей, нажмите',
      buttonText : 'Просмотреть должности'
    },
    {
      link : '/activityTypes',
      title: 'Управление видами деятельности компаний',
      description : 'Для просмотра, удаления, изменения и создания новых видов деятельности, нажмите',
      buttonText : 'Просмотреть виды деятельности компаний'
    },
    {
      link : '/legalForms',
      title: 'Управление организационно-правовыми формами',
      description : 'Для просмотра, удаления, изменения и создания новых организационно-правовых форм, нажмите',
      buttonText : 'Просмотреть организационно-правовые формы'
    },
    {
      link : '/companies',
      title: 'Управление компаниями',
      description : ' Для просмотра, удаления, изменения и создания новых компаний, нажмите',
      buttonText : 'Просмотреть компании'
    }
  ];

  constructor(private titleService: Title) { }

  ngOnInit(): void {
    this.titleService.setTitle('HRM | Human Resource Manager');
  }

}
