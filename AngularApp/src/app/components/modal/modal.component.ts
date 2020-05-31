import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
// import { EventEmitter } from 'protractor';

export interface Modal{
  header: string;
  body: string;
  acceptBtnText: string;
  cancelBtnText: string;
  id: number;
}

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  constructor() { }
  @Input() modal: Modal;
  @Output() action = new EventEmitter<number>();
  clickHandler(action: boolean){
    if (action) {
      this.action.emit(this.modal.id);
    }
    else{
      this.action.emit(null);
    }
  }

  ngOnInit(): void {
  }

}
