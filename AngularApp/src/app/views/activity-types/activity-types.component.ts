import { Component, OnInit, DoCheck, OnDestroy } from '@angular/core';
import { HttpService} from '../../services/http.service';
import { Subscription } from 'rxjs';
import { Title } from '@angular/platform-browser';
import apiSettings from '../../../assets/configure/api.config.json';
import { ActivityType } from './activityType';
import { Modal } from 'src/app/components/modal/modal.component';

@Component({
  selector: 'app-activity-types',
  templateUrl: './activity-types.component.html',
  styleUrls: ['./activity-types.component.css'],
  providers: [HttpService]
})
export class ActivityTypesComponent implements OnInit, DoCheck, OnDestroy {

  constructor(
    private httpService: HttpService,
    private titleService: Title
    ) {}

  types: ActivityType[] = [];
  controllerName = apiSettings.activityTypes;
  wrapperClass = 'hide-img-wrapper';
  private getSubscription: Subscription;
  dataTarget = '#delete-modal';
  modalInfo: Modal = {
    header: 'Удаление вида деятельности',
    body: 'При удалении вида деятельности удаляются связанные с этим видом деятельности компании и сотрудники, работающие в компании! Вы уверены?',
    acceptBtnText: 'Подтвердить',
    cancelBtnText: 'Отмена',
    id: 0
  };
  showModal = false;
  ngOnInit(){
    this.titleService.setTitle('Виды деятельности');
    this.getActivityTypes();
  }
  ngDoCheck(){
    this.wrapperClass =  this.types.length === 0 ? 'show-img-wrapper' : 'hide-img-wrapper';
  }

  ngOnDestroy(){
    this.getSubscription.unsubscribe();
  }
  onDeleteClick(id: number){
    this.modalInfo.id = id;
    this.showModal = true;
  }

  deletionHandler(id: number){
    if (id !== null) {
      const url = apiSettings.url + apiSettings.activityTypes;
      this.httpService.delete(url, id).subscribe(() => {
        this.getActivityTypes();
      });
    }
  }

  private getActivityTypes(){
    this.getSubscription =  this.httpService.get(apiSettings.url + apiSettings.activityTypes)
      .subscribe((data: ActivityType[]) => this.types = data);
  }
}
