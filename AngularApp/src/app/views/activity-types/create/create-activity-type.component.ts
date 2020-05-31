import { Component, OnInit, OnDestroy } from '@angular/core';
import apiSettings from '../../../../assets/configure/api.config.json';
import { Title } from '@angular/platform-browser';
import { HttpService } from '../../../services/http.service';
import { ActivityType } from '../activityType';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-activity-type',
  templateUrl: './create-activity-type.component.html',
  styleUrls: ['./create-activity-type.component.css'],
  providers: [HttpService]
})
export class CreateActivityTypeComponent implements OnInit, OnDestroy {

  constructor(
    private titleService: Title,
    private httpService: HttpService,
    private router: Router) { }

  alert = false;
  model: ActivityType = {
    name: '',
    id: {
      identifier: 0
    }
  };
  controllerName = apiSettings.activityTypes;
  alertMessage = 'Для создания вида деятельности необходимо заполнить все поля!';
  private subscription: Subscription;
  private timer: any;
  ngOnInit(): void {
    this.titleService.setTitle('Создание вида деятельности');
  }

  accept(){
    if (this.model.name.length > 0) {
      const url = apiSettings.url + apiSettings.activityTypes;
      this.subscription = this.httpService.post<ActivityType>(url, this.model)
        .subscribe();
      this.timer = setTimeout(() => {
          this.redirect();
        }, 50);
    }
    else{
      this.alert = true;
    }
  }

  ngOnDestroy(){
    if (this.subscription !== undefined) {
      this.subscription.unsubscribe();
      clearTimeout(this.timer);
    }
  }

  changeHandler(event: any){
    this.model.name = event.target.value;
    if (this.model.name.length > 0) {
      this.alert = false;
    } else {
      this.alert = true;
    }
  }

  redirect(){
    this.router.navigate([this.controllerName]);
  }
}
