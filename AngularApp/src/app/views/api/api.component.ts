import { Component, OnInit } from '@angular/core';
import { ApiConfig } from 'src/assets/configure/api-config';
import { Title } from '@angular/platform-browser';
import apiSettings from '../../../assets/configure/api.config.json';

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
  apiConfig: ApiConfig = apiSettings;
  private apiUrl = this.apiConfig.url;
  private apiActivityTypes = this.apiUrl + this.apiConfig.activityTypes;
  private apiPositions = this.apiUrl + this.apiConfig.positions;
  private apiLegalforms = this.apiUrl + this.apiConfig.legalForms;
  private apiCompanies  = this.apiUrl + this.apiConfig.companies;
  private apiEmployees = this.apiUrl + this.apiConfig.employees;

  apiCards: ApiCard[] = [
    {
      header: 'Работа с видами деятельности',
      inners: [
        {
          apiType: 'GET',
          apiPath: this.apiActivityTypes,
          apiDescription: 'возвращает все виды деятельности'
        },
        {
          apiType: 'GET',
          apiPath: this.apiActivityTypes + '/id',
          apiDescription: 'возвращает конкретный вид деятельности по параметру id'
        },
        {
          apiType: 'POST',
          apiPath: this.apiActivityTypes + '/model',
          apiDescription: 'запрос на создание нового вида деятельности с параметром model'
        },
        {
          apiType: 'PUT',
          apiPath: this.apiActivityTypes + '/model',
          apiDescription: 'запрос на обновление вида деятельности с параметром model'
        },
        {
          apiType: 'DELETE',
          apiPath: this.apiActivityTypes + '/id',
          apiDescription: 'запрос на удаление вида деятельности по параметру id'
        }
      ]
    },
    {
      header: 'Работа с компаниями',
      inners: [
        {
          apiType: 'GET',
          apiPath: this.apiCompanies,
          apiDescription: 'возвращает все компании'
        },
        {
          apiType: 'GET',
          apiPath: this.apiCompanies + '/id',
          apiDescription: 'возвращает конкретную компанию по параметру id'
        },
        {
          apiType: 'POST',
          apiPath: this.apiCompanies + '/model',
          apiDescription: 'запрос на создание новой компании с параметром model'
        },
        {
          apiType: 'PUT',
          apiPath: this.apiCompanies + '/model',
          apiDescription: 'запрос на обновление компании с параметром model'
        },
        {
          apiType: 'DELETE',
          apiPath: this.apiCompanies + '/id',
          apiDescription: 'запрос на удаление компании по параметру id'
        }
      ]
    },
    {
      header: 'Работа с должностями сотрудников',
      inners: [
        {
          apiType: 'GET',
          apiPath: this.apiPositions,
          apiDescription: 'возвращает все должности'
        },
        {
          apiType: 'GET',
          apiPath: this.apiPositions + '/id',
          apiDescription: 'возвращает конкретную должность по параметру id'
        },
        {
          apiType: 'POST',
          apiPath: this.apiPositions + '/model',
          apiDescription: 'запрос на создание новой должности с параметром model'
        },
        {
          apiType: 'PUT',
          apiPath: this.apiPositions + '/model',
          apiDescription: 'запрос на обновление должности с параметром model'
        },
        {
          apiType: 'DELETE',
          apiPath: this.apiPositions + '/id',
          apiDescription: 'запрос на удаление должности по параметру id'
        }
      ]
    },
    {
      header: 'Работа с организационно-правовыми формами',
      inners: [
        {
          apiType: 'GET',
          apiPath: this.apiLegalforms,
          apiDescription: 'возвращает все организационно-правовые формы деятельности компаний'
        },
        {
          apiType: 'GET',
          apiPath: this.apiLegalforms + '/id',
          apiDescription: 'возвращает конкретную организационно-правовую форму деятельности компании по параметру id'
        },
        {
          apiType: 'POST',
          apiPath: this.apiLegalforms + '/model',
          apiDescription: 'запрос на создание новой организационно-правовой формы деятельности компаний с параметром model'
        },
        {
          apiType: 'PUT',
          apiPath: this.apiLegalforms + '/model',
          apiDescription: 'запрос на обновление организационно-правовой формы деятельности компаний с параметром model'
        },
        {
          apiType: 'DELETE',
          apiPath: this.apiLegalforms + '/id',
          apiDescription: 'запрос на удаление организационно-правовой формы деятельности компаний по параметру id'
        }
      ]
    },
    {
      header: 'Работа с сотрудниками',
      inners: [
        {
          apiType: 'GET',
          apiPath: this.apiEmployees,
          apiDescription: 'возвращает всех сотрудников'
        },
        {
          apiType: 'GET',
          apiPath: this.apiEmployees + '/id',
          apiDescription: 'возвращает конкретного сотрудника по параметру id'
        },
        {
          apiType: 'POST',
          apiPath: this.apiEmployees + '/model',
          apiDescription: 'запрос на создание нового сотрудника с параметром model'
        },
        {
          apiType: 'PUT',
          apiPath: this.apiEmployees + '/model',
          apiDescription: 'запрос на обновление сотрудника с параметром model'
        },
        {
          apiType: 'DELETE',
          apiPath: this.apiEmployees + '/id',
          apiDescription: 'запрос на удаление сотрудника по параметру id'
        }
      ]
    }
  ];

  constructor(
    private titleService: Title) { }

  ngOnInit(): void {
    this.titleService.setTitle('Документация по API');
  }
}
