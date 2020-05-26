import { Component, OnInit, DoCheck, OnDestroy } from '@angular/core';
import { HttpService} from '../../services/http.service';
import { ApiConfig } from 'src/assets/configure/api-config';
import { Subscription } from 'rxjs';
import { Title } from '@angular/platform-browser';

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
export class ActivityTypesComponent implements OnInit, DoCheck, OnDestroy {

  constructor(private httpService: HttpService, private apiConfig: ApiConfig, private titleService: Title ) {
    this.url = this.apiConfig.url + this.apiConfig.activityTypes;
   }

  types: ActivityType[] = [];

  url: string;

  wrapperClass = 'hide-img-wrapper';
  subscription: Subscription;

  ngOnInit(){
    this.titleService.setTitle('Виды деятельности');
    const url = this.apiConfig.url + this.apiConfig.activityTypes;
    this.subscription =  this.httpService.get(url)
      .subscribe((data: ActivityType[]) => this.types = data);
  }
  ngDoCheck(){
    this.wrapperClass =  this.types.length === 0 ? 'show-img-wrapper' : 'hide-img-wrapper';
  }

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

  setTitle(title: string){
    this.titleService.setTitle(title);
  }
}
