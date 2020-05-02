import { Component, OnInit } from '@angular/core';

export interface ApiCardInner{
  apiType: string
  apiPath: string
  apiDescription: string
}

export interface ApiCard{
  header: string
  inners: ApiCardInner[]
}

@Component({
  selector: 'app-api',
  templateUrl: './api.component.html',
  styleUrls: ['./api.component.css']
})
export class ApiComponent implements OnInit {

  apiCards: ApiCard[] = [
    {
      header: 'Работа с видами деятельности',
      inners: [
        {
          apiType: 'GET',
          apiPath: 'api/ActivityTypes',
          apiDescription: 'возвращает все виды деятельности'
        },
        {
          apiType: 'GET',
          apiPath: 'api/ActivityTypes/id',
          apiDescription: 'возвращает конкретный вид деятельности по параметру id'
        },
        {
          apiType: 'POST',
          apiPath: 'api/ActivityTypes/model',
          apiDescription: 'запрос на создание нового вида деятельности с параметром model'
        },
        {
          apiType: 'PUT',
          apiPath: 'api/ActivityTypes/model',
          apiDescription: 'запрос на обновление вида деятельности с параметром model'
        },
        {
          apiType: 'DELETE',
          apiPath: 'api/ActivityTypes/id',
          apiDescription: 'запрос на удаление вида деятельности по параметру id'
        }
      ]
    },
    {
      header: 'Работа с компаниями',
      inners: [
        {
          apiType: 'GET',
          apiPath: 'api/Companies',
          apiDescription: 'возвращает все компании'
        },
        {
          apiType: 'GET',
          apiPath: 'api/Companies/id',
          apiDescription: 'возвращает конкретную компанию по параметру id'
        },
        {
          apiType: 'POST',
          apiPath: 'api/Companies/model',
          apiDescription: 'запрос на создание новой компании с параметром model'
        },
        {
          apiType: 'PUT',
          apiPath: 'api/Companies/model',
          apiDescription: 'запрос на обновление компании с параметром model'
        },
        {
          apiType: 'DELETE',
          apiPath: 'api/Companies/id',
          apiDescription: 'запрос на удаление компании по параметру id'
        }
      ]
    },
    {
      header: 'Работа с должностями сотрудников',
      inners: [
        {
          apiType: 'GET',
          apiPath: 'api/Positions',
          apiDescription: 'возвращает все должности'
        },
        {
          apiType: 'GET',
          apiPath: 'api/Positions/id',
          apiDescription: 'возвращает конкретную должность по параметру id'
        },
        {
          apiType: 'POST',
          apiPath: 'api/Positions/model',
          apiDescription: 'запрос на создание новой должности с параметром model'
        },
        {
          apiType: 'PUT',
          apiPath: 'api/Positions/model',
          apiDescription: 'запрос на обновление должности с параметром model'
        },
        {
          apiType: 'DELETE',
          apiPath: 'api/Positions/id',
          apiDescription: 'запрос на удаление должности по параметру id'
        }
      ]
    },
    {
      header: 'Работа с организационно-правовыми формами',
      inners: [
        {
          apiType: 'GET',
          apiPath: 'api/LegalForms',
          apiDescription: 'возвращает все организационно-правовые формы деятельности компаний'
        },
        {
          apiType: 'GET',
          apiPath: 'api/LegalForms/id',
          apiDescription: 'возвращает конкретную организационно-правовую форму деятельности компании по параметру id'
        },
        {
          apiType: 'POST',
          apiPath: 'api/LegalForms/model',
          apiDescription: 'запрос на создание новой организационно-правовой формы деятельности компаний с параметром model'
        },
        {
          apiType: 'PUT',
          apiPath: 'api/LegalForms/model',
          apiDescription: 'запрос на обновление организационно-правовой формы деятельности компаний с параметром model'
        },
        {
          apiType: 'DELETE',
          apiPath: 'api/LegalForms/id',
          apiDescription: 'запрос на удаление организационно-правовой формы деятельности компаний по параметру id'
        }
      ]
    },
    {
      header: 'Работа с сотрудниками',
      inners: [
        {
          apiType: 'GET',
          apiPath: 'api/Employees',
          apiDescription: 'возвращает всех сотрудников'
        },
        {
          apiType: 'GET',
          apiPath: 'api/Employees/id',
          apiDescription: 'возвращает конкретного сотрудника по параметру id'
        },
        {
          apiType: 'POST',
          apiPath: 'api/Employees/model',
          apiDescription: 'запрос на создание нового сотрудника с параметром model'
        },
        {
          apiType: 'PUT',
          apiPath: 'api/Employees/model',
          apiDescription: 'запрос на обновление сотрудника с параметром model'
        },
        {
          apiType: 'DELETE',
          apiPath: 'api/Employees/id',
          apiDescription: 'запрос на удаление сотрудника по параметру id'
        }
      ]
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
