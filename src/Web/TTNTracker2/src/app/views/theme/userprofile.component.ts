import { TemplateRef } from '@angular/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective, BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  //selector: 'app-dashboard',
  templateUrl: './userprofile.component.html',
  styles: [
  ]
})
export class UserprofileComponent implements OnInit {
  @ViewChild('largeModal') public largeModal: ModalDirective;
  constructor(private modalService: BsModalService) { }

  ngOnInit(): void {
  }
  isCollapsed: boolean = false;

  collapsed(event: any): void {
    // console.log(event);
  }

  expanded(event: any): void {
    // console.log(event);
  }
  modalRef: BsModalRef;
  openModalWithClass(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(
      template, { class: 'modal-lg' }
      // Object.assign({}, { class: 'gray modal-lg' })
    );
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
