import { Component, OnInit } from '@angular/core';
import { HttpService} from '../../services/http.service';
import { ApiConfig } from 'src/assets/configure/api-config';

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

  constructor(private httpService: HttpService, private apiConfig: ApiConfig ) {
    this.url = this.apiConfig.url + this.apiConfig.activityTypes;
   }

   url: string;
  ngOnInit(){
    console.log(this.apiConfig.url + this.apiConfig.activityTypes);
    this.httpService.get(this.apiConfig.url + this.apiConfig.activityTypes).subscribe((data: ActivityType[]) => this.types = data);
  }
}
