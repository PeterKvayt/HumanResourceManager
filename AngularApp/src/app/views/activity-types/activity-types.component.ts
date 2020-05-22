import { Component, OnInit, DoCheck } from '@angular/core';
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
export class ActivityTypesComponent implements OnInit, DoCheck {

  constructor(private httpService: HttpService, private apiConfig: ApiConfig ) {
    this.url = this.apiConfig.url + this.apiConfig.activityTypes;
   }

  types: ActivityType[] = [];

  url: string;

  wrapperClass = 'hide-img-wrapper';
  ngOnInit(){
    console.log('onInit');
    const url = this.apiConfig.url + this.apiConfig.activityTypes;
    this.httpService.get(url)
      .subscribe((data: ActivityType[]) => this.types = data);
  }

  ngDoCheck(){
    setTimeout(() => {
      console.log(this.types.length);
      this.wrapperClass =  this.types.length === 0 ? 'show-img-wrapper' : 'hide-img-wrapper';
    }, 250);
  }
}