import { Component, OnInit } from '@angular/core';

interface ActivityType{
  Name: string;
  Id: number;
}

@Component({
  selector: 'app-activity-types',
  templateUrl: './activity-types.component.html',
  styleUrls: ['./activity-types.component.css']
})
export class ActivityTypesComponent implements OnInit {

  types: ActivityType[] = [
    {
      Name: 'Gambling',
      Id: 0
    },
    {
      Name: 'Development',
      Id: 1
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
