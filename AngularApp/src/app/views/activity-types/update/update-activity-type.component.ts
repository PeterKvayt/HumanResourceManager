import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import apiSettings from '../../../../assets/configure/api.config.json';
import { Title } from '@angular/platform-browser';
import { HttpService } from '../../../services/http.service';
import { ActivityType } from '../activityType';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-update-activity-type',
  templateUrl: './update-activity-type.component.html',
  styleUrls: ['./update-activity-type.component.css'],
  providers: [HttpService]
})
export class UpdateActivityTypeComponent implements OnInit, OnDestroy {

  constructor(
    private titleService: Title,
    private httpService: HttpService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
      this.routeSubscription = activatedRoute.params.subscribe(params => this.id = params['id']);
    }
    
    id: number;
    alert = false;
    model: ActivityType;
    controllerName = apiSettings.activityTypes;
    alertMessage = 'Для изменения вида деятельности необходимо заполнить все поля!';
    private updateSubscription: Subscription;
    private routeSubscription: Subscription;
    private getSubscription: Subscription;
    ngOnInit(): void {
      const url = apiSettings.url + apiSettings.activityTypes;
      console.log(url);
      this.getSubscription = this.httpService.getById(url, this.id).subscribe((data: ActivityType) => {
        this.model = data;
      });
      this.titleService.setTitle('Изменение вида деятельности');
    }

    accept(){
      if (this.model.name.length > 0) {
        const url = apiSettings.url + apiSettings.activityTypes;
        this.updateSubscription = this.httpService.put<ActivityType>(url, this.model)
          .subscribe(() => {
            this.redirect();
          });
      }
      else{
        this.alert = true;
      }
    }

    ngOnDestroy(){
      if (this.updateSubscription !== undefined) {
        this.updateSubscription.unsubscribe();
      }

      this.getSubscription.unsubscribe();
      this.routeSubscription.unsubscribe();
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
