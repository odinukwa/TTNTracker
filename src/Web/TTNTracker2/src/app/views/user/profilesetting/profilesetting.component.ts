import { TemplateRef, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ModalDirective, BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { UserProfileModel } from '../../../models/userProfileModel';

@Component({
  selector: 'app-profilesettings',
  templateUrl: './profilesetting.component.html',
  styles: [
  ]
})
export class ProfilesettingComponent implements OnInit {

  @ViewChild('largeModal') public largeModal: ModalDirective;
  constructor(private modalService: BsModalService) { }
  formData = new UserProfileModel();
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
  onSubmit() {
    console.log(this.formData);
  }
}
