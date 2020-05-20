import { Component, OnInit } from '@angular/core';
import { HttpService} from '../../services/http.service';

interface IdType{
  identifier: number;
}

interface ActivityType{
  name: string;
  id: IdType;
}

@Component({
  selector: 'app-activity-types',
  templateUrl: './activity-types.component.html',
  styleUrls: ['./activity-types.component.css'],
  providers: [HttpService]
})
export class ActivityTypesComponent implements OnInit {

  types: ActivityType[];

  constructor(private httpService: HttpService) { }
  ngOnInit(){

    this.httpService.get('http://localhost:65491/api/ActivityTypes').subscribe((data: ActivityType[]) => this.types = data);
  }

}
