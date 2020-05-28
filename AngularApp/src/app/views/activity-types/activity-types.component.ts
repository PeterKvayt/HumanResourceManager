import { Component, OnInit, DoCheck, OnDestroy } from '@angular/core';
import { HttpService} from '../../services/http.service';
import { Subscription } from 'rxjs';
import { Title } from '@angular/platform-browser';
import apiSettings from '../../../assets/configure/api.config.json';

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

  constructor(private httpService: HttpService, private titleService: Title ) {}

  types: ActivityType[] = [];
  controllerName = apiSettings.activityTypes;
  wrapperClass = 'hide-img-wrapper';
  private subscription: Subscription;

  ngOnInit(){
    this.titleService.setTitle('Виды деятельности');
    this.subscription =  this.httpService.get(apiSettings.url + apiSettings.activityTypes)
      .subscribe((data: ActivityType[]) => this.types = data);
  }
  ngDoCheck(){
    this.wrapperClass =  this.types.length === 0 ? 'show-img-wrapper' : 'hide-img-wrapper';
  }

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }
}
