import { Component, OnInit, Input } from '@angular/core';

import { ApiCard } from '../../views/api/api.component';

@Component({
  selector: 'app-api-card',
  templateUrl: './api-card.component.html',
  styleUrls: ['./api-card.component.css']
})
export class ApiCardComponent implements OnInit {

  @Input() card: ApiCard

  // apiTypeClass = 'badge '+setApiTypeClass();

  setApiTypeClass(value: string): string{

    let apiTypeClass = 'badge ';
    value = value.toLowerCase();
    if(value === 'get'){
      apiTypeClass += 'badge-primary';
      return apiTypeClass;
    }
    if(value === 'post'){
      apiTypeClass += 'badge-success';
      return apiTypeClass;
    }
    if(value === 'put'){
      apiTypeClass += 'badge-warning';
      return apiTypeClass;
    }
    if(value === 'delete'){
      apiTypeClass += 'badge-danger';
      return apiTypeClass;
    }
  }

  constructor() { }

  ngOnInit(): void {
  }

}
